using Quartz;
using System;
using System.Collections.Generic;
using System.Text;

namespace springNetQuartz
{
    public class EmailManger:IJob
    {
        public void Execute(JobExecutionContext context)
        {
            Console.WriteLine("发邮件了...");
        }
    }
}
