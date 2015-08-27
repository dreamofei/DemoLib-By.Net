using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.Security.FW4._5.Common
{
    [Serializable]
    public class KeysDto
    {
        public string PrivateKey { get; set; }
        public string PublichKey { get; set; }
    }
}
