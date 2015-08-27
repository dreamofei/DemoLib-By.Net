using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using WindowsService1.Task;

namespace WindowsService1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new Service1() 
            };
            ServiceBase.Run(ServicesToRun);
        }

        //static void Main()
        //{
        //    Console.WriteLine("服务启动...");
        //    WriteTimer.Start();
        //    Console.WriteLine("启动成功");
        //    Console.ReadKey();
        //}
    }
}
