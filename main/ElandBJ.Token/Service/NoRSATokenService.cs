using ElandBJ.Token.IService;
using ElandBJ.Token.Model;
using ElandBJ.Token.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElandBJ.Token.Service
{
    public class NoRSATokenService:ITokenService
    {

        //title="userId & createTime & expiredDuration & 签名"

        /// <summary>
        /// 创建Token
        /// </summary>
        /// <param name="UserId">当前用户ID</param>
        /// <param name="expiredDuration">Token的有效时长（单位：分钟）</param>
        /// <returns>Token字符串</returns>
        public string CreateToken(string UserId, int expiredDuration)
        {
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strHashed = HashBuilder.GetHMACMD5Hash(UserId + timeStamp + expiredDuration.ToString());
            string concatData = UserId + "&" + timeStamp + "&" + expiredDuration.ToString() + "&" + strHashed;
            return CryptHelper.AESEncrypt(concatData);
        }

        /// <summary>
        /// 校验Token
        /// </summary>
        /// <param name="token">待校验的Token字符串</param>
        /// <param name="userId">输出型参数，若校验通过值为userId，否则值为null</param>
        /// <returns>Token校验结果。Valid：校验通过； Invalid：不合法的Token，校验失败； Expired：过期的Token，校验失败</returns>
        public string CheckToken(string token, out string userId)
        {
            userId = null;
            //base64编码后4的倍数长度，AES加密长度大于24位
            if (token.Length % 4 != 0 || token.Length < 24) 
            {
                return TokenState.Invalid.ToString();
            }
            string realData = CryptHelper.AESDecrypt(token);
            //验证解密非空,否则token不合法
            if (string.IsNullOrEmpty(realData))
            {
                return TokenState.Invalid.ToString();
            }

            string[] splitData = realData.Split('&');
            //如果按照&拆分后不是4个部分，肯定被篡改了
            if(splitData.Length!=4)
            {
                return TokenState.Invalid.ToString();
            }
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
