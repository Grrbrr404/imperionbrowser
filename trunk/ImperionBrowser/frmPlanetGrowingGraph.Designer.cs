namespace ImperionBrowser
{
    partial class frmPlanetGrowingGraph
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblXYCoordinates = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.zedGraph_PlanetGrowing = new ZedGraph.ZedGraphControl();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblXYCoordinates});
            this.statusStrip1.Location = new System.Drawing.Point(0, 505);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1004, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblXYCoordinates
            // 
            this.lblXYCoordinates.Name = "lblXYCoordinates";
            this.lblXYCoordinates.Size = new System.Drawing.Size(0, 17);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.zedGraph_PlanetGrowing);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 505);
            this.panel1.TabIndex = 2;
            // 
            // zedGraph_PlanetGrowing
            // 
            this.zedGraph_PlanetGrowing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraph_PlanetGrowing.IsShowPointValues = true;
            this.zedGraph_PlanetGrowing.Location = new System.Drawing.Point(0, 0);
            this.zedGraph_PlanetGrowing.Name = "zedGraph_PlanetGrowing";
            this.zedGraph_PlanetGrowing.ScrollGrace = 0;
            this.zedGraph_PlanetGrowing.ScrollMaxX = 0;
            this.zedGraph_PlanetGrowing.ScrollMaxY = 0;
            this.zedGraph_PlanetGrowing.ScrollMaxY2 = 0;
            this.zedGraph_PlanetGrowing.ScrollMinX = 0;
            this.zedGraph_PlanetGrowing.ScrollMinY = 0;
            this.zedGraph_PlanetGrowing.ScrollMinY2 = 0;
            this.zedGraph_PlanetGrowing.Size = new System.Drawing.Size(1004, 505);
            this.zedGraph_PlanetGrowing.TabIndex = 1;
            this.zedGraph_PlanetGrowing.ZoomStepFraction = 1;
            this.zedGraph_PlanetGrowing.MouseMoveEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(this.zedGraph_PlanetGrowing_MouseMoveEvent);
            // 
            // frmPlanetGrowingGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 527);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPlanetGrowingGraph";
            this.Text = "Planeten wachstum";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmGraph_Load);
            this.Resize += new System.EventHandler(this.frmGraph_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblXYCoordinates;
        private System.Windows.Forms.Panel panel1;
        private ZedGraph.ZedGraphControl zedGraph_PlanetGrowing;
    }
}