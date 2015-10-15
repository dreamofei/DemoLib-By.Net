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
        private JobDetail job;
        public EmailManager()
        {
            job = CommonUtil.BuildJob();
            GlobalScheduler.Scheduler.AddJob(job, false);
        }
        
        public void AddTrigger(string cronExpression,string triggerName)
        {
            Trigger trigger = CommonUtil.BuildTrigger(cronExpression,triggerName);
            GlobalScheduler.Scheduler.ScheduleJob(trigger);
        }

        public void RemoveTrigger(string triggerName)
        {
            GlobalScheduler.Scheduler.UnscheduleJob(triggerName, Keys.TRIGGERGROUP);
        }

        public void ModifyTrigger(string cronExpression, string triggerName)
        {
            this.RemoveTrigger(triggerName);
            this.AddTrigger(cronExpression, triggerName);
        }

        public void TriggerScheduled()
        {
            GlobalScheduler.Scheduler.GetTriggersOfJob(Keys.JOBNAME, Keys.JOBGROUP).ToList().ForEach(t => this.RemoveTrigger(t.Name));
            isInit = false;
            this.InitEmailScheduler();
        }

        public void InitEmailScheduler()
        {
            if(isInit==false)
            {
                isInit = true;

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
