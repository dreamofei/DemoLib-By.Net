using DemoLib.Security.FW4._5.Common;
using DemoLib.Security.FW4._5.Crypt;
using DemoLib.Security.FW4._5.Ticket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine(HashBuilder.GetHMACMD5Hash("hello"));
        //    Console.WriteLine(HashBuilder.GetMD5Hash("hello"));
        //    Console.WriteLine(HashBuilder.GetMD5Hash2("hello"));

        //    Console.ReadKey();
        //}

        //static void Main(string[] args)
        //{
        //    string KeyDirectory = FileHelper.GetPath("UAP");
        //    if (!Directory.Exists(KeyDirectory))
        //    {
        //        Directory.CreateDirectory(KeyDirectory);
        //    }
        //    CryptHelper.CreateRSAKey(Path.Combine(KeyDirectory, "privateKey.xml"), Path.Combine(KeyDirectory, "publicKey.xml"));

        //    Console.ReadKey();
        //}

        //static void Main(string[] args)
        //{
        //    string KeyDirectory = FileHelper.GetPath("UAP");
        //    //加密
        //    string RSAed = CryptHelper.Encrypt(Path.Combine(KeyDirectory, "publicKey.xml"), "hello");
        //    string normal = CryptHelper.Decrypt(Path.Combine(KeyDirectory, "privateKey.xml"), RSAed);

        //    Console.WriteLine(RSAed);
        //    Console.WriteLine(normal);

        //    Console.ReadKey();
        //}

        //static void Main(string[] args)
        //{
        //    string data = "hello";
        //    byte[] bytes = Encoding.UTF8.GetBytes(data);
        //    string X16 = CommonHelper.ByteArrayToString(bytes);

        //    //byte bytes2= Convert.ToByte(X16,16);
        //    byte[] b = new byte[128];

        //    for (int i = 0; i < 256;i=i+2 )
        //    {
        //        b[i / 2] = Convert.ToByte(X16.Substring(i, 2), 16);
        //    }


        //        //byte[] bytes2 = Encoding.ASCII.GetBytes(X16);

        //        //Console.WriteLine(RSAed);
        //        //Console.WriteLine(normal);

        //        Console.ReadKey();
        //}

        //static void Main(string[] args)
        //{
        //    string ticket = TicketHelper.CreateTicket("admin23","10.202.101.170",2);
        //    Console.WriteLine(ticket);
        //    string userId=null;
        //    TicketState ts = TicketHelper.CheckTicket("800b5fa3f8efb1cdcb00909f4e1e7b0a7e4efd8b08d1e0400878d0d63cb996653e492dc68deba9f4cbce62c622241b94f3237cee7d845a6bb1d020b4d60c739da38dd5bd69d3df6e7b807592248bc17fc35c76f2bc8cdb81403036bde087e010e5c627089944bac49cec72e088b5dd67eb00f28318ebcb066b694dc6e4474237","10.202.101.170",out userId);
        //    if (ts==TicketState.Valid)
        //    {
        //        Console.WriteLine("OK!");
        //    }
        //    else
        //    {
        //        Console.WriteLine("No，{0}", ts.ToString());
        //    }

        //    Console.ReadKey();
        //}

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("ToShortDateString  {0}", DateTime.Now.ToShortDateString());
        //    Console.WriteLine("ToShortTimeString  {0}", DateTime.Now.ToShortTimeString());
        //    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        //    int lengthTime = 60;
        //    string oldTime = "2015-04-16 10:22:45";
        //    TimeSpan xx=(DateTime.Now - Convert.ToDateTime(oldTime));
        //    if(Convert.ToInt32(xx.TotalMinutes)>lengthTime)
        //    {
        //        Console.WriteLine("{0}大于，totleM{1}", xx, Convert.ToInt32(xx.TotalMinutes));
        //    }
        //    else
        //    {
        //        Console.WriteLine("{0}小于，totleM{1}", xx, Convert.ToInt32(xx.TotalMinutes));
        //    }

        //    Console.ReadKey();
        //}

//        static void Main(string[] args)
//        {
//            System.Diagnostics.Debug.Write("Debug.Write~~~");
//            System.Diagnostics.Trace.Write("Trace.Write!!!");
//            Console.Read();
//#if (DEBUG)
//            Console.WriteLine("debug 模式");
//#endif
//        }

        //static void Main(string[] args)
        //{
        //    //int i1 = 5;
        //    //int i2 = 6;
        //    //i2 = i1;
        //    //Console.WriteLine(i1.Equals(i2) + "  " + (i1 == i2));

        //    //string i1 = "5";
        //    //string i2 = "51";
        //    //i2 = i1;
        //    //i2 = "5";
        //    //string i1 = new string(new char[] { '2' });
        //    //string i2 = new string(new char[] { '2' });
            
        //    //Console.WriteLine(i1.Equals(i2) + "  " + (i1 == i2));

        //    //Class1 i1 = new Class1();
        //    //Class1 i2 = new Class1();
        //    ////i2 = i1;

        //    //i1.a = i2.a = 5;
        //    //Console.WriteLine(i1.Equals(i2) + "  " + (i1 == i2));

        //    //DriveInfo d = new DriveInfo("D");
        //    //DriveInfo d2 = new DriveInfo("D");
        //    //Console.WriteLine(d.Equals(d2) + "  " + (d == d2));

        //    //---------深浅拷贝

        //    //Class1 c1 = new Class1(5);
        //    //c1.member = new Class1(12);
        //    //Class1 c2 = c1;
        //    ////Class1 c3 = (Class1)c2.Clone();
        //    //Class1 c3 = (Class1)c2.DeepClone();

        //    //c2.a = 6;
        //    ////c2.member = new Class1(7);
        //    //c2.member.a = 7;

        //    //Console.WriteLine("c1.a:{0},c1.member.a:{1}", c1.a, c1.member.a);//6,7  或 6，7
        //    //Console.WriteLine("c2.a:{0},c2.member.a:{1}", c2.a, c2.member.a);//6,7     6，7
        //    //Console.WriteLine("c3.a:{0},c3.member.a:{1}", c3.a, c3.member.a);//6,7     5，7

        //    Class1 c1 = new Class1(1);
        //    Console.WriteLine("原：c1.a:{0}", c1.a);
        //    fun(c1);
        //    Console.WriteLine("后：c1.a:{0}",c1.a);
        //    c1.treeLis += c1_treeLis;
        //    c1.treeLis2 = delegate() { return ""; };


        //    Console.Read();

           
        //}

        //static string c1_treeLis()
        //{
        //    throw new NotImplementedException();
        //}

        //static void fun(Class1 c)
        //{
        //    c.a = 100;
        //}

        static void Main(string[] args)
        {
            //int key = 1;
            //Console.WriteLine("主线程启动...");

            //Thread t=new Thread(delegate(){

            //    Console.WriteLine("我是另外一个线程...");
            //});
            ////Thread t1 = new Thread(ThreadStart, ParameterizedThreadStart);
            //t.Start();
            //Thread.Sleep(3000);
            //Monitor.Wait(key);

            SynchronizedTest st = new SynchronizedTest();
            Timer t = new Timer(
                delegate(object obj){
                    st.run();
                },null,0,1000
                );
            Console.Read();


        }

        public class SynchronizedTest
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            public void run()
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Thread.Sleep(5000);
            }
        }

    }
}
