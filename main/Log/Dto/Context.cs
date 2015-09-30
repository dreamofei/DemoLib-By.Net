using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log.Dto
{
    public class Context
    {
        private static Context obj;
        private IDictionary<string, object> data = new Dictionary<string, object>();

        private Context()
        {

        }
        public static Context Current
        {
            get
            {
                if(obj==null)
                {
                    obj = new Context();
                }
                return obj;
            }
        }

        public object this[string key]
        {
            get
            {
                return data.First(a => a.Key == key).Value;
            }
            set
            {
                if (data.Keys.Contains(key))
                {
                    data.Remove(key);
                }
                data.Add(key, value);
            }
        }

    }
}
