using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MdiFormSkin
{
    public partial class Form1:Form
    {
        MdiClient mclient;
        public Form1()
        {
            InitializeComponent();
            InitEvent();
        }

        void InitEvent()
        {
            this.MouseDoubleClick += Form1_MouseDoubleClick;
        }

        void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Text=sender.GetType().ToString();
            this.BackColor = Color.Red;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType().ToString() == "system.windows.forms.mdiclient")
                {
                    mclient = c as MdiClient;
                }
                c.MouseClick += c_MouseDoubleClick;
            }

            mclient.BackColor = Color.Yellow;
        }

        void c_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Text = sender.GetType().ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
