using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharp101.Basics
{
    public class Vertex
    {
        public int Index { get; set; }
        public List<Vertex> Neighbours { get; set; }
    }
}
