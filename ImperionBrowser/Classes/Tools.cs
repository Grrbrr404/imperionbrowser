using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Drawing;

namespace ImperionBrowser
{
    class Tools
    {
        public static void SaveCookies(WebBrowser wb, string iDestinationPath)
        {
            StreamWriter sw = new StreamWriter(iDestinationPath,false);

            try
            {
                char[] sep = { ';' };
                string[] elements = wb.Document.Cookie.Split(sep);

                foreach (string s in elements)
                    sw.WriteLine(s);
            }
            catch { }

            sw.Close();
            sw.Dispose();
        }

        public static CookieContainer ReadCookiesAsCollection(Uri iUri, string iSourcePath)
        {
            StreamReader sr = new StreamReader(iSourcePath);
            CookieContainer cc = new CookieContainer();
            
            Cookie c;
            char[] sep = {'='};
            string[] elements;
            string curLine;
            try
            {
                while (!sr.EndOfStream)
                {
                    curLine = sr.ReadLine();
                    if (curLine != String.Empty)
                    {
                        elements = curLine.Split(sep);
                        c = new Cookie(elements[0], elements[1]);
                        cc.Add(iUri, c);
                    }
                }
            }
            catch {}

            sr.Close();
            sr.Dispose();

            return cc;
        }

        public static int[] GetInputIds(RaceTypes race)
        {
            int[] inputIds = new int[12];
            if (race == RaceTypes.rtTerran || race == RaceTypes.rtTitan)
            {
                inputIds[0] = (int)TerranSpaceShip.ssSonde;
                inputIds[1] = (int)TerranSpaceShip.ssJaeger;
                inputIds[2] = (int)TerranSpaceShip.ssSchlachtschiff;
                inputIds[3] = (int)TerranSpaceShip.ssZerstoerer;
                inputIds[4] = (int)TerranSpaceShip.ssSchwererKreuzer;
                inputIds[5] = (int)TerranSpaceShip.ssPulsar;
                inputIds[6] = (int)TerranSpaceShip.ssBomber;
                inputIds[7] = (int)TerranSpaceShip.ssTankSchiff;
                inputIds[8] = (int)TerranSpaceShip.ssKleinerTransporter;
                inputIds[9] = (int)TerranSpaceShip.ssGrosserRecycler;
                inputIds[10] = (int)TerranSpaceShip.ssRecycler;
                inputIds[11] = (int)TerranSpaceShip.ssKolonieschiff;
            }
            else if (race == RaceTypes.rtXen)
            {
                inputIds[0] = (int)XenSpaceShip.xsSonde;
                inputIds[1] = (int)XenSpaceShip.xsJaeger;
                inputIds[2] = (int)XenSpaceShip.xsSchlachtschiff;
                inputIds[3] = (int)XenSpaceShip.xsZerstoerer;
                inputIds[4] = (int)XenSpaceShip.xsSchwererKreuzer;
                inputIds[5] = (int)XenSpaceShip.xsPulsar;
                inputIds[6] = (int)XenSpaceShip.xsBomber;
                inputIds[7] = (int)XenSpaceShip.xsTankSchiff;
                inputIds[8] = (int)XenSpaceShip.xsKleinerTransporter;
                inputIds[9] = (int)XenSpaceShip.xsGrosserRecycler;
                inputIds[10] = (int)XenSpaceShip.xsRecycler;
                inputIds[11] = (int)XenSpaceShip.xsKolonieschiff;
            }

            return inputIds;
        }

        /// <summary>
        /// Returns an Image Object based on the type of the planet
        /// </summary>
        /// <param name="planet"></param>
        /// <returns></returns>
        public static Image GetImageOfPlanet(Planet iSourcePlanet)
        {
            Image result;
            switch (iSourcePlanet.Type)
            {
                case PlanetType.ptDesert:
                    result = Image.FromFile("Data/image/desert.gif");
                    break;
                case PlanetType.ptEarth:
                    result = Image.FromFile("Data/image/earth.gif");
                    break;
                case PlanetType.ptGas:
                    result = Image.FromFile("Data/image/gas.gif");
                    break;
                case PlanetType.ptIce:
                    result = Image.FromFile("Data/image/ice.gif");
                    break;
                case PlanetType.ptVulcan:
                    result = Image.FromFile("Data/image/vulcan.gif");
                    break;
                case PlanetType.ptWater:
                    result = Image.FromFile("Data/image/water.gif");
                    break;
                default:
                    result = Image.FromFile("Data/image/desert.gif");
                    break;
            }

            return result;
        }

        public static StringBuilder DoWebRequestAndGetData(string url)
        {
            StringBuilder sb = new StringBuilder();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = Tools.ReadCookiesAsCollection(new Uri(url), "cookies.txt");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();

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

            return sb;
        }

        public static bool UniverseMapIsLoaded(WebBrowser browser)
        {
            if (browser.ReadyState != WebBrowserReadyState.Complete)
            {
                MessageBox.Show("Das Universum ist noch nicht komplett geladen, bitte Vorgang später wiederholen", "Universum noch nicht bereit...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!browser.Url.ToString().Contains("map"))
            {
                DialogResult res = MessageBox.Show("Für diese Funktion muss zur Universumskarte navigiert werden. Navigation durchführen?", "Navigation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    browser.Navigate("http://u1.imperion.de/map/index");

                return false;
            }

            return true;
        }
    }
}
