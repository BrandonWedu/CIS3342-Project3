using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibrary
{
    //Contains a list of Image
    public class HomeImages : ListOfObjects<Image>, ICloneable<HomeImages>
    {
        //Constructor with no list
        public HomeImages() { }
        //Constructor with list
        public HomeImages(List<Image> list)
        {
            foreach (Image item in list)
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
