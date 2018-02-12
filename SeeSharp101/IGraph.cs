using SeeSharp101.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharp101
{
    interface IGraph
    {
        string Description { get; }
        string Name { get; }
        bool IsConnected { get; }
        IEnumerable<Vertex> Vertices { get; }
        IEnumerable<Edge> Edges { get; }

        void AddEdge(string sourceVertex, string destinationVertex);
        void AddEdges(IEnumerable<KeyValuePair<string, string>> edge);
        void AddVertex(string key);
        void AddVertices(IEnumerable<string> keys);
    }
}
