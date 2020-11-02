using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebClient_4
{
    public partial class Form1 : Form
    {
        string thePostURL = "http://ptsv2.com/t/jr7ky-1554744275/post";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (HttpClient myClient = new HttpClient())
            {

            }


        }

        async static void myGetRequest(string url, TextBox theHeaderBox, TextBox theTextBox)
        {
            using (HttpClient myClient = new HttpClient())
            {

                using (HttpResponseMessage myResponse = await myClient.GetAsync(url))
                {
                    using (HttpContent myContent = myResponse.Content)
                    {
                        theTextBox.Text = await myContent.ReadAsStringAsync();
                        HttpContentHeaders myHeader = myContent.Headers;
                        theHeaderBox.Text = myHeader.ToString();
                    }

                }
            }

        }
        async static void myPostRequest(string url, TextBox theHeaderBox, TextBox theTextBox)
        {
            // use http://ptsv2.com/
            IEnumerable<KeyValuePair<string, string>> myQueries = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("theQuery1", "theArgument1"),
                new KeyValuePair<string, string>("theQuery2", "theArgument2"),
            };
            HttpContent myQuery = new FormUrlEncodedContent(myQueries);
            using (HttpClient myClient = new HttpClient())
            {

                using (HttpResponseMessage myResponse = await myClient.PostAsync(url, myQuery))
                {
                    using (HttpContent myContent = myResponse.Content)
                    {
                        theTextBox.Text = await myContent.ReadAsStringAsync();
                        HttpContentHeaders myHeader = myContent.Headers;
                        theHeaderBox.Text = myHeader.ToString();
                    }

                }
            }

        }

        private void btSendRequest_Click(object sender, EventArgs e)
        {
            myPostRequest(tbURL.Text, tbHeader, tbBody);
        }
    }
}
