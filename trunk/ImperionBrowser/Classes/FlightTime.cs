using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using FirebirdSql.Data.FirebirdClient;

namespace ImperionBrowser
{
    class FlightTime
    {
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
            using (Firebird fb = new Firebird())
            {
                string sql = String.Format("Select FlightTime from FlightTimeCache where SourceSystemId = '{0}' and DestSystemId = '{1}' and ShipType = {2}", iSourceSystem, iDestinationSystem, iSlowestShip);
                using (FbDataReader reader = fb.ExecuteQuery(sql))
                {
                    try
                    {
                        if (reader.Read())
                        {
                                time = reader.GetString(0);
                        }
                    }
                    catch(FbException e)
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
            using (Firebird fb = new Firebird())
            {
                fb.executeSql(String.Format("Insert Into FlightTimeCache (ID, SourceSystemId, DestSystemId, ShipType, FlightTime) VALUES ('{0}','{1}','{2}','{3}','{4}')", Guid.NewGuid(), iSourceSystem, iDestinationSystem, iSlowestShip, iFlytime));
            }
        }

        private string GetFlightTimeFromWebRequest(string iIdOfTarget, int iSlowestShip, Type iTargetType)
        {
            string url = "";
            if (iTargetType == typeof(Comet))
                url = String.Format("http://u1.imperion.de/fleetBase/route/1?ajaxRequest=1&planetId=c{0}&ships[{1}]=1", iIdOfTarget, iSlowestShip);
            else if (iTargetType == typeof(Debris))
                url = String.Format("http://u1.imperion.de/fleetBase/route/1?ajaxRequest=1&planetId=d{0}&ships[{1}]=1", iIdOfTarget, iSlowestShip);
            else if (iTargetType == typeof(Planet))
                url = String.Format("http://u1.imperion.de/fleetBase/route/1?ajaxRequest=1&planetId={0}&ships[{1}]=1", iIdOfTarget, iSlowestShip);


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = Tools.ReadCookiesAsCollection(new Uri(url), "cookies.txt");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StringBuilder sb = new StringBuilder();

            byte[] buf = new byte[8192];
            string tempString = null;
            int count = 0;

            try
            {
                do
                {
                    count = resStream.Read(buf, 0, buf.Length);
                    if (count != 0)
                    {
                        tempString = Encoding.ASCII.GetString(buf, 0, count);
                        sb.Append(tempString);
                    }
                }
                while (count > 0); // any more data to read?
            }
            finally
            {
                response.Close();
                resStream.Close();
                resStream.Dispose();
            }

            return ImperionParser.json_extractFlightTime(sb.ToString());
        }
    }
}
