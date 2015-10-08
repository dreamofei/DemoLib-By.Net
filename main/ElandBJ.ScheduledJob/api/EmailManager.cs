using ElandBJ.ScheduledJob.job;
using ElandBJ.ScheduledJob.model;
using ElandBJ.ScheduledJob.util;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElandBJ.ScheduledJob.api
{
    public class EmailManager : IEmailManager
    {
        private static bool isInit = false;
        //private JobDetail job = new JobDetail("EmailSender", Keys.JOBGROUP, typeof(EmailJob));
        private JobDetail job = CommonUtil.BuildJob();
        
        public void AddTrigger(string cronExpression,string triggerName)
        {
            Trigger trigger = CommonUtil.BuildTrigger(cronExpression,triggerName);
            //GlobalScheduler.Scheduler.ScheduleJob(job, trigger);
            GlobalScheduler.Scheduler.ScheduleJob(trigger);
        }

        public void RemoveTrigger(string triggerName)
        {
            GlobalScheduler.Scheduler.UnscheduleJob(triggerName, Keys.TRIGGERGROUP);
        }

        public void InitEmailScheduler()
        {
            if(isInit==false)
            {
                isInit = true;
                GlobalScheduler.Scheduler.AddJob(job, false);

                List<TriggerDto> triggers;
                //实际：调用方法得到数据库中的所有trigger
                triggers = new List<TriggerDto>() 
                {
                    new TriggerDto(){CronExpression="0/3 * * * * ?",TriggerName="初始的"}
                }; 

                triggers.ForEach(t => this.AddTrigger(t.CronExpression, t.TriggerName));
            }
        }
    }
}
