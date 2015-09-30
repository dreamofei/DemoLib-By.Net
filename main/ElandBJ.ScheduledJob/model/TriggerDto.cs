using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElandBJ.ScheduledJob.model
{
    [Serializable]
    public class TriggerDto
    {
        public string TriggerName { get; set; }
        public string CronExpression { get; set; }
    }
}
