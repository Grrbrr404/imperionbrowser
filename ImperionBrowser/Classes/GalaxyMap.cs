using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Jayrock.Json;

namespace ImperionBrowser
{
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
       
    }
}
