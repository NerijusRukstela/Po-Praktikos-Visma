using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharp101.Basics
{
    public class Vertex // : MetadataBase
    {
        private int Index { get; set; }
        private List<Vertex> _neighbours = new List<Vertex>();
        private IEnumerable<string> keys;

        public string Key { get; set; }
        public IEnumerable<Vertex> Neighbours {
            get
            {

                return _neighbours;
            }
        }

       
        public Vertex(string key)
        {
        }

        public Vertex(IEnumerable<string> keys)
        {
            this.keys = keys;
        }

        //public void AddNeighbour(Vertex vertex)
        //{

        //}

      
    }
}
