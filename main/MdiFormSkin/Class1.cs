using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdiFormSkin
{
    public class DFDto
    {
        public Dictionary<string, int> xg;
        public Dictionary<string, int> ldnl;
        public Dictionary<string, int> q33;
        public Dictionary<string, int> qq44;
        public Dictionary<string, int> q55;
    }


    class kk
    {
        public void ff()
        {
            DFDto d1 = new DFDto();
            d1.xg.Add("wx", 20);
            d1.xg.Add("wx", 20);
            d1.xg.Add("wx", 20);
            d1.xg.Add("wx", 20);

            d1.q33.Add("", 0);
        }
    }
}
