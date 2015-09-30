using Log.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log
{
    public class SampleService:ISampleService
    {
        public ISampleDao SampleDao
        {
            set;
            private get;
        }
        //public ISampleDao SampleDao
        //{
        //    get { return new SampleDao();}
        //}
        public string GetTime()
        {
            return SampleDao.GetTime();
            //return SampleDao.GetDate();
        }
    }
}
