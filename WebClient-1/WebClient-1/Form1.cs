using System;
using System.Net;
using System.Windows.Forms;

namespace WebClient_1
{
    public partial class FortuneCookie : Form
    {
        public FortuneCookie()
        {
            InitializeComponent();
        }

        private void FortuneCookie_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            tbFortune.Text = wc.DownloadString("http://webclient.fenris.ucn.dk/webclient1.txt");
        }
    }
}
