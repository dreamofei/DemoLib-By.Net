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
            job.Durable = true;

            scheduler.AddJob(job, false);

            //Trigger trigger = TriggerUtils.MakeSecondlyTrigger(5);
            //trigger.StartTimeUtc = TriggerUtils.GetEvenSecondDate(DateTime.UtcNow);
            //trigger.Name = "EmailSender";

            //scheduler.ScheduleJob(job, trigger);

            CronTrigger ctrigger = new CronTrigger();
            //ctrigger.StartTimeUtc = TriggerUtils.GetEvenSecondDate(DateTime.UtcNow);
            //ctrigger.CronExpressionString = "0/6 * * * * ?";
            ctrigger.CronExpressionString = "0 0 2 ? * SUN";
            ctrigger.Name = "tt";
            ctrigger.Group = "default";
            ctrigger.JobName = "firstJob";

            //JobDetail job2 = new JobDetail("firstJob2", typeof(EmailManger));

            CronTrigger ctrigger2 = new CronTrigger();
            //ctrigger.StartTimeUtc = TriggerUtils.GetEvenSecondDate(DateTime.UtcNow);
            ctrigger2.CronExpressionString = "0/2 * * * * ?";
            ctrigger2.Name = "tt2";
            ctrigger2.Group = "default";
            ctrigger2.JobName = "firstJob";
            //ctrigger2.JobGroup = "";

            scheduler.ScheduleJob(ctrigger);
            //scheduler.ScheduleJob(ctrigger2);
            //scheduler.ScheduleJob(job2, ctrigger2);

            while (true)
            {
                string newJob = Console.ReadLine();
                if (newJob == "Y")
                {

                    CronTrigger oldTrigger=(scheduler.GetTrigger("tt", "default") as CronTrigger);
                    CronTrigger newTrigger = (CronTrigger)oldTrigger;
                    newTrigger.CronExpressionString = "0/5 * * * * ?";
                    //scheduler.ResumeTrigger("tt", "default");
                    scheduler.UnscheduleJob("tt", "default");
                    scheduler.ScheduleJob(newTrigger);
                    //scheduler.RescheduleJob("tt", "default", newTrigger);
                    scheduler.DeleteJob("firstJob", "default");

                    Console.WriteLine("修改了...");



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
