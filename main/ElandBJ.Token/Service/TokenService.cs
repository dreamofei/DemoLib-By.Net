using ElandBJ.Token.Common;
using ElandBJ.Token.IService;
using ElandBJ.Token.Model;
using ElandBJ.Token.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ElandBJ.Token.Service
{
    public class TokenService:ITokenService
    {
        private const string _DIRECTORY = "ElandBJ.Token";
        private const string _PUBLICKEY = "PBK.EBJTK";
        private const string _PRIVATEKEY = "PVK.EBJTK";
        //title="userId & createTime & expiredDuration & 签名"

        /// <summary>
        /// 创建Token
        /// </summary>
        /// <param name="UserId">当前用户ID</param>
        /// <param name="expiredDuration">Token的有效时长（单位：分钟）</param>
        /// <returns>Token字符串</returns>
        public string CreateToken(string UserId , int expiredDuration)
        {
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strHashed = HashBuilder.GetHMACMD5Hash(UserId + timeStamp + expiredDuration.ToString());
            string concatData = UserId + "&" + timeStamp + "&" + expiredDuration.ToString() + "&" + strHashed;
            return CryptHelper.Encrypt(PublicKeyPath, concatData);
        }

        private string PublicKeyPath
        {
            get
            {
                string KeyDirectory = FileHelper.GetPath(_DIRECTORY);
                if (!Directory.Exists(KeyDirectory))
                {
                    Directory.CreateDirectory(KeyDirectory);
                    CryptHelper.CreateRSAKey(Path.Combine(KeyDirectory, _PRIVATEKEY), Path.Combine(KeyDirectory, _PUBLICKEY));
                }
                return Path.Combine(KeyDirectory, _PUBLICKEY);
            }
        }
        private string PrivateKeyPath
        {
            get
            {
                string KeyDirectory = FileHelper.GetPath(_DIRECTORY);
                return Path.Combine(KeyDirectory, _PRIVATEKEY);
            }
        }

        /// <summary>
        /// 校验Token
        /// </summary>
        /// <param name="token">待校验的Token字符串</param>
        /// <param name="userId">输出型参数，若校验通过值为userId，否则值为null</param>
        /// <returns>Token校验结果。Valid：校验通过； Invalid：不合法的Token，校验失败； Expired：过期的Token，校验失败</returns>
        public string CheckToken(string token , out string userId)
        {
            userId = null;
            //如果token长度不为256，肯定不合法
            if(token.Length!=256)
            {
                return TokenState.Invalid.ToString();
            }
            string realData = CryptHelper.Decrypt(PrivateKeyPath, token);
            //验证解密非空,否则token不合法
            if (string.IsNullOrEmpty(realData))
            {
                return TokenState.Invalid.ToString();
            }

            string[] splitData = realData.Split('&');
            //验证数字签名
            if (HashBuilder.GetHMACMD5Hash(splitData[0] + splitData[1] + splitData[2]).Equals(splitData[3]) == false)
            {
                return TokenState.Invalid.ToString();
            }

            //验证是否过期
            if (Convert.ToInt32((DateTime.Now - Convert.ToDateTime(splitData[1])).TotalMinutes) > Convert.ToInt32(splitData[2]))
            {
                return TokenState.Expired.ToString();
            }
            //到此验证通过
            userId = splitData[0];
            return TokenState.Valid.ToString();
        }
    }
}
