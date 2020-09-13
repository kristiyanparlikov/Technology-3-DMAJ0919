//
// Microsoft documentation to the rescue
// https://docs.microsoft.com/en-us/dotnet/api/system?view=netframework-4.8
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tbText_TextChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in tbText.Text.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            tbBinary.Text = sb.ToString();
            tbBinary.Update();
        }

        private void tbBinary_TextChanged(object sender, EventArgs e)
        {
            int length8 = (tbBinary.Text.Length / 8) * 8;
            if (length8 > 0)
            {
                List<byte> byteList = new List<Byte>();
                for (int i = 0; i < length8; i += 8)
                {
                    byteList.Add(Convert.ToByte(tbBinary.Text.Substring(i, 8), 2));
                }
                tbText.Text = Encoding.ASCII.GetString(byteList.ToArray());
                tbText.Update();
            }
        }
    }
}
