using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibrary
{
    //Contains a list of Room
    public class HomeRooms : ListOfObjects<Room>, ICloneable<HomeRooms>
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
        
        public int GetBedrooms()
        {
            int count = 0;
            foreach(Room room in List)
            {
                if(room.Type == RoomType.Bedroom)
                {
                    count++;
                }
            }
                return count;
        }
        public int GetFullBaths()
        {
            int count = 0;
            foreach(Room room in List)
            {
                if(room.Type == RoomType.BathroomFull)
                {
                    count++;
                }
            }
            return count;
        }
        public int GetHalfBaths()
        {
            int count = 0;
            foreach(Room room in List)
            {
                if(room.Type == RoomType.BathroomHalf)
                {
                    count++;
                }
            }
            return count;
        }
        //Implement Interface
        public HomeRooms DeepCopy()
        {
            return new HomeRooms(ListDeepCopy());
        }
    }
}
