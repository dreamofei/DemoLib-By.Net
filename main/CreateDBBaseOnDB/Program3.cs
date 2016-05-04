using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Common;
using System.Collections.Specialized;
using System.IO;
using Microsoft.SqlServer.Management.Sdk.Sfc;

namespace CreateDBBaseOnDB
{
    /// <summary>
    /// 生成table的sql
    /// </summary>
    class Program3
    {
        static void Main3(string[] args)
        {
            string templateDbName = "MyTestDB";
            string templateServer = "localhost";
            Server server = new Server(templateServer);
            Database templateDb = server.Databases[templateDbName];


            //--------方式1-----------
            //Scripter scripter = new Scripter(server);
            //Urn[] databaseUrns = new Urn[] {templateDb.Urn};
            //StringCollection sqlStrs = scripter.Script(databaseUrns);


            //Console.WriteLine("begin writeFiles。。。");
            //string sqlFilePath = @"D:\sqlScript_DB.sql";
            //using (StreamWriter sw = new StreamWriter(sqlFilePath, false, Encoding.UTF8))
            //{
            //    foreach (var sql in sqlStrs)
            //    {
            //        sw.WriteLine(sql);
            //    }
            //}

            //--------方式1-----------

            //--------方式2-----------
            ScriptingOptions sOption = new ScriptingOptions();
            sOption.DriAll = true;
            //sOption.ScriptData = true;
            int count = 1;
            foreach (Table tb in templateDb.Tables)
            {
                StringCollection sqlStrs = tb.Script(sOption);
                Console.WriteLine("begin writeFiles。。。"+(count++));
                string sqlFilePath = @"D:\sqlScript_tb2.sql";
                using (StreamWriter sw = new StreamWriter(sqlFilePath, true, Encoding.UTF8))
                {
                    foreach (var sql in sqlStrs)
                    {
                        sw.WriteLine(sql);
                        sw.WriteLine("GO");
                    }
                }
            }

            

            //--------方式2-----------



            Console.WriteLine("end。。。");


            Console.ReadKey();
        }
    }
}
