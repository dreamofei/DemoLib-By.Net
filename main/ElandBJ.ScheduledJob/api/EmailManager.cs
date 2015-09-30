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
        private JobDetail job=new JobDetail("EmailSender",Keys.JOBGROUP,typeof(EmailJob));

        public void AddTrigger(string cronExpression,string triggerName)
        {
            Trigger trigger = CommonUtil.BuildTrigger(cronExpression,triggerName);
            GlobalScheduler.Scheduler.ScheduleJob(job, trigger);
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

                List<TriggerDto> triggers;
                triggers = new List<TriggerDto>(); //实际：调用方法得到数据库中的所有trigger

                triggers.ForEach(t => this.AddTrigger(t.CronExpression, t.TriggerName));
            }
        }
    }
}
