using DemoLib.Security.FW4._5.Common;
using DemoLib.Security.FW4._5.Crypt;
using DemoLib.Security.FW4._5.Hash;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.Security.FW4._5.Ticket
{
    public class TicketHelper
    {
        private const string _DIRECTORY = "UAP";
        private const string _PUBLICKEY = "PBK.UAP";
        private const string _PRIVATEKEY = "PVK.UAP";
        //title="userId : clientIp : createTime : expiredDuration : 签名"
        public static string CreateTicket(string UserId, string clientIP, int expiredDuration)
        {
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strHashed = HashBuilder.GetHMACMD5Hash(UserId + clientIP + timeStamp + expiredDuration.ToString());
            string concatData = UserId + "&" + clientIP + "&" + timeStamp + "&" + expiredDuration.ToString() + "&" + strHashed;
            return Crypt.CryptHelper.Encrypt(PublicKeyPath, concatData);
        }

        public static string PublicKeyPath
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
        public static string PrivateKeyPath
        {
            get
            {
                string KeyDirectory = FileHelper.GetPath(_DIRECTORY);
                return Path.Combine(KeyDirectory, _PRIVATEKEY);
            }
        }

        public static TicketState CheckTicket(string ticket, string clientIp, out string userId)
        {
            userId = null;
            string realData = CryptHelper.Decrypt(PrivateKeyPath, ticket);
            //验证解密非空
            if (string.IsNullOrEmpty(realData))
            {
                return TicketState.Invalid;
            }

            string[] splitData = realData.Split('&');
            //验证数字签名
            if (HashBuilder.GetHMACMD5Hash(splitData[0] + splitData[1] + splitData[2] + splitData[3]).Equals(splitData[4]) == false)
            {
                return TicketState.Invalid;
            }
            //验证ip
            if (splitData[1].Equals(clientIp) == false)
            {
                return TicketState.Invalid;
            }
            //验证是否过期
            if (Convert.ToInt32((DateTime.Now - Convert.ToDateTime(splitData[2])).TotalMinutes) > Convert.ToInt32(splitData[3]))
            {
                return TicketState.Expired;
            }
            //到此验证通过
            userId = splitData[0];
            return TicketState.Valid;
        }
    }
}
