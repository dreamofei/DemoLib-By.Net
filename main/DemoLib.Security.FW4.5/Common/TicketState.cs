using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.Security.FW4._5.Common
{
    /// <summary>
    /// 验证ticket结果
    /// </summary>
    public enum TicketState
    {
        /// <summary>
        /// 表示错误的ticket
        /// </summary>
        Invalid=0,
        /// <summary>
        /// 表示过期的ticket
        /// </summary>
        Expired=1,
        /// <summary>
        /// 表示正确的ticket
        /// </summary>
        Valid=2
    }
}
