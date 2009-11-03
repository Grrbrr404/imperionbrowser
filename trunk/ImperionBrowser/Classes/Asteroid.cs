using System;
using System.Collections.Generic;
using System.Text;

namespace ImperionBrowser
{
    public class Asteroid
    {
        public string _id;
        public string _system_id;
        public string _user_id;
        public string _planet_id;
        public string _arrival;
        public string _disappearance;
        private Resources _resources = new Resources();

        public Resources Resources
        {
            get { return _resources; }
        }
    }
}
