namespace ImperionBrowser
{
    partial class frmPlanetGrowing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Heute", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("Gestern", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("Vor 2 Tagen", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("Vor 3 Tagen", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup12 = new System.Windows.Forms.ListViewGroup("Vor 4 Tagen", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup13 = new System.Windows.Forms.ListViewGroup("Vor 5 Tagen", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup14 = new System.Windows.Forms.ListViewGroup("Vor 6 Tagen", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Grrbrr",
            "~ID~",
            "Planet 1",
            "Eis",
            "800"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "Grrbrr",
            "~ID~",
            "Planet 1",
            "Eis",
            "1000"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanetGrowing));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.DataListView = new System.Windows.Forms.ListView();
            this.colOwner = new System.Windows.Forms.ColumnHeader();
            this.ColAlly = new System.Windows.Forms.ColumnHeader();
            this.colPlanet = new System.Windows.Forms.ColumnHeader();
            this.colPlanetType = new System.Windows.Forms.ColumnHeader();
            this.colPlanetPoints = new System.Windows.Forms.ColumnHeader();
            this.colFlightTime = new System.Windows.Forms.ColumnHeader();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnUserFilter = new System.Windows.Forms.ToolStripButton();
            this.btnResetView = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Panel1Collapsed = true;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(769, 417);
            this.splitContainer1.SplitterDistance = 56;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pnlProgress);
            this.splitContainer2.Panel1.Controls.Add(this.DataListView);
            this.splitContainer2.Panel1MinSize = 34;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip);
            this.splitContainer2.Size = new System.Drawing.Size(769, 417);
            this.splitContainer2.SplitterDistance = 740;
            this.splitContainer2.TabIndex = 0;
            // 
            // pnlProgress
            // 
            this.pnlProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProgress.Controls.Add(this.lblProgress);
            this.pnlProgress.Controls.Add(this.progressBar);
            this.pnlProgress.Location = new System.Drawing.Point(0, 140);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(740, 44);
            this.pnlProgress.TabIndex = 3;
            this.pnlProgress.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProgress.Location = new System.Drawing.Point(0, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(740, 21);
            this.lblProgress.TabIndex = 1;
            this.lblProgress.Text = "Daten werden vorbereitet, bitte habe einen Moment geduld";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 21);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(740, 23);
            this.progressBar.TabIndex = 0;
            // 
            // DataListView
            // 
            this.DataListView.AllowColumnReorder = true;
            this.DataListView.AutoArrange = false;
            this.DataListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOwner,
            this.ColAlly,
            this.colPlanet,
            this.colPlanetType,
            this.colPlanetPoints,
            this.colFlightTime});
            this.DataListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataListView.FullRowSelect = true;
            listViewGroup8.Header = "Heute";
            listViewGroup8.Name = "Today";
            listViewGroup9.Header = "Gestern";
            listViewGroup9.Name = "Yesterday";
            listViewGroup10.Header = "Vor 2 Tagen";
            listViewGroup10.Name = "TwoDaysAgo";
            listViewGroup11.Header = "Vor 3 Tagen";
            listViewGroup11.Name = "ThreeDaysAgo";
            listViewGroup12.Header = "Vor 4 Tagen";
            listViewGroup12.Name = "FourDaysAgo";
            listViewGroup13.Header = "Vor 5 Tagen";
            listViewGroup13.Name = "FiveDaysAgo";
            listViewGroup14.Header = "Vor 6 Tagen";
            listViewGroup14.Name = "SixDaysAgo";
            this.DataListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup8,
            listViewGroup9,
            listViewGroup10,
            listViewGroup11,
            listViewGroup12,
            listViewGroup13,
            listViewGroup14});
            listViewItem3.Group = listViewGroup9;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.Group = listViewGroup8;
            listViewItem4.StateImageIndex = 0;
            this.DataListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4});
            this.DataListView.Location = new System.Drawing.Point(0, 0);
            this.DataListView.Name = "DataListView";
            this.DataListView.Size = new System.Drawing.Size(740, 417);
            this.DataListView.TabIndex = 8;
            this.DataListView.UseCompatibleStateImageBehavior = false;
            this.DataListView.View = System.Windows.Forms.View.Details;
            this.DataListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataListView_MouseDoubleClick);
            this.DataListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.DataListView_ColumnClick);
            // 
            // colOwner
            // 
            this.colOwner.Text = "Besitzer";
            this.colOwner.Width = 95;
            // 
            // ColAlly
            // 
            this.ColAlly.Text = "Allianz";
            this.ColAlly.Width = 109;
            // 
            // colPlanet
            // 
            this.colPlanet.Text = "Planet";
            this.colPlanet.Width = 146;
            // 
            // colPlanetType
            // 
            this.colPlanetType.Text = "Typ";
            this.colPlanetType.Width = 55;
            // 
            // colPlanetPoints
            // 
            this.colPlanetPoints.Text = "Punkte";
            this.colPlanetPoints.Width = 50;
            // 
            // colFlightTime
            // 
            this.colFlightTime.Text = "Entfernung";
            this.colFlightTime.Width = 208;
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnResetView,
            this.btnUserFilter,
            this.toolStripButton3,
            this.toolStripSeparator2});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(25, 417);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnUserFilter
            // 
            this.btnUserFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUserFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnUserFilter.Image")));
            this.btnUserFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUserFilter.Name = "btnUserFilter";
            this.btnUserFilter.Size = new System.Drawing.Size(23, 20);
            this.btnUserFilter.Text = "Zeige nur Planeten von ausgewählten Benutzern";
            this.btnUserFilter.Click += new System.EventHandler(this.btnUserFilter_Click);
            // 
            // btnResetView
            // 
            this.btnResetView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnResetView.Image = ((System.Drawing.Image)(resources.GetObject("btnResetView.Image")));
            this.btnResetView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResetView.Name = "btnResetView";
            this.btnResetView.Size = new System.Drawing.Size(23, 20);
            this.btnResetView.Text = "toolStripButton2";
            this.btnResetView.ToolTipText = "Ansicht neu laden";
            this.btnResetView.Click += new System.EventHandler(this.btnResetView_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(23, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(23, 6);
            // 
            // frmPlanetGrowing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 417);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "frmPlanetGrowing";
            this.Text = "Planeten wachstum";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.frmPlanetGrowing_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPlanetGrowing_FormClosing);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.pnlProgress.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListView DataListView;
        private System.Windows.Forms.ColumnHeader colPlanet;
        private System.Windows.Forms.ColumnHeader colOwner;
        private System.Windows.Forms.ColumnHeader colPlanetType;
        private System.Windows.Forms.ColumnHeader colPlanetPoints;
        private System.Windows.Forms.ColumnHeader colFlightTime;
        private System.Windows.Forms.ColumnHeader ColAlly;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnUserFilter;
        private System.Windows.Forms.ToolStripButton btnResetView;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}