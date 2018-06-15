using CaiJi.Client.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaiJi.Client
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 login = new Form1();
            UserRepository userRepository = new UserRepository(new Models.CaiJiDB());
            if (userRepository.GetLast() != null)
            {
                Application.Run(new Form2());
            }
            login.ShowDialog();
            if (login.DialogResult == DialogResult.OK)
            {
                Application.Run(new Form2());
            }
            else
            {
                return;
            }
        }
    }
}
