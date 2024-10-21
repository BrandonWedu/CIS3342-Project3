using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    //Contains a list of Utility
    public class HomeUtilities : ListOfObjects<Utility>, ICloneable<HomeUtilities>
    {
        //Constructor with no list
        public HomeUtilities() { }
        //Constructor with list
        public HomeUtilities(List<Utility> list)
        {
            foreach(Utility item in list)
            {
                Add(item);
            }
        }

        //Implemented Interface
        public HomeUtilities DeepCopy()
        {
            return new HomeUtilities(ListDeepCopy());
        }
    }
}
