using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;


namespace ldapSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            toolStripStatusLabel1.Text = "Ready For Query";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Searching...";
            Application.DoEvents();

            string un = textBox1.Text;
            string directoryServer = textBox4.Text;
            string scheme = comboBox1.Text;
            string dirserv = scheme + directoryServer;

            DirectoryEntry RootEntry = new DirectoryEntry(dirserv);
            RootEntry.AuthenticationType = AuthenticationTypes.None;
            DirectorySearcher searcher = new DirectorySearcher(RootEntry);

            searcher.Filter = string.Format("(SAMAccountName={0})", un);
            searcher.PropertiesToLoad.Add("cn");
            searcher.PropertiesToLoad.Add("distinguishedname");

            try
            {
                var results = searcher.FindOne();
                textBox2.Text = results.Properties["cn"][0].ToString();
                textBox3.Text = results.Properties["distinguishedname"][0].ToString();
                toolStripStatusLabel1.Text = "Done";
            }
            catch (Exception oops)
            {
                toolStripStatusLabel1.Text = "Error: Could not search";
            }
            Application.DoEvents();

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            statusStrip1.Refresh();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
