using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WebClient_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string myUser = tbUserName.Text;
                string myPass = tbPassword.Text;

                ASCIIEncoding myEncoder = new ASCIIEncoding();
                string myPostData = "user=" + myUser + "&pass=" + myPass;

                byte[] myData = myEncoder.GetBytes(myPostData);

                WebRequest myWebRequest = HttpWebRequest.Create("http://webclient.fenris.ucn.dk/webclient3.cgi");
                myWebRequest.Method = "POST";
                myWebRequest.ContentType = "application/x-www-form-urlencoded";
                myWebRequest.ContentLength = myData.Length;

                Stream myStream = myWebRequest.GetRequestStream();
                myStream.Write(myData, 0, myData.Length);
                myStream.Close();

                WebResponse myWebResponse = myWebRequest.GetResponse();
                myStream = myWebResponse.GetResponseStream();

                StreamReader myStreamReader = new StreamReader(myStream);
                MessageBox.Show(myStreamReader.ReadToEnd());

                myStreamReader.Close();
                myStream.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
