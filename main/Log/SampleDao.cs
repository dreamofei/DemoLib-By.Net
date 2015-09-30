using Log.Core;
using Spring.Data.NHibernate.Generic.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log
{
    public class SampleDao:HibernateDaoSupport,ISampleDao
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public string GetDate()
        {
            return Session.GetNamedQuery("SampleDao_GetDate")
                .UniqueResult<DateTime>().ToString();
        }
    }
}
