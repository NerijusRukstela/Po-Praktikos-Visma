using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeeSharp101.Basics;
using SeeSharp101.Tests.Basics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphTests one = new GraphTests();
            one.Should_Report_Graph_Is_Connected();
         
           
            Console.ReadLine();
          
        }
    }
}
