using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DemoLib.Security.FW4._5.Common;

namespace DemoLib.Security.FW4._5.Crypt
{
    public class CryptHelper
    {
        private static KeysDto GetRSAKey()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            return new KeysDto()
            {
                PrivateKey = rsa.ToXmlString(true),
                PublichKey = rsa.ToXmlString(false)
            };
        }

        public static void CreateRSAKey(string privateKeyPath, string publicKeyPath)
        {
            KeysDto keys = GetRSAKey();
            FileHelper.CreateFile(privateKeyPath, keys.PrivateKey);
            FileHelper.CreateFile(publicKeyPath, keys.PublichKey);
        }

        /// <summary>
        /// 公钥加密
        /// </summary>
        /// <param name="publichKey"></param>
        /// <param name="strData"></param>
        public static string EncryptRSA(string publicKey, string strData)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);
            byte[] dataRSAed = rsa.Encrypt(Encoding.UTF8.GetBytes(strData), false);
            return CommonHelper.ByteArrayToString(dataRSAed);
        }

        public static string DecryptRSA(string privateKey, string strData)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);
            byte[] bytes = new byte[128];
            for (int i = 0; i < 256; i = i + 2)
            {
                bytes[i / 2] = Convert.ToByte(strData.Substring(i, 2), 16);
            }
            byte[] dataRSAed;
            try
            {
                dataRSAed = rsa.Decrypt(bytes, false);
            }
            catch
            {
                return null;
            }
            return Encoding.ASCII.GetString(dataRSAed);
        }

        public static string Encrypt(string publicKeyPath, string strData)
        {
            return EncryptRSA(FileHelper.ReadFile(publicKeyPath), strData);
        }

        public static string Decrypt(string privateKeyPath, string strData)
        {
            return DecryptRSA(FileHelper.ReadFile(privateKeyPath), strData);
        }

    }
}
