using System.Windows.Forms;
using System.Drawing;

namespace CustomForms
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(string Caption, string Message)
        {
            InitializeComponent();
            lblMessage.Text = Message;
            this.Text = Caption;
        }
        public CustomMessageBox(string Caption, string Message, float FontSize)
        {
            InitializeComponent();
            lblMessage.Font = new Font(FontFamily.GenericSansSerif, FontSize, FontStyle.Regular);
            lblMessage.Text = Message;
            this.Text = Caption;
        }
        public CustomMessageBox(string Caption, string Message, float FontSize, Color FontColor)
        {
            InitializeComponent();
            lblMessage.Font = new Font(FontFamily.GenericSansSerif, FontSize, FontStyle.Regular);
            lblMessage.ForeColor = FontColor;
            lblMessage.Text = Message;
            this.Text = Caption;
        }
    }
}
