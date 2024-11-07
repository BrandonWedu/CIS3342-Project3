using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibrary
{
    //emun for all amenity types
    public enum AmenityType
    {
        Fireplace,
        Dishwasher,
        WashingMachine,
        Dryer,
        Refrigerator,
        Microwave,
        BuiltinOven,
        SecuritySystem,
        Deck,
        Patio,
        SwimmingPool,
        HotTub,
        SmartHomeTechnology,
        CeilingFans,
        WalkinCloset,
        HardwoodFloors,
        GraniteCountertops,
        Garden
    }

    //Contains data for and Amenity
    public class Amenity : ICloneable<Amenity>
    {
        //Fields
        private int? amenityID;
        private AmenityType type;
        private string description;

        //Constructor without id
        public Amenity (AmenityType type, string description)
        {
            this.amenityID = null;
            this.type = type;
            this.description = description;
        }
        //Constructor with id
        public Amenity (int? amenityID, AmenityType type, string description)
        {
            this.amenityID = amenityID;
            this.type = type;
            this.description = description;
        }

        //Get Set
        public int? AmenityID
        {
            get { return amenityID; }
            set { amenityID = value; }
        }
        public AmenityType Type
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
        public Amenity DeepCopy()
        {
            return new Amenity(AmenityID, type, description);
        }
    }
}
