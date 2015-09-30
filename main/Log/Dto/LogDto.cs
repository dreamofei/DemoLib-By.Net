using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log.Dto
{
    [Serializable]
    public class LogDto
    {
        public string ObjName { get; set; }
        public string MethodName { get; set; }
        public string CalledTime { get; set; }
        public string CalledUser { get; set; }
    }
}
