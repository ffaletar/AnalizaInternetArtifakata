using ArtifactsAnalyzer;
using ArtifactsAnalyzer.Data;
using ArtifactsAnalyzer.Factories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrlHistoryLibrary;

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
            //IChromeArtifactsAnalyzer chromeArtifactsAnalyzer = ArtifactsAnalyzerFactory.Create<IChromeArtifactsAnalyzer>();
            //List<Tuple<string, string>> chromeCookieList = new List<Tuple<string, string>>();
            //if (textBox1.Text != null && textBox1.Text != "")
            //{
            //    chromeCookieList = chromeArtifactsAnalyzer.readHostCookies("path", textBox1.Text);
            //} else
            //{
            //    chromeCookieList = chromeArtifactsAnalyzer.readCookies("path");
            //}

            //dataGridView1.ReadOnly = true;
            //dataGridView1.DataSource = chromeCookieList;

            IChromeArtifactsAnalyzer chromeArtifactsAnalyzer = ArtifactsAnalyzerFactory.Create<IChromeArtifactsAnalyzer>();
            List<HistoryItem> chromeHistory = new List<HistoryItem>();
            chromeHistory = chromeArtifactsAnalyzer.readFile();


            dataGridView1.DataSource = chromeHistory;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IInternetExplorerArtifactsAnalyzer explorerArtifactsAnalyzer = ArtifactsAnalyzerFactory.Create<IInternetExplorerArtifactsAnalyzer>();
            List<Tuple<string, string>> explorerList = new List<Tuple<string, string>>();

            explorerList = explorerArtifactsAnalyzer.readFile();

            dataGridView1.DataSource = explorerList;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IFirefoxArtifactsAnalyzer firefoxArtifactsAnalyzer = ArtifactsAnalyzerFactory.Create<IFirefoxArtifactsAnalyzer>();
            List<HistoryItem> explorerList = new List<HistoryItem>();

            explorerList = firefoxArtifactsAnalyzer.readFile();

            dataGridView1.DataSource = explorerList;
        }
    }
}
