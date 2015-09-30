using System;
using System.Collections.Generic;
using System.Text;

namespace ElandBJ.Token.Model
{
    /// <summary>
    /// 验证Token结果
    /// </summary>
    public enum TokenState
    {
        /// <summary>
        /// 表示错误的Token
        /// </summary>
        Invalid = 0,
        /// <summary>
        /// 表示过期的Token
        /// </summary>
        Expired = 1,
        /// <summary>
        /// 表示正确的Token
        /// </summary>
        Valid = 2
    }
}
