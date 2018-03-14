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
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter search threads count: ");
            var threadsCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter full path of search directory: ");
            var searchFolder = Console.ReadLine();

            DuplicateFilesFinder duplicateFinder = new DuplicateFilesFinder(searchFolder, threadsCount);
            duplicateFinder.Search();
        }
    }
}


