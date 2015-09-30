using Log.Core;
using Log.Dto;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("输入一个名字：");
            string userName=Console.ReadLine();
            Context.Current["userName"] = userName;
            ISampleService sampleService = (ISampleService)ContextRegistry.GetContext().GetObject("SampleService");
            Console.WriteLine(sampleService.GetTime());


            Console.Read();
        }
    }
}
