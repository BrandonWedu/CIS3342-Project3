using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    internal class Offers : ListOfObjects<Offer>, ICloneable<Offers>
    {
        public Offers() { }
        public Offers(List<Offer> list)
        {
            this.list = list;
        }
        public Offers DeepCopy()
        {
            return new Offers(this.list);
        }
    }
}
