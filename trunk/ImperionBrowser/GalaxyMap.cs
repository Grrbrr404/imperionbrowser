using System;
using System.Collections.Generic;
using System.Text;

namespace ImperionBrowser
{
    class GalaxyMap
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

    }
}
