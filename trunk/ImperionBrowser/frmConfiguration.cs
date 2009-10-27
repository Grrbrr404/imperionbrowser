using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Google.GData.Calendar;

namespace ImperionBrowser
{
    public partial class frmConfiguration : Form
    {
        public frmConfiguration()
        {
            InitializeComponent();
        }

        private void btnSearchCalendar_Click(object sender, EventArgs e)
        {
            if (txtbxGoogleAccountName.Text == "" || txtbxGooglePwd.Text == "")
            {
                MessageBox.Show("Bitte erst Benutzernamen und Kennwort eingeben.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            GoogleSms googleSms = new GoogleSms(txtbxGoogleAccountName.Text, txtbxGooglePwd.Text);
            googleSms.AddCalendarsToComboBox(cmbxGoogleCalendar);
        }

        private void txtbx_TextChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = false;
            SaveSettings();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.gAccount = txtbxGoogleAccountName.Text;
            Properties.Settings.Default.gPwd = txtbxGooglePwd.Text;
            
            if (cmbxGoogleCalendar.SelectedItem is CalendarEntry)
                Properties.Settings.Default.gPostUrl = GoogleSms.buildCalendarUri((CalendarEntry)cmbxGoogleCalendar.SelectedItem);
            
            Properties.Settings.Default.Save();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            txtbxGoogleAccountName.Text = Properties.Settings.Default.gAccount;
            txtbxGooglePwd.Text = Properties.Settings.Default.gPwd;
        }

        private void btnSendTest_Click(object sender, EventArgs e)
        {
            GoogleSms gSms = new GoogleSms(Properties.Settings.Default.gAccount, Properties.Settings.Default.gPwd);
            gSms.SendSms(Properties.Settings.Default.gPostUrl, "Final test via config builder and i will use more text here to test this stuff, wuwuwuwu", "u1 Galaxy 3");
        }

    }
}
