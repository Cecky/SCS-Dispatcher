
namespace ScsDispatcher
{
    partial class FrmMaps
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
            this.MapPictureBox = new System.Windows.Forms.PictureBox();
            this.CmbMap = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.MapPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MapPictureBox
            // 
            this.MapPictureBox.Location = new System.Drawing.Point(12, 49);
            this.MapPictureBox.Name = "MapPictureBox";
            this.MapPictureBox.Size = new System.Drawing.Size(984, 668);
            this.MapPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.MapPictureBox.TabIndex = 2;
            this.MapPictureBox.TabStop = false;
            // 
            // CmbMap
            // 
            this.CmbMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMap.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMap.FormattingEnabled = true;
            this.CmbMap.Location = new System.Drawing.Point(12, 12);
            this.CmbMap.Name = "CmbMap";
            this.CmbMap.Size = new System.Drawing.Size(984, 31);
            this.CmbMap.TabIndex = 3;
            this.CmbMap.SelectedValueChanged += new System.EventHandler(this.CmbMap_SelectedValueChanged);
            // 
            // FrmMaps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.CmbMap);
            this.Controls.Add(this.MapPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmMaps";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Karten";
            this.Load += new System.EventHandler(this.FrmMaps_Load);
            this.SizeChanged += new System.EventHandler(this.FrmMaps_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.MapPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox MapPictureBox;
        private System.Windows.Forms.ComboBox CmbMap;
    }
}