using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public static class FileDuplicateHelper
    {
        public static void WriteToOutputFile(IEnumerable<string> files)
        {
            var path = Directory.GetCurrentDirectory() + "\\duplicates.txt";
            foreach (var file in files)
            {
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(Path.GetFileName(file));
                    tw.Close();
                }
            }
        }
        public static string GetHash(string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return Encoding.UTF8.GetString(new SHA1Managed().ComputeHash(fileStream));
            }
        }
    }
}
