using ScsDispatcher.Properties;
using Ookii.Dialogs.WinForms;
using System;
using System.Windows.Forms;

namespace ScsDispatcher
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void OpenFolder(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            bool IsETS = false;
            if (btn.Name.Contains("ETS"))
                IsETS = true;
            
            VistaFolderBrowserDialog ofd = new VistaFolderBrowserDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                if (IsETS)
                    TxtPathETS.Text = ofd.SelectedPath;
                else
                    TxtPathATS.Text = ofd.SelectedPath;
            }
        }

        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.GameFilesPathETS = TxtPathETS.Text;
            Settings.Default.GameFilesPathATS = TxtPathATS.Text;
            Settings.Default.AutoDistanceLearning = cbAutoLearn.Checked;
            Settings.Default.IgnoreTranslation = cbIgnoreTranslation.Checked;
            Settings.Default.DefaultJobLength = Convert.ToInt32(TxtDefaultJobLength.Text);
            Settings.Default.ExportSavegameToText = cbExportSavegameToText.Checked;
            Settings.Default.Save();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            TxtPathETS.Text = Settings.Default.GameFilesPathETS;
            TxtPathATS.Text = Settings.Default.GameFilesPathATS;
            TxtDefaultJobLength.Text = Settings.Default.DefaultJobLength.ToString();
            cbAutoLearn.Checked = Settings.Default.AutoDistanceLearning;
            cbIgnoreTranslation.Checked = Settings.Default.IgnoreTranslation;
            cbExportSavegameToText.Checked = Settings.Default.ExportSavegameToText;
        }
    }
}
