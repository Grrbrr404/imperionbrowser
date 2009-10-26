using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Jayrock.Json;

namespace ImperionBrowser
{
    public enum SpaceShip
    {
        ssSonde,
        ssJaeger,
        ssSchlachtschiff,
        ssZerstoerer,
        ssSchwererKreuzer,
        ssPulsar,
        ssBomber,
        ssTankSchiff,
        ssKleinerTransporter,
        ssGrosserRecycler,
        ssRecycler,
        ssKolonieschiff

    }
    
    public class GalaxyMap
    {
        private List<GalaxySystem> _Systems = new List<GalaxySystem>();

        public List<GalaxySystem> Systems
        {
            get { return _Systems; }
            set { _Systems = value; }
        }

        public GalaxySystem this[string index]
        {
            get 
            {
                return _Systems.Find(delegate(GalaxySystem gs) { return gs._system_id == index; });
            }
            set { /* set the specified index to value here */ }
        }

        public void AddNewSystem(string iSystemId)
        {
            GalaxySystem gs = new GalaxySystem(iSystemId);
            _Systems.Add(gs);
        }

        public Comet FindComet(string iIdOfComet)
        {
            for (int i = 0; i < Systems.Count; i++)
            {
                for (int j = 0; j < Systems[i].Comets.Count; j++)
                {
                    if (Systems[i].Comets[j]._Id == iIdOfComet)
                        return Systems[i].Comets[j];
                }
            }

            return null; //Comet coudnt be found
        }

        public string GetFlightTime(string idOfTarget, Type targetType, SpaceShip slowestShip)
        {
            WebBrowser wb = new WebBrowser();
            string url = String.Empty;
            
            if (targetType == typeof(Comet))
                url = String.Format("http://u1.imperion.de/fleetBase/route/1?ajaxRequest=1&planetId=c{0}&ships[{1}]=1", idOfTarget, (int)slowestShip);
            else if (targetType == typeof(Debris))
                url = String.Format("http://u1.imperion.de/fleetBase/route/1?ajaxRequest=1&planetId=d{0}&ships[{1}]=1", idOfTarget, (int)slowestShip);
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = Tools.ReadCookiesAsCollection(new Uri(url), "cookies.txt");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StringBuilder sb = new StringBuilder();

            byte[] buf = new byte[8192];
            string tempString = null;
            int count = 0;

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
            
            return ImperionParser.json_extractFlightTime(sb.ToString());
        }
    }
}
