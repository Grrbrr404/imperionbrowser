using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Google.GData.Calendar;
using Google.GData.Extensions;
using Google.GData.Client;
using System.IO;

namespace ImperionBrowser
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tools.SaveCookies(webBrowser1, "cookies.txt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GoogleSms googleSms = new GoogleSms("enteruserhere", "enterpwdhere");
            googleSms.AddCalendarsToComboBox(comboBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GoogleSms googleSms = new GoogleSms("enteruserhere", "enterpwdhere");
            CalendarEntry targetCal = (CalendarEntry)comboBox1.SelectedItem;
            googleSms.SendSms(GoogleSms.buildCalendarUri(targetCal), "Imperion Test", "Galaxy U1");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqLight sq = new SqLight();
            
            sq.ExecuteSql("insert into FlightTimeCache (ID) values('"+ Guid.NewGuid() + "')");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ImperionParser ip = new ImperionParser(new WebBrowser());

            GalaxyMap gm = ip.TestMap(true);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ImperionParser ip = new ImperionParser(new WebBrowser());
            GalaxyMap gm = ip.TestMap(false);
            
            frmRaidTargets raidTargets = new frmRaidTargets(gm, new frmMain());
            raidTargets.Show();
        }
    
    }
}
