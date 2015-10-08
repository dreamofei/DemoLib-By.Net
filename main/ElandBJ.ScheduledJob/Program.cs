using ElandBJ.ScheduledJob.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace ElandBJ.ScheduledJob
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        //static void Main()
        //{
        //    ServiceBase[] ServicesToRun;
        //    ServicesToRun = new ServiceBase[] 
        //    { 
        //        new EmailService() 
        //    };
        //    ServiceBase.Run(ServicesToRun);
        //}

        static void Main(string[] args)
        {
            Spring.Context.Support.ContextRegistry.GetContext();
            Console.WriteLine("服务启动...");
            //WriteTimer.Start();
            (Spring.Context.Support.ContextRegistry.GetContext().GetObject("EmailManager") as ElandBJ.ScheduledJob.api.IEmailManager).InitEmailScheduler();
            Console.WriteLine("启动成功");
            Console.ReadKey();
        }
    }
}
