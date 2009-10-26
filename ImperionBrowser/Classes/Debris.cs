using System;
using System.Collections.Generic;
using System.Text;

namespace ImperionBrowser
{
    public class Debris
    {
        public string _planetId = String.Empty;
        private Resources _resource = new Resources();

        public Debris()
        {
            Resource._deutriFields = "0"; // A Debris never have deutrium    
        }

        public Resources Resource
        {
            get { return _resource; }
        }

    }
}
