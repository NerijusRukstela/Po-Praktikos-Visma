using System;
using System.Text;

namespace SeeSharp101.Basics
{
    public class Graph
    {
        
         public string Name { get; private set; }
         public string Description { get; private set; }
         public int[,] AdjacencyMatrix { get; private set; }



        public string GetStatistics()
        {
            StringBuilder myStringBuilder = new StringBuilder();

            myStringBuilder.Append(String.Format("{0,6} {1,15}\n\n", "Name", Name));
            myStringBuilder.Append(String.Format("{0,6} {1,15:N0}\n", "Description", Description));
            myStringBuilder.Append(String.Format("{0,6} {1,15:N0}\n", "IsConnected", IsConnected));
            string newString = Convert.ToString(myStringBuilder);

            return newString;



        }

        public bool IsConnected
         {
             get
             {
                int roundI = -1;
                bool isTrue = true;
                for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
                {
                    roundI = roundI + 1;
                    for (int j = 0; j < AdjacencyMatrix.GetLength(1); j++)
                    {
                        if (i == roundI && i == j) { }
                        else
                        {
                            if (AdjacencyMatrix[i, j] == 0)
                            {
                                isTrue = false;
                                return isTrue;
                            }
                        }
                    }
                }
                return isTrue;
             }
         }
         public Graph(string name, string description = "One Graph to Rule Them All")
         {
            this.Name = name;
            this.Description = description;
         }
        
        public Graph(int[,] adjacencyMatrix)
        {
           // if (adjacencyMatrix.Length == 0) throw new ArgumentException("ll");
            this.AdjacencyMatrix = adjacencyMatrix;
      
        }
       
    }
}
