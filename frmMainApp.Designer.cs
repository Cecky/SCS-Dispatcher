
namespace ScsDispatcher
{
    partial class FrmMainApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainApp));
            this.grpRoute = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnAddJob = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCargo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCompaniesTo = new System.Windows.Forms.ComboBox();
            this.cmbCitiesTo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCompaniesFrom = new System.Windows.Forms.ComboBox();
            this.cmbCitiesFrom = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblSiiVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemGenerateLocalisationETS = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemGenerateLocalisationATS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemGenerateDistances = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemMaps = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLanguagefiles = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemClearJobs = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemWrite3nkETS = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemWrite3nkATS = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblGameID = new System.Windows.Forms.Label();
            this.grpTour = new System.Windows.Forms.GroupBox();
            this.lblNoJobs = new System.Windows.Forms.Label();
            this.ListTouren = new System.Windows.Forms.ListView();
            this.TourNr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Von = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nach = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fracht = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Distanz = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MenuItemSiiToJSON = new System.Windows.Forms.ToolStripMenuItem();
            this.grpRoute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpTour.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRoute
            // 
            this.grpRoute.Controls.Add(this.pictureBox1);
            this.grpRoute.Controls.Add(this.BtnAddJob);
            this.grpRoute.Controls.Add(this.label5);
            this.grpRoute.Controls.Add(this.cmbCargo);
            this.grpRoute.Controls.Add(this.label3);
            this.grpRoute.Controls.Add(this.label4);
            this.grpRoute.Controls.Add(this.cmbCompaniesTo);
            this.grpRoute.Controls.Add(this.cmbCitiesTo);
            this.grpRoute.Controls.Add(this.label2);
            this.grpRoute.Controls.Add(this.label1);
            this.grpRoute.Controls.Add(this.cmbCompaniesFrom);
            this.grpRoute.Controls.Add(this.cmbCitiesFrom);
            this.grpRoute.Enabled = false;
            this.grpRoute.Location = new System.Drawing.Point(10, 85);
            this.grpRoute.Name = "grpRoute";
            this.grpRoute.Size = new System.Drawing.Size(522, 204);
            this.grpRoute.TabIndex = 1;
            this.grpRoute.TabStop = false;
            this.grpRoute.Text = "Route";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(211, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // BtnAddJob
            // 
            this.BtnAddJob.Location = new System.Drawing.Point(211, 163);
            this.BtnAddJob.Name = "BtnAddJob";
            this.BtnAddJob.Size = new System.Drawing.Size(95, 33);
            this.BtnAddJob.TabIndex = 15;
            this.BtnAddJob.Text = "Job hinzufügen";
            this.BtnAddJob.UseVisualStyleBackColor = true;
            this.BtnAddJob.Click += new System.EventHandler(this.BtnAddJob_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Fracht";
            // 
            // cmbCargo
            // 
            this.cmbCargo.Location = new System.Drawing.Point(144, 136);
            this.cmbCargo.Name = "cmbCargo";
            this.cmbCargo.Size = new System.Drawing.Size(231, 21);
            this.cmbCargo.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Firma";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Stadt";
            // 
            // cmbCompaniesTo
            // 
            this.cmbCompaniesTo.FormattingEnabled = true;
            this.cmbCompaniesTo.Location = new System.Drawing.Point(312, 86);
            this.cmbCompaniesTo.Name = "cmbCompaniesTo";
            this.cmbCompaniesTo.Size = new System.Drawing.Size(199, 21);
            this.cmbCompaniesTo.TabIndex = 7;
            // 
            // cmbCitiesTo
            // 
            this.cmbCitiesTo.FormattingEnabled = true;
            this.cmbCitiesTo.Location = new System.Drawing.Point(312, 46);
            this.cmbCitiesTo.Name = "cmbCitiesTo";
            this.cmbCitiesTo.Size = new System.Drawing.Size(199, 21);
            this.cmbCitiesTo.TabIndex = 6;
            this.cmbCitiesTo.SelectedValueChanged += new System.EventHandler(this.UpdateCompaniesTo);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Firma";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Stadt";
            // 
            // cmbCompaniesFrom
            // 
            this.cmbCompaniesFrom.Location = new System.Drawing.Point(6, 86);
            this.cmbCompaniesFrom.Name = "cmbCompaniesFrom";
            this.cmbCompaniesFrom.Size = new System.Drawing.Size(199, 21);
            this.cmbCompaniesFrom.TabIndex = 3;
            // 
            // cmbCitiesFrom
            // 
            this.cmbCitiesFrom.Location = new System.Drawing.Point(6, 46);
            this.cmbCitiesFrom.Name = "cmbCitiesFrom";
            this.cmbCitiesFrom.Size = new System.Drawing.Size(199, 21);
            this.cmbCitiesFrom.TabIndex = 2;
            this.cmbCitiesFrom.SelectedValueChanged += new System.EventHandler(this.UpdateCompaniesFrom);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(871, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "SiiLibrary:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSiiVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 617);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(544, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblSiiVersion
            // 
            this.lblSiiVersion.Name = "lblSiiVersion";
            this.lblSiiVersion.Size = new System.Drawing.Size(22, 17);
            this.lblSiiVersion.Text = "---";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.extrasToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(544, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemOpen,
            this.toolStripSeparator,
            this.MenuItemSave,
            this.MenuItemSaveAs,
            this.toolStripSeparator1,
            this.MenuItemClose});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "&Datei";
            // 
            // MenuItemOpen
            // 
            this.MenuItemOpen.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemOpen.Image")));
            this.MenuItemOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuItemOpen.Name = "MenuItemOpen";
            this.MenuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuItemOpen.Size = new System.Drawing.Size(168, 22);
            this.MenuItemOpen.Text = "Ö&ffnen";
            this.MenuItemOpen.Click += new System.EventHandler(this.MenuItemOpen_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(165, 6);
            // 
            // MenuItemSave
            // 
            this.MenuItemSave.Enabled = false;
            this.MenuItemSave.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemSave.Image")));
            this.MenuItemSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuItemSave.Name = "MenuItemSave";
            this.MenuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuItemSave.Size = new System.Drawing.Size(168, 22);
            this.MenuItemSave.Text = "&Speichern";
            this.MenuItemSave.Click += new System.EventHandler(this.MenuItemSave_Click);
            // 
            // MenuItemSaveAs
            // 
            this.MenuItemSaveAs.Enabled = false;
            this.MenuItemSaveAs.Name = "MenuItemSaveAs";
            this.MenuItemSaveAs.Size = new System.Drawing.Size(168, 22);
            this.MenuItemSaveAs.Text = "Speichern &unter";
            this.MenuItemSaveAs.Click += new System.EventHandler(this.MenuItemSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // MenuItemClose
            // 
            this.MenuItemClose.Name = "MenuItemClose";
            this.MenuItemClose.Size = new System.Drawing.Size(168, 22);
            this.MenuItemClose.Text = "&Beenden";
            this.MenuItemClose.Click += new System.EventHandler(this.MenuItemClose_Click);
            // 
            // extrasToolStripMenuItem
            // 
            this.extrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemGenerateLocalisationETS,
            this.MenuItemGenerateLocalisationATS,
            this.MenuItemSiiToJSON,
            this.toolStripSeparator2,
            this.MenuItemGenerateDistances,
            this.toolStripSeparator3,
            this.MenuItemSettings,
            this.toolStripSeparator4,
            this.MenuItemMaps,
            this.MenuItemLanguagefiles,
            this.MenuItemClearJobs});
            this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            this.extrasToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.extrasToolStripMenuItem.Text = "Extras";
            // 
            // MenuItemGenerateLocalisationETS
            // 
            this.MenuItemGenerateLocalisationETS.Name = "MenuItemGenerateLocalisationETS";
            this.MenuItemGenerateLocalisationETS.Size = new System.Drawing.Size(263, 22);
            this.MenuItemGenerateLocalisationETS.Text = "Lokaldaten erstellen (ETS)";
            this.MenuItemGenerateLocalisationETS.Click += new System.EventHandler(this.MenuItemGenerateLocalisation_Click);
            // 
            // MenuItemGenerateLocalisationATS
            // 
            this.MenuItemGenerateLocalisationATS.Name = "MenuItemGenerateLocalisationATS";
            this.MenuItemGenerateLocalisationATS.Size = new System.Drawing.Size(263, 22);
            this.MenuItemGenerateLocalisationATS.Text = "Lokaldaten erstellen (ATS)";
            this.MenuItemGenerateLocalisationATS.Click += new System.EventHandler(this.MenuItemGenerateLocalisation_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(260, 6);
            // 
            // MenuItemGenerateDistances
            // 
            this.MenuItemGenerateDistances.Name = "MenuItemGenerateDistances";
            this.MenuItemGenerateDistances.Size = new System.Drawing.Size(263, 22);
            this.MenuItemGenerateDistances.Text = "Distanzen-DB aktualisieren";
            this.MenuItemGenerateDistances.Click += new System.EventHandler(this.MenuItemGenerateDistances_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(260, 6);
            // 
            // MenuItemSettings
            // 
            this.MenuItemSettings.Name = "MenuItemSettings";
            this.MenuItemSettings.Size = new System.Drawing.Size(263, 22);
            this.MenuItemSettings.Text = "Einstellungen";
            this.MenuItemSettings.Click += new System.EventHandler(this.MenuItemSettings_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(260, 6);
            // 
            // MenuItemMaps
            // 
            this.MenuItemMaps.Name = "MenuItemMaps";
            this.MenuItemMaps.Size = new System.Drawing.Size(263, 22);
            this.MenuItemMaps.Text = "Karten";
            this.MenuItemMaps.Click += new System.EventHandler(this.MenuItemMaps_Click);
            // 
            // MenuItemLanguagefiles
            // 
            this.MenuItemLanguagefiles.Name = "MenuItemLanguagefiles";
            this.MenuItemLanguagefiles.Size = new System.Drawing.Size(263, 22);
            this.MenuItemLanguagefiles.Text = "Städteliste (ETS)";
            this.MenuItemLanguagefiles.Click += new System.EventHandler(this.MenuItemLanguagefiles_Click);
            // 
            // MenuItemClearJobs
            // 
            this.MenuItemClearJobs.Enabled = false;
            this.MenuItemClearJobs.Name = "MenuItemClearJobs";
            this.MenuItemClearJobs.Size = new System.Drawing.Size(263, 22);
            this.MenuItemClearJobs.Text = "Jobs löschen";
            this.MenuItemClearJobs.Click += new System.EventHandler(this.MenuItemJobClear_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemWrite3nkETS,
            this.MenuItemWrite3nkATS});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.Visible = false;
            // 
            // MenuItemWrite3nkETS
            // 
            this.MenuItemWrite3nkETS.Name = "MenuItemWrite3nkETS";
            this.MenuItemWrite3nkETS.Size = new System.Drawing.Size(131, 22);
            this.MenuItemWrite3nkETS.Text = "Debug ETS";
            this.MenuItemWrite3nkETS.Click += new System.EventHandler(this.MenuItemDebugETS_Click);
            // 
            // MenuItemWrite3nkATS
            // 
            this.MenuItemWrite3nkATS.Name = "MenuItemWrite3nkATS";
            this.MenuItemWrite3nkATS.Size = new System.Drawing.Size(131, 22);
            this.MenuItemWrite3nkATS.Text = "Debug ATS";
            this.MenuItemWrite3nkATS.Click += new System.EventHandler(this.MenuItemDebugATS_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblGameID);
            this.groupBox1.Location = new System.Drawing.Point(10, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 52);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spiel";
            // 
            // lblGameID
            // 
            this.lblGameID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameID.Location = new System.Drawing.Point(6, 16);
            this.lblGameID.Name = "lblGameID";
            this.lblGameID.Size = new System.Drawing.Size(510, 25);
            this.lblGameID.TabIndex = 0;
            this.lblGameID.Text = "---";
            this.lblGameID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpTour
            // 
            this.grpTour.Controls.Add(this.lblNoJobs);
            this.grpTour.Controls.Add(this.ListTouren);
            this.grpTour.Enabled = false;
            this.grpTour.Location = new System.Drawing.Point(10, 295);
            this.grpTour.Name = "grpTour";
            this.grpTour.Size = new System.Drawing.Size(522, 321);
            this.grpTour.TabIndex = 19;
            this.grpTour.TabStop = false;
            this.grpTour.Text = "Tour(en)";
            // 
            // lblNoJobs
            // 
            this.lblNoJobs.AutoSize = true;
            this.lblNoJobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoJobs.ForeColor = System.Drawing.Color.Red;
            this.lblNoJobs.Location = new System.Drawing.Point(177, 159);
            this.lblNoJobs.Name = "lblNoJobs";
            this.lblNoJobs.Size = new System.Drawing.Size(158, 31);
            this.lblNoJobs.TabIndex = 19;
            this.lblNoJobs.Text = "Keine Jobs";
            // 
            // ListTouren
            // 
            this.ListTouren.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TourNr,
            this.Von,
            this.Nach,
            this.Fracht,
            this.Distanz});
            this.ListTouren.GridLines = true;
            this.ListTouren.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListTouren.HideSelection = false;
            this.ListTouren.Location = new System.Drawing.Point(9, 19);
            this.ListTouren.MultiSelect = false;
            this.ListTouren.Name = "ListTouren";
            this.ListTouren.Size = new System.Drawing.Size(510, 296);
            this.ListTouren.TabIndex = 20;
            this.ListTouren.UseCompatibleStateImageBehavior = false;
            this.ListTouren.View = System.Windows.Forms.View.Details;
            // 
            // TourNr
            // 
            this.TourNr.Text = "Nr.";
            this.TourNr.Width = 30;
            // 
            // Von
            // 
            this.Von.Text = "Von";
            this.Von.Width = 150;
            // 
            // Nach
            // 
            this.Nach.Text = "Nach";
            this.Nach.Width = 150;
            // 
            // Fracht
            // 
            this.Fracht.Text = "Fracht";
            this.Fracht.Width = 120;
            // 
            // Distanz
            // 
            this.Distanz.Text = "Distanz";
            this.Distanz.Width = 56;
            // 
            // MenuItemSiiToJSON
            // 
            this.MenuItemSiiToJSON.Name = "MenuItemSiiToJSON";
            this.MenuItemSiiToJSON.Size = new System.Drawing.Size(263, 22);
            this.MenuItemSiiToJSON.Text = "Übersetzungsdatei in JSON wandeln";
            this.MenuItemSiiToJSON.Click += new System.EventHandler(this.MenuItemSiiToJSON_Click);
            // 
            // FrmMainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 639);
            this.Controls.Add(this.grpTour);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grpRoute);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMainApp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SCS Dispatcher";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpRoute.ResumeLayout(false);
            this.grpRoute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.grpTour.ResumeLayout(false);
            this.grpTour.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpRoute;
        private System.Windows.Forms.ComboBox cmbCompaniesFrom;
        private System.Windows.Forms.ComboBox cmbCitiesFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCompaniesTo;
        private System.Windows.Forms.ComboBox cmbCitiesTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCargo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblSiiVersion;
        private System.Windows.Forms.Button BtnAddJob;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemClose;
        private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGenerateLocalisationATS;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGenerateLocalisationETS;
        private System.Windows.Forms.Label lblGameID;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSettings;
        private System.Windows.Forms.GroupBox grpTour;
        private System.Windows.Forms.Label lblNoJobs;
        private System.Windows.Forms.ListView ListTouren;
        private System.Windows.Forms.ColumnHeader TourNr;
        private System.Windows.Forms.ColumnHeader Von;
        private System.Windows.Forms.ColumnHeader Nach;
        private System.Windows.Forms.ColumnHeader Fracht;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveAs;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGenerateDistances;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ColumnHeader Distanz;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem MenuItemMaps;
        private System.Windows.Forms.ToolStripMenuItem MenuItemLanguagefiles;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemWrite3nkETS;
        private System.Windows.Forms.ToolStripMenuItem MenuItemWrite3nkATS;
        private System.Windows.Forms.ToolStripMenuItem MenuItemClearJobs;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSiiToJSON;
    }
}

