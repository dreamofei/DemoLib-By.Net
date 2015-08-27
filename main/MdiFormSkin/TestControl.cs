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
    public partial class TestControl : Form
    {
        public TestControl()
        {
            InitializeComponent();
        }

        private void TestControl_Load(object sender, EventArgs e)
        {
            List<NameObject> l = new List<NameObject>() { 
                new NameObject{c1="1",c2="2",c3="3"},
                new NameObject{c1="11",c2="22",c3="33"},
                new NameObject{c1="111",c2="222",c3="3333"},
                new NameObject{c1="1111",c2="22222",c3="33333"},
                new NameObject{c1="111111",c2="222222",c3="333333"},
            };
            this.lookUpEdit1.Properties.DataSource = l;
            this.searchLookUpEdit1.Properties.DataSource = l;
        }
    }
    public class NameObject
    {
        public string c1 { get; set; }
        public string c2 { get; set; }
        public string c3 { get; set; }
    }
}
