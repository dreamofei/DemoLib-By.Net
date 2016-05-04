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
    /// back
    /// </summary>
    class Program4
    {
        static void Main4(string[] args)
        {
            string templateDbName = "MyTestDB";
            string templateServer = "localhost";
            Server server = new Server(templateServer);
            Database templateDb = server.Databases[templateDbName];

            //Backup backup = new Backup();
            //backup.SqlBackup

            Backup backup = new Backup();
            backup.Action = BackupActionType.Database;
            backup.Database = templateDbName;
            string backUpFilePath = @"D:\myDb20160504.bak";
            BackupDeviceItem backupDeviceItem = new BackupDeviceItem(backUpFilePath, DeviceType.File);
            backup.Devices.Add(backupDeviceItem);
            backup.Initialize = true;

            Console.WriteLine("begin back。。。");

            String script = backup.Script(server);
            backup.SqlBackup(server);

            string sqlFilePath = @"D:\sqlScript_backUp.sql";
            using (StreamWriter sw = new StreamWriter(sqlFilePath, true, Encoding.UTF8))
            {
                sw.WriteLine(script);
                sw.WriteLine("GO");
            }

            //--------方式1-----------




            //--------方式2-----------



            Console.WriteLine("end。。。");


            Console.ReadKey();
        }
    }
}
