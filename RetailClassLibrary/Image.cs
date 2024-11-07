using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibrary
{
    //Enum for room types in Room.cs
    //Contains data for a home image
    public class Image : ICloneable<Image>
    {
        //Fields
        private int? imageID;
        private string url;
        private RoomType type;
        private string description;
        private bool mainImage;

        public Image (RoomType type, string description, bool mainImage)
        {
            this.imageID = null;
            this.url = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff");
            this.type = type;
            this.description = description;
            this.mainImage = mainImage;
        }

        //Constructor without id
        public Image (string url, RoomType type, string description, bool mainImage)
        {
            this.imageID = null;
            this.url = url;
            this.type = type;
            this.description = description;
            this.mainImage= mainImage;
        }
        //Constructor with id
        public Image (int? imageID, string url, RoomType type, string description, bool mainImage)
        {
            this.imageID = imageID;
            this.url = url;
            this.type = type;
            this.description = description;
            this.mainImage = mainImage;
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
        public bool MainImage
        {
            get { return mainImage; }
            set { mainImage = value; }
        }

        //Return Deep Copy
        public Image DeepCopy()
        {
            return new Image(imageID, url, type, description, mainImage);
        }
    }
}
