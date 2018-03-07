using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace SeeSharp101.Basics
{
    public class Graph : MetadataBase, IGraph, IEnumerable
    {

        public string Description { get;  }
        public string Name { get; }
        public int[,] AdjacencyMatrix { get; private set; }
        public Vertex Key { get; }
        public IEnumerable<Vertex> Vertices { get; }
        public IEnumerable<Edge> Edges { get; }
       
        List<Vertex> listVertex = new List<Vertex>();


        public bool IsConnected
        {
            get
            {
                int roundI = -1;
                bool isTrue = true;
                for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
                {
                    roundI = roundI + 1;
                    for (int j = 0; j < AdjacencyMatrix.GetLength(0); j++)
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


        public Graph(string name, string description, int[,] adjacencymatrix)
        {

            this.Name = name;
            this.Description = description;
            this.AdjacencyMatrix = adjacencymatrix;
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
        public Graph()
        {
            // if (adjacencyMatrix.Length == 0) throw new ArgumentException("ll");

        }


        public void AddEdge(string sourceVertex, string destinationVertex)
        {

            Vertex source = Vertices.FirstOrDefault(v => v.Key == sourceVertex);
            Vertex destination = Vertices.FirstOrDefault(v => v.Key == destinationVertex);

            Edge edge = new Edge(source, destination);
           

            

        }
        public void AddEdges(IEnumerable<KeyValuePair<string , string >> edge)
        {

            
         
        }
        public void AddVertex(string key)
        {
            Vertex vertex = new Vertex(key);
            listVertex.Add(vertex);

        }
        
        public void AddVertices(IEnumerable<string> keys)
        {
           for(int i=0; i<listVertex.Count; i++)
            {
                Vertex vertices = new Vertex(keys);
                listVertex.Add(vertices);
            }
            
        }
        public IEnumerable<Vertex> GetEnumerator()
        {
            return null;
        }
        IEnumerator IEnumerable.GetEnumerator() {

            return (IEnumerator)this;
        }
       


    }
}
