using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace CaiJi.Client
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void TestCaiJi_Click(object sender, EventArgs e)
        {
            string startUrl = StartUrl.Text;
            string Host = "";
            var html = CaiJi.Utils.Requester.Get.ResponseToString(startUrl, out Host);
            if (html == null)
            {
                MessageBox.Show("采集失败，请确保该网址有效");
                return;
            }
            string startMark = StartFrom.Text;
            string endMark = EndTo.Text;
            if (!String.IsNullOrEmpty(startMark))
            {
                int position1, position2;
                position1 = html.IndexOf(startMark, StringComparison.OrdinalIgnoreCase);
                if (position1 > -1)
                {
                    position2 = html.IndexOf(endMark, position1 + startMark.Length, StringComparison.OrdinalIgnoreCase);
                    if (position2 > -1)
                    {
                        html = html.Substring(position1 + startMark.Length, position2 - position1 - startMark.Length);
                    }
                }
            }
            string result = "";
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            string xpath = "//a";
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(xpath);
            if (nodes != null)
            {
                foreach (var item in nodes)
                {
                    try
                    {
                        string href = item.Attributes["href"].Value;
                        if (!String.IsNullOrEmpty(Include.Text))
                        {
                            if (!href.Contains(Include.Text))
                            {
                                continue;
                            }
                        }
                        if (!String.IsNullOrEmpty(Exclude.Text))
                        {
                            if (href.Contains(Exclude.Text))
                            {
                                continue;
                            }
                        }
                        if (href.Length < Host.Length)
                        {
                            href = Host + href;
                        }
                        else
                        {
                            if(href.Substring(0,href.Length)!= Host)
                            {
                                href = Host + href;
                            }
                        }
                        result += href + "\r\n";
                        listBox1.Items.Add(href);
                    }
                    catch { }
                }
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selectedvalue = listBox1.SelectedItem.ToString();
            tabControl1.SelectTab(1);
            textBox1.Text = selectedvalue;
        }

        /// <summary>
        /// 采集内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string startUrl = textBox1.Text;
            string Host = "";
            var html = CaiJi.Utils.Requester.Get.ResponseToString(startUrl, out Host);
            if (html == null)
            {
                MessageBox.Show("采集失败，请确保该网址有效");
                return;
            }
            string startMark = textBox2.Text;
            string endMark = textBox3.Text;
            if (!String.IsNullOrEmpty(startMark))
            {
                int position1, position2;
                position1 = html.IndexOf(startMark, StringComparison.OrdinalIgnoreCase);
                if (position1 > -1)
                {
                    position2 = html.IndexOf(endMark, position1 + startMark.Length, StringComparison.OrdinalIgnoreCase);
                    if (position2 > -1)
                    {
                        html = html.Substring(position1 + startMark.Length, position2 - position1 - startMark.Length);
                    }
                }
            }
            textBox4.Text = html.Trim();
        }
    }
}
