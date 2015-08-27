using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;

namespace WindowsService1.Task
{
    public class WriteTimer
    {
        static Timer writeTimer=new Timer();
        static double interval = 30000;
        static int count = 1;
        static bool isInit = false;
        static void DoWork()
        {
            Console.WriteLine("kjljlkj");
            FileStream fs = new FileStream(@"D:\WindowsServerTaskTest\a.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(string.Format("{0}:写入第{1}次",DateTime.Now,(count++).ToString()));
            sw.Close();
            fs.Close();
        }
        static void setTimer()
        {
            writeTimer.Interval = interval;
            writeTimer.Elapsed+= delegate(object sender, ElapsedEventArgs e){
                DoWork();
            };
        }
        public static void Start()
        {
            if(isInit==false)
            {
                Console.WriteLine("初始化定时器。。。");
                setTimer();
                isInit = true;
                Console.WriteLine("初始化完成");
            }
            writeTimer.Start();
            Console.WriteLine("开始工作....");

        }
        public static void Stop()
        {
            writeTimer.Enabled = false;
        }
    }
}
