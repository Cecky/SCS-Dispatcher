
namespace ScsDispatcher
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnFolderETS = new System.Windows.Forms.Button();
            this.TxtPathETS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnFolderATS = new System.Windows.Forms.Button();
            this.TxtPathATS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAutoLearn = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDefaultJobLength = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbIgnoreTranslation = new System.Windows.Forms.CheckBox();
            this.cbExportSavegameToText = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnFolderETS);
            this.groupBox1.Controls.Add(this.TxtPathETS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(681, 70);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Euro Truck Simulator 2";
            // 
            // BtnFolderETS
            // 
            this.BtnFolderETS.Image = ((System.Drawing.Image)(resources.GetObject("BtnFolderETS.Image")));
            this.BtnFolderETS.Location = new System.Drawing.Point(637, 25);
            this.BtnFolderETS.Name = "BtnFolderETS";
            this.BtnFolderETS.Size = new System.Drawing.Size(22, 22);
            this.BtnFolderETS.TabIndex = 3;
            this.BtnFolderETS.UseVisualStyleBackColor = true;
            this.BtnFolderETS.Click += new System.EventHandler(this.OpenFolder);
            // 
            // TxtPathETS
            // 
            this.TxtPathETS.Location = new System.Drawing.Point(91, 26);
            this.TxtPathETS.Name = "TxtPathETS";
            this.TxtPathETS.Size = new System.Drawing.Size(546, 20);
            this.TxtPathETS.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Steam Pfad:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnFolderATS);
            this.groupBox2.Controls.Add(this.TxtPathATS);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(13, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(681, 70);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "American Truck Simulator";
            // 
            // BtnFolderATS
            // 
            this.BtnFolderATS.Image = ((System.Drawing.Image)(resources.GetObject("BtnFolderATS.Image")));
            this.BtnFolderATS.Location = new System.Drawing.Point(637, 25);
            this.BtnFolderATS.Name = "BtnFolderATS";
            this.BtnFolderATS.Size = new System.Drawing.Size(22, 22);
            this.BtnFolderATS.TabIndex = 3;
            this.BtnFolderATS.UseVisualStyleBackColor = true;
            this.BtnFolderATS.Click += new System.EventHandler(this.OpenFolder);
            // 
            // TxtPathATS
            // 
            this.TxtPathATS.Location = new System.Drawing.Point(91, 26);
            this.TxtPathATS.Name = "TxtPathATS";
            this.TxtPathATS.Size = new System.Drawing.Size(546, 20);
            this.TxtPathATS.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Steam Pfad:";
            // 
            // cbAutoLearn
            // 
            this.cbAutoLearn.AutoSize = true;
            this.cbAutoLearn.Location = new System.Drawing.Point(21, 164);
            this.cbAutoLearn.Name = "cbAutoLearn";
            this.cbAutoLearn.Size = new System.Drawing.Size(244, 17);
            this.cbAutoLearn.TabIndex = 5;
            this.cbAutoLearn.Text = "Automatisches lernen der Distanzen aktivieren";
            this.cbAutoLearn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Standard Joblänge:";
            // 
            // TxtDefaultJobLength
            // 
            this.TxtDefaultJobLength.Location = new System.Drawing.Point(124, 192);
            this.TxtDefaultJobLength.Name = "TxtDefaultJobLength";
            this.TxtDefaultJobLength.Size = new System.Drawing.Size(57, 20);
            this.TxtDefaultJobLength.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "km/miles";
            // 
            // cbIgnoreTranslation
            // 
            this.cbIgnoreTranslation.AutoSize = true;
            this.cbIgnoreTranslation.Location = new System.Drawing.Point(306, 164);
            this.cbIgnoreTranslation.Name = "cbIgnoreTranslation";
            this.cbIgnoreTranslation.Size = new System.Drawing.Size(175, 17);
            this.cbIgnoreTranslation.TabIndex = 8;
            this.cbIgnoreTranslation.Text = "Frachtübersetzungen ignorieren";
            this.cbIgnoreTranslation.UseVisualStyleBackColor = true;
            // 
            // cbExportSavegameToText
            // 
            this.cbExportSavegameToText.AutoSize = true;
            this.cbExportSavegameToText.Location = new System.Drawing.Point(21, 231);
            this.cbExportSavegameToText.Name = "cbExportSavegameToText";
            this.cbExportSavegameToText.Size = new System.Drawing.Size(254, 17);
            this.cbExportSavegameToText.TabIndex = 9;
            this.cbExportSavegameToText.Text = "Erzeuge Savegame als Textdatei in \"D:\\Temp\\\"";
            this.cbExportSavegameToText.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 260);
            this.Controls.Add(this.cbExportSavegameToText);
            this.Controls.Add(this.cbIgnoreTranslation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtDefaultJobLength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbAutoLearn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSettings_FormClosing);
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnFolderETS;
        private System.Windows.Forms.TextBox TxtPathETS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnFolderATS;
        private System.Windows.Forms.TextBox TxtPathATS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbAutoLearn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDefaultJobLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbIgnoreTranslation;
        private System.Windows.Forms.CheckBox cbExportSavegameToText;
    }
}