using System;
using System.Collections.Generic;
using System.Text;

namespace ElandBJ.Token.IService
{
    public interface ITokenService
    {
        /// <summary>
        /// 创建Token
        /// </summary>
        /// <param name="UserId">当前用户ID</param>
        /// <param name="expiredDuration">Token的有效时长（单位：分钟）</param>
        /// <returns>Token字符串</returns>
        string CreateToken(string UserId, int expiredDuration);

        /// <summary>
        /// 校验Token
        /// </summary>
        /// <param name="token">待校验的Token字符串</param>
        /// <param name="userId">输出型参数，若校验通过值为userId，否则值为null</param>
        /// <returns>Token校验结果。Valid：校验通过； Invalid：不合法的Token，校验失败； Expired：过期的Token，校验失败</returns>
        string CheckToken(string token, out string userId);
    }
}
