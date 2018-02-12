using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharp101.Basics
{
    class Edge : MetadataBase
    {
        public Vertex Source { get; set; }
        public Vertex Target { get; set; }
    }
}
