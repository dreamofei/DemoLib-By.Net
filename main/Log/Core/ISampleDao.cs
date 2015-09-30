using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log.Core
{
    public interface ISampleDao
    {
        string GetTime();
        string GetDate();
    }
}
