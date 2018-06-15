using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using CaiJiClient.Models;
using CaiJiClient.Repositories;

namespace CaiJiClient
{
    public partial class Form1 : Form
    {
        private string Host = ConfigurationManager.AppSettings["ServerHost"].ToString();

        public Form1()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            var username = UserName.Text;
            var userpwd = UserPassword.Text;

            string url = Host + "User/Login?username=" + username + "&userpwd=" + userpwd;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            var responseText = reader.ReadToEnd();
            reader.Close();
            dynamic responseObj = CaiJi.Utils.Converter.JsonDynamic.ToDynamic(responseText);
            if (responseObj.Status == 1)
            {
                var access_token = responseObj.Result.access_token;
                UserRepository userRepository = new UserRepository(new CaiJiDB());
                int result = userRepository.Add(new User
                {
                    AccessToken = access_token,
                    Name = username,
                    Password = userpwd
                });
                if (result > 0)
                    this.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("请重试");
            }
        }
    }
}
