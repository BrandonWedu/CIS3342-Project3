using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    //Contains a list of Room
    internal class HomeRooms : ListOfObjects<Room>, ICloneable<HomeRooms>
    {
        //Constructor with no list
        public HomeRooms() { }
        //Constructor with list
        public HomeRooms(List<Room> rooms)
        {
            foreach (Room room in rooms)
            {
                Add(room);
            }
        }
        
        //Implement Interface
        public HomeRooms DeepCopy()
        {
            return new HomeRooms(ListDeepCopy());
        }
    }
}
