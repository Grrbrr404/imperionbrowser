using System;
using System.Collections.Generic;
using System.Text;

namespace ImperionBrowser
{
    public class Planet
    {
        public string _planet_id;
        public string _player_name;
        public string _alliance_name;
        public string _alliance_id;
        public string _user_id;
        public string _system_id;
        public string _planet_type_id;
        public string _kind_id;
        public string _planet_name;
        public string _inhabitants;
        public string _alliance_status;

        private Climate _climate = new Climate();
        private Resources _resources = new Resources();
        private Reports _reports = new Reports();

        public Resources Resources
        {
            get { return _resources; }
            set { _resources = value; }
        }

        public Reports Reports
        {
            get { return _reports; }
            set { _reports = value; }
        }
        
        public Climate Climate
        {
            get { return _climate; }
            set { _climate = value; }
        }

    }

    public class Climate
    {
        public int _solar = 0;
        public int _wind = 0;
        public int _water = 0;
        public int _thermal = 0;

        public Climate() { }
    }

    public class Resources
    {
        public string _metalFields = String.Empty;
        public string _crystalFields = String.Empty;
        public string _deutriFields = String.Empty;
    }

    public class Reports 
    { 
        public Reports() {}
    }
}        
