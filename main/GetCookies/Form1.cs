using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetCookies
{
    public partial class Form1 : Form
    {
        public string para;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.button1.Text = para;
            MessageBox.Show(para);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CookieContainer c = new CookieContainer();
            CookieCollection cc = c.GetCookies(new Uri("http://www.baidu.com"));
        }


        private const int INTERNET_COOKIE_HTTPONLY = 0x00002000;
        private const int INTERNET_COOKIE = 0x2000;
        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetGetCookieEx(
            string url,
            string cookieName,
            StringBuilder cookieData,
            ref int size,
            int flags,
            IntPtr pReserved);

        /// <summary>
        /// Returns cookie contents as a string
        /// </summary>
        /// <param name="url">http://***.***.****</param>
        /// <returns></returns>
        public static string GetCookie(string url,string CookieKey)
        {
            int size = 512;
            StringBuilder sb = new StringBuilder(size);
            if (!InternetGetCookieEx(url, CookieKey, sb, ref size, INTERNET_COOKIE, IntPtr.Zero))
            {
                if (size < 0)
                {
                    return null;
                }
                sb = new StringBuilder(size);
                if (!InternetGetCookieEx(url, CookieKey, sb, ref size, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero))
                {
                    return null;
                }
            }
            return sb.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s=GetCookie("http://www.baidu.com","BAIDUID");
            MessageBox.Show(s);
        }
    }
}
