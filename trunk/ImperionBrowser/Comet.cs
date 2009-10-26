using System;
using System.Collections.Generic;
using System.Text;

namespace ImperionBrowser
{
    public class Comet
    {
        public string _Id = String.Empty;
        public string _Name = String.Empty;
        public bool _highlight;

        private Resources _resources = new Resources();

        public Resources Resources
        {
            get { return _resources; }
        }

        public Comet() {}
    }
}
