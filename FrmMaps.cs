using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ScsDispatcher
{
    public partial class FrmMaps : Form
    {
        private List<MapPicture> MapPictures = new List<MapPicture>();

        private class MapPicture
        {
            public string FullName { get; internal set; }
            public string FileName { get; internal set; }
            public Image Image { get; internal set; }
            public MapPicture(string FullName)
            {
                this.FullName = FullName;
                this.Image = Image.FromFile(FullName);
                FileName = Path.GetFileNameWithoutExtension(FullName);
            }
        }
        public FrmMaps(bool StartMaximized)
        {
            InitializeComponent();

            if(StartMaximized)
                this.WindowState = FormWindowState.Maximized;
        }
        private void FrmMaps_Load(object sender, EventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(Application.StartupPath + "\\" + Properties.Resources.MapFolder);
            foreach (var file in directory.GetFiles())
            {
                MapPicture item = new MapPicture(file.FullName);
                MapPictures.Add(item);
                CmbMap.Items.Add(item.FileName);
            }

            if (CmbMap.Items.Count > 0)
                CmbMap.SelectedIndex = 0;
        }
        private void FrmMaps_SizeChanged(object sender, EventArgs e)
        {
            Size NewSize = new Size(this.Size.Width - 40, this.Size.Height);
            CmbMap.Size = NewSize;

            NewSize = new Size(this.Size.Width - 40,this.Size.Height - 100);
            MapPictureBox.Size = NewSize;
        }
        private void CmbMap_SelectedValueChanged(object sender, EventArgs e)
        {
            if (MapPictures[CmbMap.SelectedIndex].Image.Width > MapPictureBox.Width ||
                MapPictures[CmbMap.SelectedIndex].Image.Height > MapPictureBox.Height)
                MapPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            else
                MapPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;

            MapPictureBox.Image = MapPictures[CmbMap.SelectedIndex].Image;
        }
    }
}
