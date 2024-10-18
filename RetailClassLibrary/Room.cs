using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    //Enum for types of rooms
    public enum RoomType
    {
        LivingRoom,
        Kitchen,
        DiningRoom,
        Bedroom,
        Bathroom,
        HomeOffice,
        Laundry,
        Garage,
        Basement,
        Attic,
        Pantry,
        Mudroom,
        Library,
        Sunroom,
        Workshop,
        Storage
    }

    //Contains Room Data
    internal class Room : ICloneable<Room>
    {
        //Fields
        private int? roomID;
        private RoomType type;
        private int height;
        private int width;

        //Constructor without id
        public Room(RoomType type, int height, int width)
        {
            roomID = null;
            this.type = type;
            this .height = height;
            this .width = width;
        }
        //Constructor with id
        public Room(int? roomID, RoomType type, int height, int width)
        {
            this.roomID = roomID;
            this.type = type;
            this .height = height;
            this .width = width;
        }

        //Get Set
        public int? RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }
        public RoomType Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        //Return Deep Copy
        public Room DeepCopy()
        {
            return new Room (type, height, width);
        }
    }
}
