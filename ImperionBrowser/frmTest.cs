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
        
        /// <summary>
        /// Hotkey testing
        /// </summary>
        HotKey _hk;



        public frmTest()
        {
            InitializeComponent();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            //init hotkey wrapper
            _hk = new HotKey();
            _hk.OwnerForm = this;
            _hk.HotKeyPressed += new HotKey.HotKeyPressedEventHandler(_hk_HotKeyPressed);

            //init hotkeys
            _hk.AddHotKey(Keys.G, HotKey.MODKEY.MOD_CONTROL, "test");
            _hk.AddHotKey(Keys.G, HotKey.MODKEY.MOD_SHIFT, "test2");
            _hk.AddHotKey(Keys.G, HotKey.MODKEY.MOD_ALT, "test3");

        }

        private void _hk_HotKeyPressed(string HotKeyID)
        {
            if (HotKeyID == "test")
                MessageBox.Show("ctrl + g was pressed");
            else if (HotKeyID == "test2")
                MessageBox.Show("shift + g was pressed");
            else if (HotKeyID == "test3")
                MessageBox.Show("alt + g was pressed");
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

        private void frmTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            _hk.Dispose();
        }
    
    }
}
