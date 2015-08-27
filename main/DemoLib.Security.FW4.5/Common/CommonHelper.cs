using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.Security.FW4._5.Common
{
    public class CommonHelper
    {
        public static string ByteArrayToString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in bytes)
            {
                sb.Append(item.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
