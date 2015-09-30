using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ElandBJ.Token.Common
{
    public class FileHelper
    {
        public static void CreateFile(string path, string strData)
        {
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(strData);
            sw.Close();
            fs.Close();
        }

        public static string GetSpecialPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }

        public static string GetPath(string partPath)
        {
            return Path.Combine(GetSpecialPath(), partPath);
        }

        public static string ReadFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string fileData = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            return fileData;
        }
    }
}
