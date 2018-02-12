using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharp101.Basics
{
    public abstract class MetadataBase
    {
        public object this[string i]
        {
            get { return _dict[i]; }
            set { _dict[i] = value; }
        }
        private Dictionary<string, object> _dict = new Dictionary<string, object>();
       
    }
}
