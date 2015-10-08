using ElandBJ.ScheduledJob.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testRemote
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmailManager em= Spring.Context.Support.ContextRegistry.GetContext().GetObject("RemoteEmailManager") as IEmailManager;
            em.AddTrigger("0/2 * * * * ?", "test");
        }
    }
}
