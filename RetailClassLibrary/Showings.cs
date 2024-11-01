using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    public class Showings : ListOfObjects<Showing>, ICloneable<Showings>
    {
        public Showings() { }
        public Showings(List<Showing> list) 
        {
            this.list = list;
        }
        public Showings DeepCopy()
        {
            return new Showings(List);
        }
    }
}
