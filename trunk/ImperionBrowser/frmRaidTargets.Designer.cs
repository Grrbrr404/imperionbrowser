namespace ImperionBrowser
{
    partial class frmRaidTargets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRaidTargets));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpbxFilter = new System.Windows.Forms.GroupBox();
            this.btnFilterNow = new System.Windows.Forms.Button();
            this.chckbxWaterFilter = new System.Windows.Forms.CheckBox();
            this.chckbxVulcanFilter = new System.Windows.Forms.CheckBox();
            this.chckbxIceFilter = new System.Windows.Forms.CheckBox();
            this.chckbxDesertFilter = new System.Windows.Forms.CheckBox();
            this.chckbxEarthFilter = new System.Windows.Forms.CheckBox();
            this.grpbxShip = new System.Windows.Forms.GroupBox();
            this.ship12 = new System.Windows.Forms.NumericUpDown();
            this.ship11 = new System.Windows.Forms.NumericUpDown();
            this.ship10 = new System.Windows.Forms.NumericUpDown();
            this.ship9 = new System.Windows.Forms.NumericUpDown();
            this.ship8 = new System.Windows.Forms.NumericUpDown();
            this.ship7 = new System.Windows.Forms.NumericUpDown();
            this.ship6 = new System.Windows.Forms.NumericUpDown();
            this.ship5 = new System.Windows.Forms.NumericUpDown();
            this.ship4 = new System.Windows.Forms.NumericUpDown();
            this.ship3 = new System.Windows.Forms.NumericUpDown();
            this.ship2 = new System.Windows.Forms.NumericUpDown();
            this.ship1 = new System.Windows.Forms.NumericUpDown();
            this.pctrbxSprite = new System.Windows.Forms.PictureBox();
            this.cmbxRace = new System.Windows.Forms.ComboBox();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpbxFilter.SuspendLayout();
            this.grpbxShip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ship12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrbxSprite)).BeginInit();
            this.pnlProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpbxFilter);
            this.splitContainer1.Panel1.Controls.Add(this.grpbxShip);
            this.splitContainer1.Panel1.Controls.Add(this.cmbxRace);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlProgress);
            this.splitContainer1.Panel2.Controls.Add(this.dataGrid);
            this.splitContainer1.Size = new System.Drawing.Size(648, 472);
            this.splitContainer1.SplitterDistance = 181;
            this.splitContainer1.TabIndex = 1;
            // 
            // grpbxFilter
            // 
            this.grpbxFilter.Controls.Add(this.btnFilterNow);
            this.grpbxFilter.Controls.Add(this.chckbxWaterFilter);
            this.grpbxFilter.Controls.Add(this.chckbxVulcanFilter);
            this.grpbxFilter.Controls.Add(this.chckbxIceFilter);
            this.grpbxFilter.Controls.Add(this.chckbxDesertFilter);
            this.grpbxFilter.Controls.Add(this.chckbxEarthFilter);
            this.grpbxFilter.Location = new System.Drawing.Point(16, 125);
            this.grpbxFilter.Name = "grpbxFilter";
            this.grpbxFilter.Size = new System.Drawing.Size(507, 49);
            this.grpbxFilter.TabIndex = 9;
            this.grpbxFilter.TabStop = false;
            this.grpbxFilter.Text = "Ich möchte folgende Planetentypen anzeigen";
            // 
            // btnFilterNow
            // 
            this.btnFilterNow.Location = new System.Drawing.Point(421, 15);
            this.btnFilterNow.Name = "btnFilterNow";
            this.btnFilterNow.Size = new System.Drawing.Size(75, 23);
            this.btnFilterNow.TabIndex = 14;
            this.btnFilterNow.Text = "Filtern";
            this.btnFilterNow.UseVisualStyleBackColor = true;
            this.btnFilterNow.Click += new System.EventHandler(this.btnFilterNow_Click);
            // 
            // chckbxWaterFilter
            // 
            this.chckbxWaterFilter.AutoSize = true;
            this.chckbxWaterFilter.Checked = true;
            this.chckbxWaterFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckbxWaterFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckbxWaterFilter.Image = global::ImperionBrowser.Properties.Resources.water;
            this.chckbxWaterFilter.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.chckbxWaterFilter.Location = new System.Drawing.Point(165, 19);
            this.chckbxWaterFilter.Name = "chckbxWaterFilter";
            this.chckbxWaterFilter.Size = new System.Drawing.Size(32, 24);
            this.chckbxWaterFilter.TabIndex = 13;
            this.chckbxWaterFilter.Text = " ";
            this.chckbxWaterFilter.UseVisualStyleBackColor = true;
            // 
            // chckbxVulcanFilter
            // 
            this.chckbxVulcanFilter.AutoSize = true;
            this.chckbxVulcanFilter.Checked = true;
            this.chckbxVulcanFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckbxVulcanFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckbxVulcanFilter.Image = global::ImperionBrowser.Properties.Resources.vulcan;
            this.chckbxVulcanFilter.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.chckbxVulcanFilter.Location = new System.Drawing.Point(127, 19);
            this.chckbxVulcanFilter.Name = "chckbxVulcanFilter";
            this.chckbxVulcanFilter.Size = new System.Drawing.Size(32, 24);
            this.chckbxVulcanFilter.TabIndex = 12;
            this.chckbxVulcanFilter.Text = " ";
            this.chckbxVulcanFilter.UseVisualStyleBackColor = true;
            // 
            // chckbxIceFilter
            // 
            this.chckbxIceFilter.AutoSize = true;
            this.chckbxIceFilter.Checked = true;
            this.chckbxIceFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckbxIceFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckbxIceFilter.Image = global::ImperionBrowser.Properties.Resources.ice;
            this.chckbxIceFilter.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.chckbxIceFilter.Location = new System.Drawing.Point(89, 19);
            this.chckbxIceFilter.Name = "chckbxIceFilter";
            this.chckbxIceFilter.Size = new System.Drawing.Size(32, 24);
            this.chckbxIceFilter.TabIndex = 11;
            this.chckbxIceFilter.Text = " ";
            this.chckbxIceFilter.UseVisualStyleBackColor = true;
            // 
            // chckbxDesertFilter
            // 
            this.chckbxDesertFilter.AutoSize = true;
            this.chckbxDesertFilter.Checked = true;
            this.chckbxDesertFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckbxDesertFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckbxDesertFilter.Image = global::ImperionBrowser.Properties.Resources.desert;
            this.chckbxDesertFilter.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.chckbxDesertFilter.Location = new System.Drawing.Point(51, 19);
            this.chckbxDesertFilter.Name = "chckbxDesertFilter";
            this.chckbxDesertFilter.Size = new System.Drawing.Size(32, 24);
            this.chckbxDesertFilter.TabIndex = 10;
            this.chckbxDesertFilter.Text = " ";
            this.chckbxDesertFilter.UseVisualStyleBackColor = true;
            // 
            // chckbxEarthFilter
            // 
            this.chckbxEarthFilter.AutoSize = true;
            this.chckbxEarthFilter.Checked = true;
            this.chckbxEarthFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckbxEarthFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckbxEarthFilter.Image = global::ImperionBrowser.Properties.Resources.earth;
            this.chckbxEarthFilter.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.chckbxEarthFilter.Location = new System.Drawing.Point(13, 19);
            this.chckbxEarthFilter.Name = "chckbxEarthFilter";
            this.chckbxEarthFilter.Size = new System.Drawing.Size(32, 24);
            this.chckbxEarthFilter.TabIndex = 9;
            this.chckbxEarthFilter.Text = " ";
            this.chckbxEarthFilter.UseVisualStyleBackColor = true;
            // 
            // grpbxShip
            // 
            this.grpbxShip.Controls.Add(this.ship12);
            this.grpbxShip.Controls.Add(this.ship11);
            this.grpbxShip.Controls.Add(this.ship10);
            this.grpbxShip.Controls.Add(this.ship9);
            this.grpbxShip.Controls.Add(this.ship8);
            this.grpbxShip.Controls.Add(this.ship7);
            this.grpbxShip.Controls.Add(this.ship6);
            this.grpbxShip.Controls.Add(this.ship5);
            this.grpbxShip.Controls.Add(this.ship4);
            this.grpbxShip.Controls.Add(this.ship3);
            this.grpbxShip.Controls.Add(this.ship2);
            this.grpbxShip.Controls.Add(this.ship1);
            this.grpbxShip.Controls.Add(this.pctrbxSprite);
            this.grpbxShip.Location = new System.Drawing.Point(15, 39);
            this.grpbxShip.Name = "grpbxShip";
            this.grpbxShip.Size = new System.Drawing.Size(508, 80);
            this.grpbxShip.TabIndex = 2;
            this.grpbxShip.TabStop = false;
            this.grpbxShip.Text = "Ich möchte beim Angriff folgende Schiffe hinzufügen";
            // 
            // ship12
            // 
            this.ship12.Location = new System.Drawing.Point(457, 53);
            this.ship12.Name = "ship12";
            this.ship12.Size = new System.Drawing.Size(40, 20);
            this.ship12.TabIndex = 27;
            // 
            // ship11
            // 
            this.ship11.Location = new System.Drawing.Point(416, 53);
            this.ship11.Name = "ship11";
            this.ship11.Size = new System.Drawing.Size(40, 20);
            this.ship11.TabIndex = 26;
            // 
            // ship10
            // 
            this.ship10.Location = new System.Drawing.Point(375, 53);
            this.ship10.Name = "ship10";
            this.ship10.Size = new System.Drawing.Size(40, 20);
            this.ship10.TabIndex = 25;
            // 
            // ship9
            // 
            this.ship9.Location = new System.Drawing.Point(334, 53);
            this.ship9.Name = "ship9";
            this.ship9.Size = new System.Drawing.Size(40, 20);
            this.ship9.TabIndex = 24;
            // 
            // ship8
            // 
            this.ship8.Location = new System.Drawing.Point(293, 53);
            this.ship8.Name = "ship8";
            this.ship8.Size = new System.Drawing.Size(40, 20);
            this.ship8.TabIndex = 23;
            // 
            // ship7
            // 
            this.ship7.Location = new System.Drawing.Point(252, 53);
            this.ship7.Name = "ship7";
            this.ship7.Size = new System.Drawing.Size(40, 20);
            this.ship7.TabIndex = 22;
            // 
            // ship6
            // 
            this.ship6.Location = new System.Drawing.Point(211, 53);
            this.ship6.Name = "ship6";
            this.ship6.Size = new System.Drawing.Size(40, 20);
            this.ship6.TabIndex = 21;
            // 
            // ship5
            // 
            this.ship5.Location = new System.Drawing.Point(170, 53);
            this.ship5.Name = "ship5";
            this.ship5.Size = new System.Drawing.Size(40, 20);
            this.ship5.TabIndex = 20;
            // 
            // ship4
            // 
            this.ship4.Location = new System.Drawing.Point(129, 53);
            this.ship4.Name = "ship4";
            this.ship4.Size = new System.Drawing.Size(40, 20);
            this.ship4.TabIndex = 19;
            // 
            // ship3
            // 
            this.ship3.Location = new System.Drawing.Point(88, 53);
            this.ship3.Name = "ship3";
            this.ship3.Size = new System.Drawing.Size(40, 20);
            this.ship3.TabIndex = 18;
            // 
            // ship2
            // 
            this.ship2.Location = new System.Drawing.Point(47, 53);
            this.ship2.Name = "ship2";
            this.ship2.Size = new System.Drawing.Size(40, 20);
            this.ship2.TabIndex = 17;
            // 
            // ship1
            // 
            this.ship1.Location = new System.Drawing.Point(6, 53);
            this.ship1.Name = "ship1";
            this.ship1.Size = new System.Drawing.Size(40, 20);
            this.ship1.TabIndex = 16;
            // 
            // pctrbxSprite
            // 
            this.pctrbxSprite.Image = ((System.Drawing.Image)(resources.GetObject("pctrbxSprite.Image")));
            this.pctrbxSprite.InitialImage = null;
            this.pctrbxSprite.Location = new System.Drawing.Point(6, 19);
            this.pctrbxSprite.Name = "pctrbxSprite";
            this.pctrbxSprite.Size = new System.Drawing.Size(496, 28);
            this.pctrbxSprite.TabIndex = 15;
            this.pctrbxSprite.TabStop = false;
            // 
            // cmbxRace
            // 
            this.cmbxRace.FormattingEnabled = true;
            this.cmbxRace.Items.AddRange(new object[] {
            "Ich bin ein Terraner",
            "Ich bin ein Xen",
            "Ich bin ein Titan"});
            this.cmbxRace.Location = new System.Drawing.Point(15, 12);
            this.cmbxRace.Name = "cmbxRace";
            this.cmbxRace.Size = new System.Drawing.Size(201, 21);
            this.cmbxRace.TabIndex = 1;
            this.cmbxRace.Tag = "Ich bin ein Terraner";
            this.cmbxRace.SelectedIndexChanged += new System.EventHandler(this.cmbxRace_SelectedIndexChanged);
            // 
            // pnlProgress
            // 
            this.pnlProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProgress.Controls.Add(this.label2);
            this.pnlProgress.Controls.Add(this.progressBar);
            this.pnlProgress.Location = new System.Drawing.Point(0, 103);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(648, 44);
            this.pnlProgress.TabIndex = 2;
            this.pnlProgress.Visible = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(648, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Daten werden vorbereitet, bitte habe einen Moment geduld";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 21);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(648, 23);
            this.progressBar.TabIndex = 0;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(648, 287);
            this.dataGrid.TabIndex = 1;
            this.dataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellDoubleClick);
            // 
            // frmRaidTargets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 472);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmRaidTargets";
            this.Text = "Raid Ziele...";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.frmRecyclerTargets_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.grpbxFilter.ResumeLayout(false);
            this.grpbxFilter.PerformLayout();
            this.grpbxShip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ship12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrbxSprite)).EndInit();
            this.pnlProgress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ComboBox cmbxRace;
        private System.Windows.Forms.GroupBox grpbxShip;
        private System.Windows.Forms.NumericUpDown ship12;
        private System.Windows.Forms.NumericUpDown ship11;
        private System.Windows.Forms.NumericUpDown ship10;
        private System.Windows.Forms.NumericUpDown ship9;
        private System.Windows.Forms.NumericUpDown ship8;
        private System.Windows.Forms.NumericUpDown ship7;
        private System.Windows.Forms.NumericUpDown ship6;
        private System.Windows.Forms.NumericUpDown ship5;
        private System.Windows.Forms.NumericUpDown ship4;
        private System.Windows.Forms.NumericUpDown ship3;
        private System.Windows.Forms.NumericUpDown ship2;
        private System.Windows.Forms.NumericUpDown ship1;
        private System.Windows.Forms.PictureBox pctrbxSprite;
        private System.Windows.Forms.GroupBox grpbxFilter;
        private System.Windows.Forms.CheckBox chckbxWaterFilter;
        private System.Windows.Forms.CheckBox chckbxVulcanFilter;
        private System.Windows.Forms.CheckBox chckbxIceFilter;
        private System.Windows.Forms.CheckBox chckbxDesertFilter;
        private System.Windows.Forms.CheckBox chckbxEarthFilter;
        private System.Windows.Forms.Button btnFilterNow;
    }
}