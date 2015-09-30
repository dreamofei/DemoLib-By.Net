using System;
using System.Collections.Generic;
using System.Text;

namespace ElandBJ.Token.Common
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
