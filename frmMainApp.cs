using CustomForms;
using HashFS;
using Language;
using Scs.SaveGame;
using ScsDispatcher.Properties;
using SiiLibrary;
using SiiLibrary.MemStream;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScsDispatcher
{
    public partial class FrmMainApp : Form
    {
        #region Variables
        private string siiFileName;
        private ScsSavegame Savegame;

        #endregion region

        #region Form
        public FrmMainApp()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            Version ver = typeof(FrmMainApp).Assembly.GetName().Version;
            this.Text += " " + ver.ToString();

            lblSiiVersion.Text = "SiiLibrary: " + SiiLib.GetVersion();

#if DEBUG
            debugToolStripMenuItem.Visible = true;
#endif

        }
        #endregion

        #region ComboBoxes
        private void UpdateCompaniesFrom(object sender, EventArgs e)
        {
            Random rand = new Random();
            cmbCompaniesFrom.Items.Clear();
            Savegame.CityList[cmbCitiesFrom.SelectedIndex].Companies.Sort();
            foreach (var Company in Savegame.CityList[cmbCitiesFrom.SelectedIndex].Companies)
            {
                cmbCompaniesFrom.Items.Add(Company.TranslatedName);
            }
            cmbCompaniesFrom.SelectedIndex = rand.Next(cmbCompaniesFrom.Items.Count);
        }
        private void UpdateCompaniesTo(object sender, EventArgs e)
        {
            Random rand = new Random();
            cmbCompaniesTo.Items.Clear();
            Savegame.CityList[cmbCitiesTo.SelectedIndex].Companies.Sort();
            foreach (var Company in Savegame.CityList[cmbCitiesTo.SelectedIndex].Companies)
            {
                cmbCompaniesTo.Items.Add(Company.TranslatedName);
            }
            cmbCompaniesTo.SelectedIndex = rand.Next(cmbCompaniesTo.Items.Count);
        }
        #endregion

        #region MenuStrip
        private void MenuItemGenerateLocalisation_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem) sender;
            StringBuilder sb = new StringBuilder();
            ScsDictionary.GameID gameId; 
            string GamePath;
            
            if (menuItem.Text.Contains("ETS"))
            {
                gameId = ScsDictionary.GameID.ETS;
                GamePath = Properties.Settings.Default.GameFilesPathETS;
                if(!GamePath.ToLower().Contains("euro"))
                {
                    MessageBox.Show("Kein gültiger Pfad. Bitte Einstellungen überprüfen", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                gameId = ScsDictionary.GameID.ATS;
                GamePath = Properties.Settings.Default.GameFilesPathATS;
                if (!GamePath.ToLower().Contains("american"))
                {
                    MessageBox.Show("Kein gültiger Pfad. Bitte Einstellungen überprüfen","Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            } 

            if (!File.Exists(GamePath + @"\def.scs"))
            {
                sb.AppendLine("Die Datei \"def.scs\" konnte im angegeben Pfad nicht gefunden werden");
                sb.AppendLine();
                sb.AppendLine("\"" + GamePath + "\"");
                MessageBox.Show(sb.ToString(), "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.DoEvents();
            LanguageGenerator.Build(GamePath, gameId);
        }
        private void MenuItemOpen_Click(object sender, EventArgs e)
        {
            ScsDictionary.GameID gameID;
            OpenFileDialog ofd = new OpenFileDialog();
            var rand = new Random();
            ofd.Filter = "Savegames (*.sii) |*.sii";

            // clear all usercontrols
            foreach (Control ctrl in grpRoute.Controls)
            {
                if (ctrl.GetType() == typeof(ComboBox))
                {
                    ComboBox comboBox = ctrl as ComboBox;
                    comboBox.Items.Clear();
                }
            }
            ListTouren.Items.Clear();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                CustomMessageBox frmMessage = new CustomMessageBox("Loading", "Lade Savegame...", 12.0F);
                frmMessage.Show();
                Application.DoEvents();
                
                siiFileName = ofd.FileName;
                string BackupFileName = siiFileName.Replace(".sii", "") + "_backup.sii";
                File.Copy(siiFileName, BackupFileName, true);

                if (siiFileName.Contains("Euro"))
                    gameID = ScsDictionary.GameID.ETS;
                else
                    gameID = ScsDictionary.GameID.ATS;

                SiiStream siiStream = new SiiStream(siiFileName);
                Savegame = new ScsSavegame(siiStream, gameID);

                // add all cities to comboboxes
                foreach (var city in Savegame.CityList)
                {
                    if (Savegame.TryGetCity(city, out string CityTranslation))
                    {
                        cmbCitiesFrom.Items.Add(CityTranslation);
                        cmbCitiesTo.Items.Add(CityTranslation);
                    }
                    else
                    {
                        cmbCitiesFrom.Items.Add(String.Format("[{0}]NoDictionaryEntryFound",city.InternalName));
                        cmbCitiesTo.Items.Add(String.Format("[{0}]NoDictionaryEntryFound", city.InternalName));
                    }
                }
                cmbCitiesFrom.SelectedIndex = rand.Next(cmbCitiesFrom.Items.Count);
                cmbCitiesTo.SelectedIndex = rand.Next(cmbCitiesTo.Items.Count);


                // only add cargo that exists in the savefile
                // we need the existing to use the entries as template for the new job
                foreach(var item in Savegame.CargoList)
                {
                    cmbCargo.Items.Add(item.TranslatedName);
                }
                cmbCargo.SelectedIndex = rand.Next(cmbCargo.Items.Count);
                
                grpRoute.Enabled = true;
                grpTour.Enabled = true;
                MenuItemClearJobs.Enabled = true;

                if (Savegame.GameID == ScsDictionary.GameID.ETS)
                    lblGameID.Text = "Euro Truck Simulator 2";
                else
                    lblGameID.Text = "American Truck Simulator";

                frmMessage.Close();
            }
        }
        private void MenuItemSave_Click(object sender, EventArgs e)
        {
            CustomMessageBox frmMessage = new CustomMessageBox("Saving", "Speichere Savegame...", 12.0F);
            frmMessage.Show();
            Application.DoEvents();

            SiiStream siiStream = Savegame.Save();
            siiStream.WriteToFile(siiFileName);

            //Export new savegame to textfile for debugging
            if (Settings.Default.ExportSavegameToText)
            {
                DateTime dt = DateTime.Now;
                string fName = string.Format("_{0}{1}{2}_{3}{4}{5}", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
                siiStream.WriteToFile("D:\\Temp\\save" + fName + ".txt");
            }

            ListTouren.Items.Clear();
            MenuItemSave.Enabled = false;
            MenuItemSaveAs.Enabled = false;

            frmMessage.Close();
        }
        private void MenuItemSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Savegames (*.sii) |*.sii";

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                CustomMessageBox frmMessage = new CustomMessageBox("Saving", "Speichere Savegame...", 12.0F);
                frmMessage.Show();
                Application.DoEvents();

                SiiStream siiStream = Savegame.Save();
                siiStream.WriteToFile(sfd.FileName);

                ListTouren.Items.Clear();
                MenuItemSave.Enabled = false;
                MenuItemSaveAs.Enabled = false;

                frmMessage.Close();
            }
        }
        private void MenuItemSettings_Click(object sender, EventArgs e)
        {
            frmSettings Settings = new frmSettings();
            Settings.ShowDialog();
        }
        private void MenuItemGenerateDistances_Click(object sender, EventArgs e)
        {
            Savegame.UpdateDistances();
        }
        private void MenuItemMaps_Click(object sender, EventArgs e)
        {
            FrmMaps Maps = new FrmMaps(true);
            Maps.Show();
        }
        private void MenuItemLanguagefiles_Click(object sender, EventArgs e)
        {
            frmCityList frmCityList = new frmCityList(ScsDictionary.GameID.ETS);
            frmCityList.ShowDialog();
        }
        private void MenuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MenuItemJobClear_Click(object sender, EventArgs e)
        {
            Savegame.ClearJobs();

            //Export new savegame to textfile for debugging
            if (Settings.Default.ExportSavegameToText)
            {
                SiiStream tmpStream = Savegame.Save();
                tmpStream.WriteToFile(@"D:\Temp\jj.jj");
            }

            MessageBox.Show("Alle Jobs wurden erfolgreich gelöscht", "Erfolg");

            MenuItemSave.Enabled = true;
            MenuItemSaveAs.Enabled = true;
        }
        private void MenuItemSiiToJSON_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Savegames (*.sii) |*.sii";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                string StrKey, StrValue;
                List<string> list = new List<string>();
                list = File.ReadAllLines(ofd.FileName).ToList<string>();

                Dictionary<string, string> dict = new Dictionary<string, string>();

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Contains("key"))
                    {
                        StrKey = Tools.StringRemove(list[i],"key[]:","\"").Trim();
                        StrValue = Tools.StringRemove(list[i+1], "val[]:", "\"").Trim();
                        dict.Add(StrKey, StrValue);
                        i++;
                    }
                }
                LanguageGenerator.WriteToFileJSON(dict, Path.GetDirectoryName(ofd.FileName) + @"\user_localisation.txt");
                MessageBox.Show("Erstellung abgeschlossen","Abschluss", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Buttons
        private void BtnAddJob_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string CityFrom = Savegame.CityList[cmbCitiesFrom.SelectedIndex].InternalName;
            string CompanyFrom = Savegame.CityList[cmbCitiesFrom.SelectedIndex].Companies[cmbCompaniesFrom.SelectedIndex].InternalName;
            string CityTo = Savegame.CityList[cmbCitiesTo.SelectedIndex].InternalName;
            string CompanyTo = Savegame.CityList[cmbCitiesTo.SelectedIndex].Companies[cmbCompaniesTo.SelectedIndex].InternalName;
            string Cargo = Savegame.CargoList[cmbCargo.SelectedIndex].InternalName;

            //add job to savegame and return the distance between the cities if known
            string Dist = Savegame.AddJob(CityFrom, CompanyFrom, CityTo, CompanyTo, Cargo);

            ListViewItem listViewItem = new ListViewItem((ListTouren.Items.Count + 1).ToString());
            listViewItem.SubItems.Add(String.Format("{0} ({1})", cmbCitiesFrom.Text, cmbCompaniesFrom.Text));
            listViewItem.SubItems.Add(String.Format("{0} ({1})", cmbCitiesTo.Text, cmbCompaniesTo.Text));
            listViewItem.SubItems.Add(Savegame.CargoList[cmbCargo.SelectedIndex].TranslatedName);
            listViewItem.SubItems.Add(Dist);
            ListTouren.Items.Add(listViewItem);

            if (ListTouren.Items.Count > 0)
                lblNoJobs.Visible = false;

            int TmpCityIndex, TmpCompanyIndex;
            TmpCityIndex = cmbCitiesTo.SelectedIndex;
            TmpCompanyIndex = cmbCompaniesTo.SelectedIndex;
            cmbCitiesFrom.SelectedIndex = TmpCityIndex;
            cmbCompaniesFrom.SelectedIndex = TmpCompanyIndex;
            cmbCitiesTo.SelectedIndex = rnd.Next(0, cmbCitiesTo.Items.Count);
            cmbCompaniesTo.SelectedIndex = rnd.Next(0, cmbCompaniesTo.Items.Count);
            cmbCargo.SelectedIndex = rnd.Next(0, cmbCargo.Items.Count);

            MenuItemSave.Enabled = true;
            MenuItemSaveAs.Enabled = true;
        }
        #endregion

        #region DEBUGGING
        // DEBUGGING
        private void MenuItemDebugETS_Click(object sender, EventArgs e)
        {
            
        }
        private void MenuItemDebugATS_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Settings.Default.GameFilesPathATS);
            IHashFsReader hashFsReader = HashFsReader.Open(Settings.Default.GameFilesPathATS + @"\base.scs");
            hashFsReader.ExtractDirectoryListToFile("/", @"d:\temp\base.txt");
            MessageBox.Show("Done");
        }
        #endregion
    }
}