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
    /// 生成数据库库的Sql
    /// </summary>
    class Program2
    {
        static void Main2(string[] args)
        {
            string templateDbName = "MyTestDB";
            string templateServer = "localhost";
            //string templateDbName = "SemDissectorGlobalManagement";
            //string templateServer = "10.200.50.173";
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
            StringCollection sqlStrs = templateDb.Script(sOption);

            Console.WriteLine("begin writeFiles。。。");
            string sqlFilePath = @"D:\sqlScript_DB2.sql";
            using (StreamWriter sw = new StreamWriter(sqlFilePath, false, Encoding.UTF8))
            {
                foreach (var sql in sqlStrs)
                {
                    sw.WriteLine(sql);
                    sw.WriteLine("GO");
                }
            }

            //--------方式2-----------



            Console.WriteLine("end。。。");


            Console.ReadKey();
        }
    }
}
