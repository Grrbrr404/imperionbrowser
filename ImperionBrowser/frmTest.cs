using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            ImperionParser ip = new ImperionParser(new WebBrowser());
            ip.TestMap();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Tools.SaveCookies(webBrowser1, "cookies.txt");
           
        }

    
    }
}
