using ArtifactsAnalyzer;
using ArtifactsAnalyzer.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizaInternetArtifakata
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IChromeArtifactsAnalyzer chromeArtifactsAnalyzer = ArtifactsAnalyzerFactory.Create<IChromeArtifactsAnalyzer>();
            List<Tuple<string, string>> chromeCookieList = new List<Tuple<string, string>>();
            if (textBox1.Text != null && textBox1.Text != "")
            {
                chromeCookieList = chromeArtifactsAnalyzer.readHostCookies("path", textBox1.Text);
            }else
            {
                chromeCookieList = chromeArtifactsAnalyzer.readCookies("path");
            }
            
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = chromeCookieList;
            

        }
    }
}
