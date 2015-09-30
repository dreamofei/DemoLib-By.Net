using ElandBJ.Token.Common;
using ElandBJ.Token.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ElandBJ.Token.Security
{
    public class CryptHelper
    {

        #region RSA
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

        #endregion

        #region AES

        private static string _key = "yytscdmy1#i!90%p";
        private static string _iv = "iyenckekl873k(h&";

        /// <summary>
        /// AES加密算法
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <returns>将加密后的密文转换为Base64编码，以便显示</returns>
        public static string AESEncrypt(string plainText)
        {
            //分组加密算法
            SymmetricAlgorithm des = Rijndael.Create();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(plainText);//得到需要加密的字节数组 
            //设置密钥及密钥向量
            des.Key = Encoding.UTF8.GetBytes(_key);
            des.IV = Encoding.UTF8.GetBytes(_iv);
            byte[] cipherBytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cipherBytes = ms.ToArray();//得到加密后的字节数组
                    cs.Close();
                    ms.Close();
                }
            }
            return Convert.ToBase64String(cipherBytes);
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="showText">密文字符串</param>
        /// <returns>返回解密后的明文字符串</returns>
        public static string AESDecrypt(string showText)
        {
            byte[] cipherText = Convert.FromBase64String(showText);
            SymmetricAlgorithm des = Rijndael.Create();
            des.Key = Encoding.UTF8.GetBytes(_key);
            des.IV = Encoding.UTF8.GetBytes(_iv);
            byte[] decryptBytes = new byte[cipherText.Length];
            using (MemoryStream ms = new MemoryStream(cipherText))
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    cs.Read(decryptBytes, 0, decryptBytes.Length);
                    cs.Close();
                    ms.Close();
                }
            }
            return Encoding.UTF8.GetString(decryptBytes).Replace("\0", "");   ///将字符串后尾的'\0'去掉
        }

        #endregion

    }
}
