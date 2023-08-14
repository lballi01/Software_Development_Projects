using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Antivirus__Basic_
{
    public partial class Text : Form
    {
        public Text()
        {
            InitializeComponent();
        }

        public string GetMD5FromFile(string filenPath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filenPath))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var md5signatures = File.ReadAllLines("MD5base.txt");
            if (md5signatures.Contains(tbMD5.Text))
            {
                lblStatus.Text = "Infected!!!";
                lblStatus.ForeColor = Color.Red;
            }

            else
            {
                lblStatus.Text = "Clean!!!";
                lblStatus.ForeColor = Color.Green;
            }
                
        }

        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Textfiles | *.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbMD5.Text = GetMD5FromFile(ofd.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
