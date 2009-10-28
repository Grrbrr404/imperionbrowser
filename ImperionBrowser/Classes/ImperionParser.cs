using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Jayrock;
using System.IO;
using Jayrock.Json;

namespace ImperionBrowser
{
    class ImperionParser
    {
        private WebBrowser mBrowser;
        private int lengthOfSystem;

        public ImperionParser(WebBrowser iBrowser)
        {
            mBrowser = iBrowser;
        }
        
        public void TestMap()
        {
            StreamReader sr = new StreamReader("mapdata_stefan.txt");
            StringBuilder sb = new StringBuilder(sr.ReadToEnd());

            GalaxyMap galaxyMap = json_parseMap(sb);

            frmRecyclerTargets rt = new frmRecyclerTargets(galaxyMap, null);
            rt.Show();

            /*int pcount = 0;
            int ccount = 0;
            int dcount = 0;

            for (int i = 0; i < galaxyMap.Systems.Count; i++)
            {
                pcount += galaxyMap.Systems[i].Planets.Count;
                ccount += galaxyMap.Systems[i].Comets.Count;
                dcount += galaxyMap.Systems[i].Debris.Count;
            }

            MessageBox.Show(String.Format("Es wurden {0} Systeme durchsucht: \r Es wurden {1} Planeten, {2} Kometen und {3} Trümmerfelder gefunden", galaxyMap.Systems.Count, pcount, ccount, dcount));*/
        }

        private void json_AddDebrisToSystem(JsonTextReader jsonReader, GalaxySystem galaxySystem)
        {
            string text = jsonReader.Text;
            jsonReader.Read();
            Debris curDepris;
            
            while (jsonReader.Read() && jsonReader.TokenClass == JsonTokenClass.Member && jsonReader.Text.Length == lengthOfSystem + 2)
            {
                curDepris = new Debris();
                jsonReader.Read(); //Skip obj begin
                jsonReader.Read();
                curDepris._planetId = json_readMemberIntoString(jsonReader);
                curDepris.Resource._metalFields = json_readMemberIntoString(jsonReader);
                curDepris.Resource._crystalFields = json_readMemberIntoString(jsonReader);
                galaxySystem.Debris.Add(curDepris);
            }
        }

        private static void json_AddCometsToSystem(JsonTextReader jsonReader, GalaxySystem galaxySystem)
        {
            JsonTokenClass tc = jsonReader.TokenClass;
            Comet comet;

            //continue reader till array begins
            while (tc != JsonTokenClass.Array)
            {
                jsonReader.Read();
                tc = jsonReader.TokenClass;
            }

            while (tc != JsonTokenClass.EndArray)
            {

                try
                {
                    jsonReader.Read();
                    if (jsonReader.TokenClass != JsonTokenClass.Member)
                        jsonReader.Read();

                    comet = new Comet();
                    comet._Id = json_readMemberIntoString(jsonReader);
                    comet._styemId = galaxySystem._system_id;
                    comet.Resources._metalFields = json_readMemberIntoNumber(jsonReader).ToString();
                    comet.Resources._crystalFields = json_readMemberIntoNumber(jsonReader).ToString();
                    comet.Resources._deutriFields = json_readMemberIntoNumber(jsonReader).ToString();
                    
                    comet._Name = json_readMemberIntoString(jsonReader);
                    comet._highlight = json_readMemberIntoNumber(jsonReader) == 1;
                    galaxySystem.Comets.Add(comet);

                    jsonReader.Read();

                    tc = jsonReader.TokenClass;
                }
                catch
                {
                    MessageBox.Show("error:" + jsonReader.Text + " | line: " + jsonReader.LineNumber + " | pos: " + jsonReader.LinePosition);
                }
            }
            
        }

        private static Planet json_ParsePlanet(JsonTextReader jsonReader)
        {
            Planet curPlanet = new Planet();
            // read whole planet
            try
            {
                curPlanet._planet_id = json_readMemberIntoString(jsonReader);
                curPlanet._player_name = json_readMemberIntoString(jsonReader);
                curPlanet._alliance_name = json_readMemberIntoString(jsonReader);
                curPlanet._alliance_id = json_readMemberIntoString(jsonReader);
                curPlanet._user_id = json_readMemberIntoString(jsonReader);
                curPlanet._system_id = json_readMemberIntoString(jsonReader);
                curPlanet._planet_type_id = json_readMemberIntoString(jsonReader);
                curPlanet._kind_id = json_readMemberIntoString(jsonReader);
                curPlanet._planet_name = json_readMemberIntoString(jsonReader);
                curPlanet._inhabitants = json_readMemberIntoString(jsonReader);
                curPlanet._alliance_status = json_readMemberIntoString(jsonReader);

                if (jsonReader.ReadMember() == "climate" && jsonReader.TokenClass != JsonTokenClass.Null)
                {
                    try
                    {
                        jsonReader.Read(); // skip object begin of climate object
                        curPlanet.Climate._solar = json_readMemberIntoNumber(jsonReader);
                        curPlanet.Climate._wind = json_readMemberIntoNumber(jsonReader);
                        curPlanet.Climate._water = json_readMemberIntoNumber(jsonReader);
                        curPlanet.Climate._thermal = json_readMemberIntoNumber(jsonReader);
                        jsonReader.Read(); //skip object end of cliamte object
                    }
                    catch
                    {
                        MessageBox.Show("error:" + jsonReader.Text + " | line: " + jsonReader.LineNumber + " | pos: " + jsonReader.LinePosition);
                    }
                }

                if (jsonReader.ReadMember() == "resources" && jsonReader.TokenClass != JsonTokenClass.Null)
                {
                    try
                    {
                        jsonReader.Read(); // skip object begin of resource object
                        curPlanet.Resources._metalFields = json_readMemberIntoString(jsonReader);
                        curPlanet.Resources._crystalFields = json_readMemberIntoString(jsonReader);
                        curPlanet.Resources._deutriFields = json_readMemberIntoString(jsonReader);
                        jsonReader.Read(); // skip object end of resource object
                    }
                    catch
                    {
                        MessageBox.Show("error:" + jsonReader.Text + " | line: " + jsonReader.LineNumber + " | pos: " + jsonReader.LinePosition);
                    }
                }
            }
            catch
            {
                MessageBox.Show("error:" + jsonReader.Text + " | line: " + jsonReader.LineNumber + " | pos: " + jsonReader.LinePosition);
            }

            return curPlanet;

        }

        private static void json_ContinueToNextObject(JsonTextReader jsonReader)
        {
            int depth = jsonReader.Depth;
            string text;
            JsonTokenClass tc = jsonReader.TokenClass;
            while (tc != JsonTokenClass.EndObject && jsonReader.Depth != depth)
            {
                text = jsonReader.Text;
                jsonReader.Read();
                tc = jsonReader.TokenClass;
            }

            
        }

        private static string json_readMemberIntoString(JsonTextReader jsonReader)
        {
            jsonReader.ReadMember();
            if (jsonReader.TokenClass != JsonTokenClass.Null)
                return jsonReader.ReadString();
            else
                jsonReader.Read();

            return String.Empty;
        }

        private static int json_readMemberIntoNumber(JsonTextReader jsonReader)
        {
            try
            {
                jsonReader.ReadMember();
                if (jsonReader.TokenClass != JsonTokenClass.Null)
                    return jsonReader.ReadNumber().ToInt32();
                else
                    jsonReader.Read();
                
                return 0;
            }
            catch
            {
                jsonReader.Read();
                return 0;
            }
        }

        public void ShowRecyclerTargets(frmMain frmMain)
        {
            string searchStr = "mapData = JSON.decode('";
            int posStart = mBrowser.DocumentText.LastIndexOf(searchStr) + searchStr.Length;
            int posEnd = mBrowser.DocumentText.IndexOf("');", posStart);

            StringBuilder jsonData = new StringBuilder(mBrowser.DocumentText.Substring(posStart, posEnd - posStart));
            GalaxyMap galaxyMap = json_parseMap(jsonData);

            frmRecyclerTargets rt = new frmRecyclerTargets(galaxyMap, frmMain);
            rt.Show();
           
        }

        private GalaxyMap json_parseMap(StringBuilder jsonData)
        {
            JsonTextReader jsonReader = new JsonTextReader(new StringReader(jsonData.ToString()));
            GalaxyMap galaxyMap = new GalaxyMap();
            Planet curPlanet;
            int res; // temporary variable for integer testing
            string text; // temp text variable;
            lengthOfSystem = 0;
            while (jsonReader.Read())
            {
                text = jsonReader.Text;
                
                if (jsonReader.Depth == 1 && jsonReader.TokenClass == JsonTokenClass.Member && int.TryParse(text, out res)) //found new system, set length of system id
                {
                    lengthOfSystem = text.Length;
                }

                if (jsonReader.TokenClass == JsonTokenClass.Member && text.Length == lengthOfSystem && int.TryParse(text, out res)) //member is a new system
                {
                    galaxyMap.AddNewSystem(text);
                }

                if (text == "debris")
                {
                    json_AddDebrisToSystem(jsonReader, galaxyMap.Systems[galaxyMap.Systems.Count - 1]); //Add Debris to last found system
                }

                if (text == "comets")
                {
                    json_AddCometsToSystem(jsonReader, galaxyMap.Systems[galaxyMap.Systems.Count - 1]); //Add comets as Comet objects to the last found system
                }

                if (text == "planet_id")
                {
                    curPlanet = json_ParsePlanet(jsonReader);
                    galaxyMap[curPlanet._system_id].Planets.Add(curPlanet);
                }

            }

            return galaxyMap;
        }


        public static string json_extractFlightTime(string jsonData)
        {
            JsonTextReader jsonReader = new JsonTextReader(new StringReader(jsonData));

            while (jsonReader.Read())
            {
                if (jsonReader.Text == "duration")
                {
                    string text = json_readMemberIntoString(jsonReader);
                    return text;
                }
            }

            return "00:00:00";
        }

        public static string ParseFleetBaseAndGetResourceSum(HtmlDocument htmlDocument)
        {
            HtmlElement divFleetBase = htmlDocument.GetElementById("fleetBase");
            HtmlElement divFleetSlots = divFleetBase.Children[0];
            int amountOfReturningFleet = Convert.ToInt32(divFleetBase.GetElementsByTagName("span")[0].InnerText);

            if (amountOfReturningFleet == 0)
                return "Es kommen momentan keine Resourcen zurück";

            HtmlElementCollection tables = divFleetBase.GetElementsByTagName("table");

            int sumMetal = 0;
            int sumCrystal = 0;
            int sumDeut = 0;
            HtmlElement listResource;

            for (int i = 0; i < amountOfReturningFleet; i++)
            {
                listResource = tables[i].GetElementsByTagName("tr")[6].GetElementsByTagName("ul")[0];

                sumMetal += Convert.ToInt32(listResource.Children[0].InnerText);
                sumCrystal += Convert.ToInt32(listResource.Children[1].InnerText);
                sumDeut += Convert.ToInt32(listResource.Children[2].InnerText);
            }
            
            return String.Format("Es kommen insgesamt {0} Metall, {1} Kristall und {2} Deterium", sumMetal, sumCrystal, sumDeut);
        }
    }
}
