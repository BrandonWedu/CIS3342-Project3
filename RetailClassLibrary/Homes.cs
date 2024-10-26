using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    public class Homes : ListOfObjects<Home>, ICloneable<Homes>
    {
        public Homes() { }
        public Homes(List<Home> list) { }
        public Homes DeepCopy()
        {
            return new Homes(List);
        }
    }
}
