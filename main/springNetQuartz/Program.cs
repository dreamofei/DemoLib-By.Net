using Quartz;
using Quartz.Impl;
using Spring.Scheduling.Quartz;
using System;
using System.Collections.Generic;
using System.Text;

namespace springNetQuartz
{
    class Program
    {
        static void Main(string[] args)
        {
            ISchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = factory.GetScheduler();
            scheduler.Start();

            JobDetail job = new JobDetail("firstJob", typeof(EmailManger));

            //Trigger trigger = TriggerUtils.MakeSecondlyTrigger(5);
            //trigger.StartTimeUtc = TriggerUtils.GetEvenSecondDate(DateTime.UtcNow);
            //trigger.Name = "EmailSender";

            //scheduler.ScheduleJob(job, trigger);

            CronTrigger ctrigger = new CronTrigger();
            //ctrigger.StartTimeUtc = TriggerUtils.GetEvenSecondDate(DateTime.UtcNow);
            ctrigger.CronExpressionString = "0/2 * * * * ?";
            ctrigger.Name = "tt";
            ctrigger.Group = "default";

            scheduler.ScheduleJob(job, ctrigger);

            while (true)
            {
                string newJob = Console.ReadLine();
                if (newJob == "Y")
                {
                    scheduler.UnscheduleJob("tt", "default");
                }
            }

            #region MyRegion

            //while(true)
            //{
            //    string newJob = Console.ReadLine();
            //    if(newJob=="Y")
            //    {
            //        JobDetail job2 = new JobDetail("firstJob2", typeof(EmailManger));

            //        Trigger trigger2 = TriggerUtils.MakeSecondlyTrigger(2);
            //        trigger2.StartTimeUtc = TriggerUtils.GetEvenSecondDate(DateTime.UtcNow);
            //        trigger2.Name = "EmailSender2";

            //        scheduler.ScheduleJob(job2, trigger2);
            //    }
            //}

            //-------------------
            //Trigger tr = TriggerUtils.MakeDailyTrigger(14, 41);
            //tr.StartTimeUtc = TriggerUtils.GetEvenSecondDate(DateTime.UtcNow);
            //tr.Name = "EmailSender" + DateTime.Now.ToString();

            //scheduler.ScheduleJob(job,tr);
            //scheduler.GetTrigger("","").
            #endregion

            //SchedulerFactoryObject sfactory = new SchedulerFactoryObject();

            //MethodInvokingJobDetailFactoryObject sjob = new MethodInvokingJobDetailFactoryObject();

            //CronTriggerObject

        }
    }
}
