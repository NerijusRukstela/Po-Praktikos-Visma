using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class FileH
    {
        public string FileName { get; set; }
        public string FileHash { get; set; }
        public bool Processed { get; set; }
    }

    //public class FileG
    //{
    //    public string FileHash { get; set; }
    //    public List<string> Files { get; set; }
    //}

    class Program
    {
        private static List<string> duplicates = new List<string>();

        static void Search(List<FileH> files) {
            while (files.Any(f => f.Processed == false))
            {
                var file = files.First(f => f.Processed == false);
                file.Processed = true;
                var index = files.IndexOf(file);

                for (int i = index + 1; i < files.Count; i++)
                {
                    var nextFile = files[i];
                    lock (duplicates)
                    {
                        if (file.FileHash == nextFile.FileHash && !duplicates.Any(f => f == nextFile.FileName))
                        {
                            duplicates.Add(files[i].FileName);
                        }
                    }
                }
            }
        }

        public static void Test(string[] filesPaths)
        {
            //Calculate File hash for every file in directory and add to list
            List<FileH> filesH = new List<FileH>();
            foreach (var file in filesPaths)
            {
                filesH.Add(new FileH()
                {
                    FileName = file,
                    FileHash = GetHash(file)
                });
            }

            var threadsList = new List<Thread>();
            for (int i = 0; i < threadsCount; i++)
            {
                Thread thread = new Thread(delegate ()
                {
                    Search(filesH);
                });
                threadsList.Add(thread);
                thread.Start();
            }

            while (!threadsList.Any(t => t.ThreadState == ThreadState.Stopped))
            {
                Console.WriteLine("Threads running");
            }

           



            WriteDublicateTitle();




            //Search(filesH);
            //Group fileNames by hash
            //var filesHashes = filesH.GroupBy(f => f.FileHash);

            ////Group files with similar hashes by fileName
            //List<FileG> filesG = new List<FileG>();
            //foreach (var file in filesHashes)
            //{
            //    filesG.Add(new FileG()
            //    {
            //        FileHash = file.Key,
            //        Files = file.Select(f => f.FileName).ToList()
            //    });
            //}


            //Iterate through every file hash group
            //foreach (var file in filesG)
            //{
            //    //Iterate to every duplicate file in group, skip first file, because we dont need to write it to duplicates
            //    foreach (var duplicateFile in file.Files.Skip(1))
            //    {
            //        Thread firstThread = new Thread(delegate ()
            //        {
            //            WriteDublicateTitle(duplicateFile);
            //        });
            //        firstThread.Start();

            //    }
            //}
        }

        private static string GetHash(string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return Encoding.UTF8.GetString(new SHA1Managed().ComputeHash(fileStream));
            }
        }
        private static void CreateFileForDublicateTitle()
        {
            string path = "E:/elgema/ConsoleApp1/ConsoleApp1/bin/Debug/dublikatai.txt";

            if (File.Exists(path)) return;
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {

                sw.WriteLine("Welcome");
            }
        }
        private static void WriteDublicateTitle()
        {

            string path = "E:\\elgema\\ConsoleApp1\\ConsoleApp1\\bin\\Debug\\dublikatai.txt";
            foreach (var file in duplicates)
            {
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(file);
                    tw.Close();
                }
            }
            
        }

        static int threadsCount;
        static void Main(string[] args)
        {
            CreateFileForDublicateTitle();

            Console.WriteLine("Paieskos giju skaicius");
            string threadNumberString = Console.ReadLine();
            threadsCount = Convert.ToInt32(threadNumberString);

            Console.WriteLine("Ivesti paieskos katalogas");
            string searchFolder = "E:\\elgema\\ConsoleApp1\\ConsoleApp1\\bin\\Debug\\pirmas";

            Test(Directory.GetFiles(searchFolder));

        }
    }
}


