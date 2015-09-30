using AopAlliance.Intercept;
using Common.Logging;
using Log.Dto;
using Log.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log.Advice
{
    public class LogAdvice : IMethodInterceptor
    {
        ILog _log = LogManager.GetLogger(typeof(LogAdvice));
        public object Invoke(IMethodInvocation invocation)
        {
            LogDto log=new LogDto();
            log.ObjName = invocation.Target.ToString();
            log.MethodName = invocation.Method.Name;
            log.CalledTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.CalledUser = Context.Current["userName"].ToString();
            LogHelper.logToFile(log);
            _log.Info(string.Format("AOP:对象{0}，方法名{1}",log.ObjName,log.MethodName));
            return invocation.Proceed();
        }
    }
}
