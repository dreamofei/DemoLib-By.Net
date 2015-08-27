using DemoLib.Security.FW4._5.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.Security.FW4._5.Hash
{
    public class HashBuilder
    {
        public static string GetHMACMD5Hash(string strData)
        {
            HMACMD5 md5 = new HMACMD5(Encoding.UTF8.GetBytes(strData));
            byte[] dataHashed= md5.ComputeHash(Encoding.UTF8.GetBytes(strData));
            return CommonHelper.ByteArrayToString(dataHashed);
        }

        public static string GetMD5Hash(string strData)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dataHashed = md5.ComputeHash(Encoding.UTF8.GetBytes(strData));
            return BitConverter.ToString(dataHashed);
        }

        public static string GetMD5Hash2(string strData)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dataHashed = md5.ComputeHash(Encoding.UTF8.GetBytes(strData));
            return CommonHelper.ByteArrayToString(dataHashed);
        }
    }
}
