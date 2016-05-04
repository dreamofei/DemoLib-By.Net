using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Common;
using System.Collections.Specialized;
using System.IO;

namespace CreateDBBaseOnDB
{
    /// <summary>
    /// 利用Transfer生成sql
    /// </summary>
    class Program
    {
        static void Main2(string[] args)
        {
            //string templateDbName = "MyTestDB";
            //string templateServer = "localhost";
            string templateDbName = "SemDissectorGlobalManagement";
            string templateServer = "10.200.50.173";
            //ServerConnection conn = new ServerConnection("");
            Server server = new Server(templateServer);
            Database templateDb = server.Databases[templateDbName];
            Transfer transfer = new Transfer(templateDb);

            //transfer.CopyAllDatabaseTriggers = true;
            transfer.CopyAllDefaults = true;
            transfer.CopyAllObjects = true;
            transfer.CopyAllUsers = true;
            transfer.CopyData = true;
            transfer.DestinationDatabase = "DBByCS";
            transfer.CreateTargetDatabase = true;
            transfer.DestinationServer = "localhost";
            //transfer.Scripter
            //transfer.Options.ExtendedProperties = true;

            Console.WriteLine("begin scriptTransfer。。。");

            //StringCollection sqlStrs = transfer.ScriptTransfer();
            //IEnumerable<string> sqlStrs2 = transfer.EnumScriptTransfer();
            transfer.TransferData();

            //Console.WriteLine("begin writeFiles。。。");
            ////--------输出到文件-----
            //string sqlFilePath = @"D:\sqlScript.sql";
            //using (StreamWriter sw = new StreamWriter(sqlFilePath, false, Encoding.UTF8))
            //{
            //    foreach (var sql in sqlStrs)
            //    {
            //        sw.WriteLine(sql);
            //    }
            //}

            //string sqlFilePath2 = @"D:\sqlScript2.sql";
            //using (StreamWriter sw = new StreamWriter(sqlFilePath2, false, Encoding.UTF8))
            //{
            //    foreach (var sql in sqlStrs2)
            //    {
            //        sw.WriteLine(sql);
            //    }
            //}
            //--------输出到文件-----
            //--------输出到console-----
            //StringBuilder sb = new StringBuilder();
            //foreach (var sql in sqlStrs)
            //{
            //    sb.AppendLine(sql);
            //}

            //Console.WriteLine(sb.ToString());
            //--------输出到console-----

            //var conn = new ServerConnection(connection);
            //var server = new Microsoft.SqlServer.Management.Smo.Server("localhost");
            //Database database = server.Databases[templateDbName];
            //var transfer = new Transfer(database);
            //transfer.CopyAllObjects = true;
            //transfer.DropDestinationObjectsFirst = true;
            //transfer.CopyData = true;
            //transfer.CopySchema = true;
            //transfer.CreateTargetDatabase = true;
            //transfer.CopyAllPartitionFunctions = true;
            //transfer.CopyAllPartitionSchemes = true;
            //transfer.Options.DriForeignKeys = true;
            //transfer.Options.Indexes = true;
            //transfer.Options.DriAll = true;
            //transfer.Options.Triggers = true;
            //transfer.Options.NoCollation = false;
            //transfer.Options.IncludeDatabaseRoleMemberships = true;
            ////添加注释
            //transfer.Options.ExtendedProperties = true;
            //return transfer.ScriptTransfer();
            Console.WriteLine("end。。。");


            Console.ReadKey();
        }
    }
}
