using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Data.SQLite;

namespace ImperionBrowser
{
    class FlightTime
    {
        /// <summary>
        /// This method can calculate the flight time from a sourcesystem, to a destination system.
        /// This is done by a webrequest, if the flight time was never calculated before. If
        /// it was calculated before, the flighttime will be extracted out of the sql light table 'FlightTimeCache'
        /// </summary>
        /// <param name="iSourceSystem">the source system where a ship would start</param>
        /// <param name="iDestinationSystem">the destination system, where the ship target (planet, comet, asteroid etc) is inside</param>
        /// <param name="iIdOfTarget">the target id of asterod</param>
        /// <param name="iSlowestShip">the slowest ship</param>
        /// <param name="iTargetType">Comet / Asteroid / Debris / Planet</param>
        /// <returns>Flight Time</returns>
        public static string GetFlightTime(string iSourceSystem, string iDestinationSystem, string iIdOfTarget, int iSlowestShip, Type iTargetType)
        {
            FlightTime ft = new FlightTime();

            string flytime = ft.GetFlightTimeFromCache(iSourceSystem, iDestinationSystem, iSlowestShip);

            if (flytime == "-1")
            {
                flytime = ft.GetFlightTimeFromWebRequest(iIdOfTarget, iSlowestShip, iTargetType);
                if (flytime != "00:00:00")
                    ft.AddFlightTimeToCache(iSourceSystem, iDestinationSystem, iSlowestShip, flytime);
            }

            return flytime;
        }
        

        private string GetFlightTimeFromCache(string iSourceSystem, string iDestinationSystem, int iSlowestShip)
        {
            string time = "-1";
            using (SqLight sqLight = new SqLight())
            {
                string sql = String.Format("Select FlightTime from FlightTimeCache where SourceSystemId = '{0}' and DestSystemId = '{1}' and ShipType = {2}", iSourceSystem, iDestinationSystem, iSlowestShip);
                using (SQLiteDataReader reader = sqLight.ExecuteQuery(sql))
                {
                    try
                    {
                        if (reader.Read())
                        {
                            time = reader.GetString(0);
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                    reader.Close();
                }
            }

            return time;
        }

        private void AddFlightTimeToCache(string iSourceSystem, string iDestinationSystem, int iSlowestShip, string iFlytime)
        {
            using (SqLight sqLight = new SqLight())
            {
                sqLight.ExecuteSql(String.Format("Insert Into FlightTimeCache (ID, SourceSystemId, DestSystemId, ShipType, FlightTime) VALUES ('{0}','{1}','{2}','{3}','{4}')", Guid.NewGuid(), iSourceSystem, iDestinationSystem, iSlowestShip, iFlytime));
            }
        }

        private string GetFlightTimeFromWebRequest(string iIdOfTarget, int iSlowestShip, Type iTargetType)
        {
            string url = "";
            if (iTargetType == typeof(Comet))
                url = String.Format("http://u1.imperion.de/fleetBase/route/1?ajaxRequest=1&planetId=c{0}&ships[{1}]=1", iIdOfTarget, iSlowestShip);
            else if (iTargetType == typeof(Debris))
                url = String.Format("http://u1.imperion.de/fleetBase/route/1?ajaxRequest=1&planetId=d{0}&ships[{1}]=1", iIdOfTarget, iSlowestShip);
            else if (iTargetType == typeof(Asteroid))
                url = String.Format("http://u1.imperion.de/fleetBase/route/1?ajaxRequest=1&planetId=a{0}&ships[{1}]=1", iIdOfTarget, iSlowestShip);
            else if (iTargetType == typeof(Planet))
                url = String.Format("http://u1.imperion.de/fleetBase/route/1?ajaxRequest=1&planetId={0}&ships[{1}]=1", iIdOfTarget, iSlowestShip);

            StringBuilder sb = Tools.DoWebRequestAndGetData(url);

            return ImperionParser.json_extractFlightTime(sb.ToString());
        }
    }
}
