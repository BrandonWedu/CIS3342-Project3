using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    //Enum for room types in Room.cs
    //Contains data for a home image
    public class HomeImage : ICloneable<HomeImage>
    {
        //Fields
        private int? imageID;
        private string url;
        private RoomType type;
        private string description;

        //Constructor without id
        public HomeImage (string url, RoomType type, string description)
        {
            this.imageID = null;
            this.url = url;
            this.type = type;
            this.description = description;
        }
        //Constructor with id
        public HomeImage (int? imageID, string url, RoomType type, string description)
        {
            this.imageID = imageID;
            this.url = url;
            this.type = type;
            this.description = description;
        }

        //Get Set
        public int? ImageID
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
        public HomeImage DeepCopy()
        {
            return new HomeImage(imageID, url, type, description);
        }
    }
}
