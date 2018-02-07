using System;
using System.Text;
using System.Collections.Generic;

namespace SeeSharp101.Basics
{
    public class Graph : GraphBase
    {
       
        public int[,] AdjacencyMatrix { get; private set; }
        public override Dictionary<int, Vertex> Vertices { get; set; }
        

        public override bool IsConnected
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


        public Graph(string name, string description, int[,] adjacencyMatrix)
        {

            this.Name = name;
            this.Description = description;
            this.AdjacencyMatrix = adjacencyMatrix;
        }
        public Graph(string name, string description = "One Graph to Rule Them All")
         {
            Name = name;
            Description = description;
         }
        public Graph(string name)
        {
            Name = name;
        }

        public Graph(int[,] adjacencyMatrix)
        {
           // if (adjacencyMatrix.Length == 0) throw new ArgumentException("ll");
            this.AdjacencyMatrix = adjacencyMatrix;
      
        }
        

    }
}
