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
        private List<Report> _reports = new List<Report>();
        
        public Resources Resources
        {
            get { return _resources; }
            set { _resources = value; }
        }

        public List<Report> Reports
        {
            get { return _reports; }
        }
        
        public Climate Climate
        {
            get { return _climate; }
            set { _climate = value; }
        }

        /// <summary>
        /// Gets the Report with highest _time. if there is no report, it will return null
        /// </summary>
        /// <returns></returns>
        public Report GetLatestReport()
        {
            Report result = new Report();

            for (int i = 0; i < Reports.Count; i++)
            {
                if (Reports[i]._time > result._time)
                    result = Reports[i];
            }

            return result;
        }

        public string GetLatestReportTimeAsString(string iDateTimeFormatString)
        {
            DateTime dt = GetLatestReport()._time;

            if (dt == DateTime.MinValue)
                return "-";
            else
                return dt.ToString(iDateTimeFormatString);
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

    public class Report
    {
        public DateTime _time;
        public string _planet_id_target;
        public string _header_id;
        public string _type;

        public Report()
        {
            _time = new DateTime();
            _time = DateTime.MinValue;
        }
    }
}        
