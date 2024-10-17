using System;
using System.Collections.Generic;
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
        Playroom,
        Mudroom,
        Library,
        Sunroom,
        Workshop,
        Storage
    }

    //Contains data for a home image
    public class HomeImage
    {
        //Fields
        private int imageID;
        private string url;
        private RoomType type;
        private string description;

        //Constructor
        public HomeImage (int imageID, string url, RoomType type, string description)
        {
            this.imageID = imageID;
            this.url = url;
            this.type = type;
            this.description = description;
        }

        //Get Set
        public int ImageID
        {
            get { return imageID; }
            set { imageID = value; }
        }
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        public RoomType Type
        {
            get { return type; }
            set { type = value; }
        } 
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        //Return Deep Copy
        internal HomeImage DeepCopy()
        {
            return new HomeImage(imageID, url, type, description);
        }
    }
}
