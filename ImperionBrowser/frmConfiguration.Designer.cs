namespace ImperionBrowser
{
    partial class frmConfiguration
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.frpbxGoogleSms = new System.Windows.Forms.GroupBox();
            this.btnSearchCalendar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbxGoogleCalendar = new System.Windows.Forms.ComboBox();
            this.txtbxGooglePwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbxGoogleAccountName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnSendTest = new System.Windows.Forms.Button();
            this.frpbxGoogleSms.SuspendLayout();
            this.SuspendLayout();
            // 
            // frpbxGoogleSms
            // 
            this.frpbxGoogleSms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.frpbxGoogleSms.Controls.Add(this.btnSearchCalendar);
            this.frpbxGoogleSms.Controls.Add(this.label3);
            this.frpbxGoogleSms.Controls.Add(this.cmbxGoogleCalendar);
            this.frpbxGoogleSms.Controls.Add(this.txtbxGooglePwd);
            this.frpbxGoogleSms.Controls.Add(this.label2);
            this.frpbxGoogleSms.Controls.Add(this.txtbxGoogleAccountName);
            this.frpbxGoogleSms.Controls.Add(this.label1);
            this.frpbxGoogleSms.Location = new System.Drawing.Point(12, 12);
            this.frpbxGoogleSms.Name = "frpbxGoogleSms";
            this.frpbxGoogleSms.Size = new System.Drawing.Size(373, 158);
            this.frpbxGoogleSms.TabIndex = 0;
            this.frpbxGoogleSms.TabStop = false;
            this.frpbxGoogleSms.Text = "SMS Benachrichtigung bei Angriffen";
            // 
            // btnSearchCalendar
            // 
            this.btnSearchCalendar.Location = new System.Drawing.Point(298, 119);
            this.btnSearchCalendar.Name = "btnSearchCalendar";
            this.btnSearchCalendar.Size = new System.Drawing.Size(69, 23);
            this.btnSearchCalendar.TabIndex = 6;
            this.btnSearchCalendar.Text = "Suchen...";
            this.btnSearchCalendar.UseVisualStyleBackColor = true;
            this.btnSearchCalendar.Click += new System.EventHandler(this.btnSearchCalendar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kalender";
            // 
            // cmbxGoogleCalendar
            // 
            this.cmbxGoogleCalendar.FormattingEnabled = true;
            this.cmbxGoogleCalendar.Location = new System.Drawing.Point(9, 119);
            this.cmbxGoogleCalendar.Name = "cmbxGoogleCalendar";
            this.cmbxGoogleCalendar.Size = new System.Drawing.Size(283, 21);
            this.cmbxGoogleCalendar.TabIndex = 4;
            this.cmbxGoogleCalendar.TextChanged += new System.EventHandler(this.txtbx_TextChanged);
            // 
            // txtbxGooglePwd
            // 
            this.txtbxGooglePwd.Location = new System.Drawing.Point(9, 80);
            this.txtbxGooglePwd.Name = "txtbxGooglePwd";
            this.txtbxGooglePwd.Size = new System.Drawing.Size(358, 20);
            this.txtbxGooglePwd.TabIndex = 3;
            this.txtbxGooglePwd.UseSystemPasswordChar = true;
            this.txtbxGooglePwd.TextChanged += new System.EventHandler(this.txtbx_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Google Account Password";
            // 
            // txtbxGoogleAccountName
            // 
            this.txtbxGoogleAccountName.Location = new System.Drawing.Point(9, 41);
            this.txtbxGoogleAccountName.Name = "txtbxGoogleAccountName";
            this.txtbxGoogleAccountName.Size = new System.Drawing.Size(358, 20);
            this.txtbxGoogleAccountName.TabIndex = 1;
            this.txtbxGoogleAccountName.TextChanged += new System.EventHandler(this.txtbx_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Google Account Name";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveChanges.Enabled = false;
            this.btnSaveChanges.Location = new System.Drawing.Point(310, 176);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(75, 23);
            this.btnSaveChanges.TabIndex = 1;
            this.btnSaveChanges.Text = "&Übernehmen";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(229, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(148, 176);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnSendTest
            // 
            this.btnSendTest.Location = new System.Drawing.Point(13, 176);
            this.btnSendTest.Name = "btnSendTest";
            this.btnSendTest.Size = new System.Drawing.Size(75, 23);
            this.btnSendTest.TabIndex = 4;
            this.btnSendTest.Text = "Send test";
            this.btnSendTest.UseVisualStyleBackColor = true;
            this.btnSendTest.Visible = false;
            this.btnSendTest.Click += new System.EventHandler(this.btnSendTest_Click);
            // 
            // frmConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 211);
            this.Controls.Add(this.btnSendTest);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.frpbxGoogleSms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConfiguration";
            this.Text = "Einstellungen...";
            this.Load += new System.EventHandler(this.frmConfiguration_Load);
            this.frpbxGoogleSms.ResumeLayout(false);
            this.frpbxGoogleSms.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox frpbxGoogleSms;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtbxGoogleAccountName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbxGooglePwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearchCalendar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbxGoogleCalendar;
        private System.Windows.Forms.Button btnSendTest;
    }
}