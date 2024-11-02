using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    public class Companies : ListOfObjects<Company>, ICloneable<Companies>
    {
        public Companies() { }
        public Companies(List<Company> list)
        {
            this.list = list;
        }
        public Companies DeepCopy()
        {
            return new Companies(List);
        }
    }
}
