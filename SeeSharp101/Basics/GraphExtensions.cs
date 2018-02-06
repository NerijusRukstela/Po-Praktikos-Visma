using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharp101.Basics
{
    static class GraphExtensions
    {

        public static string GetStatistics(Graph graph)
        {
            StringBuilder myStringBuilder = new StringBuilder();

            myStringBuilder.Append(String.Format("{0,6} {1,15}\n\n", "Name", graph.Name));
            myStringBuilder.Append(String.Format("{0,6} {1,15:N0}\n", "Description", graph.Description));
            myStringBuilder.Append(String.Format("{0,6} {1,15:N0}\n", "IsConnected", graph.IsConnected));
            string newString = Convert.ToString(myStringBuilder);

            return newString;



        }
    }
}
