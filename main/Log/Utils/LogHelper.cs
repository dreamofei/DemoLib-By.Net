using Log.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Log.Utils
{
    public class LogHelper
    {
        public static void logToFile(LogDto log)
        {
            string logFilePath = AppDomain.CurrentDomain.BaseDirectory+"//log.txt";
            if (!File.Exists(logFilePath))
            {
                File.Create(logFilePath);
            }
            StreamWriter sw = new StreamWriter(logFilePath, true, Encoding.Default);
            //FileStream fs = new FileStream(logFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            //StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("时间：{0} 用户：{1} 调用对象：{2} 的方法：{3}", log.CalledTime, log.CalledUser, log.ObjName, log.MethodName);
            //fs.Close();
            sw.Close();

        }
    }
}
