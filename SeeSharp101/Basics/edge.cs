using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharp101.Basics
{
    public class Edge : MetadataBase
    {
    
        public Vertex Source { get; set; }
        public Vertex Destination { get; set; }
        public Edge(Vertex source, Vertex destination)
        {

        }

        public Edge()
        {
        }
    }
}
