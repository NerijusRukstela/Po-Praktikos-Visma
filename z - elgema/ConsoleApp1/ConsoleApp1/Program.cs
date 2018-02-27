using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static void Test(string[] filesPaths)
        {
            filesPaths
                .Select(f => new
                {
                    FileName = f,
                    FileHash = GetHash(f)
                })
                .GroupBy(f => f.FileHash)
                .Select(g => new
                {
                    FileHash = g.Key,
                    Files = g.Select(z => z.FileName).ToList()
                })
                .SelectMany(f => f.Files.Skip(1)).ToList()
                .ForEach(delegate (string name)
                {
                    writeDublicateTitle(name);
                });
        }

        private static string GetHash(string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return Encoding.UTF8.GetString(new SHA1Managed().ComputeHash(fileStream));
            }
        }
        private static void createFileForDublicateTitle()
        {
            string path = "E:/elgema/ConsoleApp1/ConsoleApp1/bin/Debug/dublikatai.txt";

            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    
                    sw.WriteLine("Welcome");
                }
            }
        }
        static void writeDublicateTitle(string name)
        {
         
            string path = "E:\\elgema\\ConsoleApp1\\ConsoleApp1\\bin\\Debug\\dublikatai.txt";
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(name);
                tw.Close();
            }

        }

        static void Main(string[] args)
        {


            createFileForDublicateTitle();

            

                Console.WriteLine("Paieskos giju skaicius");
                string threadNumberString = Console.ReadLine();
                int threadNumberInt = Convert.ToInt32(threadNumberString);

            switch (threadNumberInt)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("negalimas giju skaicius");
                    break;
            }
            Console.WriteLine("Ivesti paieskos katalogas");
            string searchFolder = Console.ReadLine();
            Test(Directory.GetFiles(searchFolder));
           


            
        }
    }
}