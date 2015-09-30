using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElandBJ.ScheduledJob.api
{
    public interface IEmailManager
    {
        void AddTrigger(string cronExpression, string triggerName);

        void RemoveTrigger(string triggerName);

        void InitEmailScheduler();
    }
}
