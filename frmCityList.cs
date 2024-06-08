using Language;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ScsDispatcher
{
    public partial class frmCityList : Form
    {
        public frmCityList(ScsDictionary.GameID ID)
        {
            InitializeComponent();
            
            ScsDictionary scsDictionary = new ScsDictionary();
            scsDictionary.Update(ID);
            var sortedDict = scsDictionary.Cities.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var item in sortedDict)
            {
                listView1.Items.Add(
                    new ListViewItem(new[] { item.Value, item.Key })
                    {
                        Tag = item.Key
                    });
            }
        }
    }
}
