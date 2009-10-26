using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImperionBrowser
{
    public partial class frmRenameTab : Form
    {
        public frmRenameTab()
        {
            InitializeComponent();
        }

        public string TabName
        {
            set { edtTabName.Text = value; }
            get { return edtTabName.Text; }
        }
    }
}
