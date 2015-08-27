using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Deployment.Application;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetCookies
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
            //NameValueCollection col = new NameValueCollection();
            //string queryString="";
            //if (ApplicationDeployment.IsNetworkDeployed)
            //{
            //    queryString = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
            //}
            //Form1 f = new Form1();
            //f.para = queryString;
            //Application.Run(f);

            Form1 f = new Form1();
            f.para = UAP.Support.Client.ClickonceHelper.GetTicket();
            Application.Run(f);
        }
    }
}
