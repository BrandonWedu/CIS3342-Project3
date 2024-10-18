using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    public class HomeImages : ListOfObjects<HomeImage>, ICloneable<HomeImages>
    {
        //Constructor with no list
        public HomeImages() { }
        //Constructor with list
        public HomeImages(List<HomeImage> list)
        {
            foreach (HomeImage item in list)
                {
                    Add(item);
                }
        }
        
        //Implement Interface
        public HomeImages DeepCopy()
        {
            return new HomeImages(ListDeepCopy());
        }
    }
}
