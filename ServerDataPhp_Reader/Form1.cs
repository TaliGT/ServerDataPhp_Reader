using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerDataPhp_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lel = "";
            Random a = new Random();
            int b = a.Next(1, 3);
            if (b == 1)
            {
                lel = "growtopia1.com";
            }
            else if (b == 2)
            {
                lel = "growtopia2.com";
            }
            else
            {
                lel = "Unknown";
            }
            string ip = textBox1.Text;
            var url = "http://" + ip + "/growtopia/server_data.php";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Headers["Accept"] = "*/*";
            httpRequest.Headers["Host"] = lel;
            httpRequest.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            httpRequest.Headers["content-length"] = "38";
            httpRequest.Headers["user-agent"] = "";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                MessageBox.Show(result.ToString());
            }

        }
    }
}
