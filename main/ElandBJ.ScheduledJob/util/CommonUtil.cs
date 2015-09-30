using ElandBJ.ScheduledJob.model;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElandBJ.ScheduledJob.util
{
    public static class CommonUtil
    {
        public static Trigger BuildTrigger(string cronExpression, string triggerName)
        {
            CronTrigger trigger = new CronTrigger();
            trigger.CronExpressionString = cronExpression; //ctrigger.CronExpressionString = "0/2 * * * * ?";
            trigger.Name = triggerName;
            trigger.Group = Keys.TRIGGERGROUP;
            return trigger;
        }
    }
}
