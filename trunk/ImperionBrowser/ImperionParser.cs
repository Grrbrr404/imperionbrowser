using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Jayrock;
using Jayrock.Json;
using System.IO;

namespace ImperionBrowser
{
    class ImperionParser
    {
        WebBrowser mBrowser;

        public ImperionParser(WebBrowser iBrowser)
        {
            mBrowser = iBrowser;
        }
        
        public static void TestMap()
        {
            StreamReader sr = new StreamReader("mapdata_stefan.txt");
            JsonTextReader jsonReader = new JsonTextReader(new StringReader(sr.ReadToEnd()));

            GalaxyMap galaxyMap = new GalaxyMap();
            Planet curPlanet;
            int res; // temporary variable for integer testing
            string text; // temp text variable;

            while (jsonReader.Read())
            {
                text = jsonReader.Text;
                if (jsonReader.TokenClass == JsonTokenClass.Member && text.Length == 6 && int.TryParse(text, out res)) //member is a new system
                {
                    galaxyMap.AddNewSystem(text);
                }

                if (text == "debris")
                {
                    json_ContinueToNextObject(jsonReader);
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

            int pcount = 0;
            int ccount = 0;
            for (int i = 0; i < galaxyMap.Systems.Count; i++)
            {
                pcount += galaxyMap.Systems[i].Planets.Count;
                ccount += galaxyMap.Systems[i].Comets.Count;
            }

            MessageBox.Show(String.Format("Es wurden {0} Systeme durchsucht: \r Es wurden {1} Planeten und {2} Kometen gefunden", galaxyMap.Systems.Count, pcount, ccount));
        }

        private static void json_AddCometsToSystem(JsonTextReader jsonReader, GalaxySystem galaxySystem)
        {
            JsonTokenClass tc = jsonReader.TokenClass;
            Comet comet;
            string text;

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
            while (tc != JsonTokenClass.EndObject)
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

        
        public void AddCometSearchButton()
        {
            HtmlElement GalaxyMap = mBrowser.Document.GetElementById("mapContent");
            Button aBtn = new Button();
            mBrowser.Controls.Add(aBtn);
            aBtn.Location = GalaxyMap.ScrollRectangle.Location;
        }

        public void GetCometsInMap()
        {
            string searchStr = "mapData = JSON.decode('";
            int posStart = mBrowser.DocumentText.LastIndexOf(searchStr) + searchStr.Length;
            int posEnd = mBrowser.DocumentText.IndexOf("');", posStart);

            StringBuilder jsonData = new StringBuilder(mBrowser.DocumentText.Substring(posStart, posEnd - posStart));
            GalaxyMap galaxyMap = json_parseMap(jsonData);

            int pcount = 0;
            int ccount = 0;
            for (int i = 0; i < galaxyMap.Systems.Count; i++)
            {
                pcount += galaxyMap.Systems[i].Planets.Count;
                ccount += galaxyMap.Systems[i].Comets.Count;
            }
            MessageBox.Show(String.Format("Es wurden {0} Systeme durchsucht: \r Es wurden {1} Planeten und {2} Kometen gefunden", galaxyMap.Systems.Count, pcount, ccount));
        }

        private GalaxyMap json_parseMap(StringBuilder jsonData)
        {
            JsonTextReader jsonReader = new JsonTextReader(new StringReader(jsonData.ToString()));
            GalaxyMap galaxyMap = new GalaxyMap();
            Planet curPlanet;
            int res; // temporary variable for integer testing
            string text; // temp text variable;

            
            while (jsonReader.Read())
            {
                text = jsonReader.Text;
                if (jsonReader.TokenClass == JsonTokenClass.Member && text.Length == 6 && int.TryParse(text, out res)) //member is a new system
                {
                    galaxyMap.AddNewSystem(text);
                }

                if (text == "debris")
                {
                    json_ContinueToNextObject(jsonReader);
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
        
    }
}
