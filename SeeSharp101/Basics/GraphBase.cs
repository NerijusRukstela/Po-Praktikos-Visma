using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharp101.Basics
{
    abstract public class GraphBase
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public abstract bool IsConnected { get; }
        public abstract Dictionary<int, Vertex> Vertices { get; set; }

    }
}
