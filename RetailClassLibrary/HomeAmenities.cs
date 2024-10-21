using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    //Contains a list of Amenitiy
    public class HomeAmenities : ListOfObjects<Amenity>, ICloneable<HomeAmenities>
    {
        //Constructor with no list
        public HomeAmenities() { }
        //Constructor with list 
        public HomeAmenities(List<Amenity> list)
        {
            foreach (Amenity amenity in list)
            {
                Add(amenity);
            }
        }

        //Implement Interface
        public HomeAmenities DeepCopy()
        {
            return new HomeAmenities(ListDeepCopy());
        }
    }
}
