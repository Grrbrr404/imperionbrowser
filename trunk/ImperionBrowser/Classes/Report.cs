using System;
using System.Collections.Generic;
using System.Text;

namespace ImperionBrowser
{
    public class Report
    {
        public DateTime _time;
        public string _planet_id_target;
        public string _header_id;
        private MissionTypes _type;

        public Report()
        {
            _time = new DateTime();
            _time = DateTime.MinValue;
        }

        public MissionTypes Type
        {
            get { return _type; }
        }

        public void SetType(string iType)
        {
            try
            {
                _type = (MissionTypes)int.Parse(iType);
            }
            catch
            {
                throw new Exception("No valid MissionType: " + iType);
            }
        }
    }
}
