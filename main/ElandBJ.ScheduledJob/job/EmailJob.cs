using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElandBJ.ScheduledJob.job
{
    public class EmailJob:IJob
    {
        public void Execute(JobExecutionContext context)
        {
            //实际：调用发送邮件的方法
            Console.WriteLine("发邮件了...");
        }
    }
}
