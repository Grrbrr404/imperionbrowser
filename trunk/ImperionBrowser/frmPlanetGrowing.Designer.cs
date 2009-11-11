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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Heute", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Gestern", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Grrbrr",
            "Planet 1",
            "Eis",
            "800"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Grrbrr",
            "Planet 1",
            "Eis",
            "1000"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanetGrowing));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.DataListView = new System.Windows.Forms.ListView();
            this.colOwner = new System.Windows.Forms.ColumnHeader();
            this.colPlanet = new System.Windows.Forms.ColumnHeader();
            this.colPlanetType = new System.Windows.Forms.ColumnHeader();
            this.colPlanetPoints = new System.Windows.Forms.ColumnHeader();
            this.colFlightTime = new System.Windows.Forms.ColumnHeader();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
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
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
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
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip);
            this.splitContainer2.Size = new System.Drawing.Size(769, 357);
            this.splitContainer2.SplitterDistance = 740;
            this.splitContainer2.TabIndex = 0;
            // 
            // pnlProgress
            // 
            this.pnlProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProgress.Controls.Add(this.label2);
            this.pnlProgress.Controls.Add(this.progressBar);
            this.pnlProgress.Location = new System.Drawing.Point(0, 140);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(740, 44);
            this.pnlProgress.TabIndex = 3;
            this.pnlProgress.Visible = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(740, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Daten werden vorbereitet, bitte habe einen Moment geduld";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.DataListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOwner,
            this.colPlanet,
            this.colPlanetType,
            this.colPlanetPoints,
            this.colFlightTime});
            this.DataListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataListView.FullRowSelect = true;
            listViewGroup1.Header = "Heute";
            listViewGroup1.Name = "Heute";
            listViewGroup2.Header = "Gestern";
            listViewGroup2.Name = "Gestern";
            this.DataListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            listViewItem1.Group = listViewGroup2;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.Group = listViewGroup1;
            listViewItem2.StateImageIndex = 0;
            this.DataListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.DataListView.LabelEdit = true;
            this.DataListView.Location = new System.Drawing.Point(0, 0);
            this.DataListView.Name = "DataListView";
            this.DataListView.Size = new System.Drawing.Size(740, 357);
            this.DataListView.TabIndex = 8;
            this.DataListView.UseCompatibleStateImageBehavior = false;
            this.DataListView.View = System.Windows.Forms.View.Details;
            this.DataListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.DataListView_ColumnClick);
            // 
            // colOwner
            // 
            this.colOwner.Text = "Besitzer";
            this.colOwner.Width = 95;
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
            this.colPlanetPoints.Width = 114;
            // 
            // colFlightTime
            // 
            this.colFlightTime.Text = "Entfernung";
            this.colFlightTime.Width = 70;
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip.Location = new System.Drawing.Point(1, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(24, 357);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(21, 20);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(21, 20);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(21, 20);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // frmPlanetGrowing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 417);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmPlanetGrowing";
            this.Text = "Planeten wachstum";
            this.Load += new System.EventHandler(this.frmPlanetGrowing_Load);
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
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListView DataListView;
        private System.Windows.Forms.ColumnHeader colPlanet;
        private System.Windows.Forms.ColumnHeader colOwner;
        private System.Windows.Forms.ColumnHeader colPlanetType;
        private System.Windows.Forms.ColumnHeader colPlanetPoints;
        private System.Windows.Forms.ColumnHeader colFlightTime;
    }
}