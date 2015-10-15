using ElandBJ.ScheduledJob.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace testRemote
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmailManager em= Spring.Context.Support.ContextRegistry.GetContext().GetObject("RemoteEmailManager") as IEmailManager;
            em.AddTrigger("0/2 * * * * ?", "test");
            Console.WriteLine("test 已经添加");

            Thread.Sleep(6000);

            em.RemoveTrigger("test");
            Console.WriteLine("test 已经移除");

            Console.ReadKey();


        }
    }
}
