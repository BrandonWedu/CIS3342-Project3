using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    //Property Type Enum
    public enum PropertyType
    {
        Townhome,
        Multifamily,
        Condo,
        Duplex,
        Tinyhome
    }
    //House status Enum
    public enum SaleStatus
    {
        OffMarket,
        ForSale,
        Pending,
        Sold
    }
    //enum for GarageTypes
    public enum GarageType
    {
        SingleCar,
        DoubleCar,
        MultiCar
    }

    //Contains House Data
    public  class Home : ICloneable<Home>
    {
        //Fields
        private int? homeID;
        private Agent agent;
        private Address address;
        private PropertyType propertyType;
        private int homeSize;
        private int yearConstructed;
        private GarageType garageType;
        private string description;
        private DateTime dateListed;
        private SaleStatus saleStatus;
        private HomeImages images;
        private HomeAmenities amenities;
        private TemperatureControl temperatureControl;
        private HomeRooms rooms;
        private HomeUtilities utilities;

        //Constructor without id
        public Home(Agent agent, Address address, PropertyType type, int yearConstructed, GarageType garageType, string description, DateTime dateListed, SaleStatus saleStatus, HomeImages images, HomeAmenities amenities, TemperatureControl temperatureControl, HomeRooms rooms, HomeUtilities utilities) {
            this.homeID = null;
            this.agent = agent.DeepCopy();
            this.address = address.DeepCopy();
            this.propertyType = type;
            this.yearConstructed = yearConstructed;
            this.garageType = garageType;
            this.description = description;
            this.dateListed = new DateTime(dateListed.Ticks);
            this.saleStatus = saleStatus;
            this.images = images.DeepCopy();
            this.amenities = amenities.DeepCopy();
            this.temperatureControl = temperatureControl.DeepCopy();
            this.rooms = rooms.DeepCopy();
            this.utilities = utilities.DeepCopy();
            CalculateHomeSize();
        }
        //Constructor with id
        public Home(int? houseID, Agent agent, Address address, PropertyType type, int yearConstructed, GarageType garageType, string description, DateTime dateListed, SaleStatus saleStatus, HomeImages images, HomeAmenities amenities, TemperatureControl temperatureControl, HomeRooms rooms, HomeUtilities utilities) {
            this.homeID = houseID;
            this.agent = agent.DeepCopy();
            this.address = address.DeepCopy();
            this.propertyType = type;
            this.yearConstructed = yearConstructed;
            this.garageType = garageType;
            this.description = description;
            this.dateListed = new DateTime(dateListed.Ticks);
            this.saleStatus = saleStatus;
            this.images = images.DeepCopy();
            this.amenities = amenities.DeepCopy();
            this.temperatureControl = temperatureControl.DeepCopy();
            this.rooms = rooms.DeepCopy();
            this.utilities = utilities.DeepCopy();
            CalculateHomeSize();
        }

        //Get Set
        public int? HomeID
        {
            get { return homeID; }
            set { homeID = value; }
        }
        public Agent Agent
        {
            get { return agent.DeepCopy(); }
            set { agent = value.DeepCopy(); }
        }
        public Address Address
        {
            get { return address.DeepCopy(); }
            set { address = value.DeepCopy(); }
        }
        public PropertyType PropertyType
        {
            get { return propertyType; }
            set { propertyType = value; }
        }
        public int HomeSize
        {
            get { return CalculateHomeSize(); }
            set { homeSize = value; }
        } 
        public int YearConstructed
        {
            get { return yearConstructed; }
            set { yearConstructed = value; }
        }
        public GarageType GarageType
        {
            get { return garageType; }
            set {  garageType = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public DateTime DateListed
        {
            get { return new DateTime(dateListed.Ticks); }
            set { dateListed = new DateTime(value.Ticks); }
        }

        public SaleStatus SaleStatus
        {
            get { return saleStatus; }
            set { saleStatus = value; }
        }

        public HomeImages Images
        {
            get { return images.DeepCopy(); }
            set { images = value.DeepCopy(); }
        }

        public HomeAmenities Amenities
        {
            get { return amenities.DeepCopy(); }
            set { amenities = value.DeepCopy(); }
        }

        public TemperatureControl TemperatureControl
        {
            get { return temperatureControl.DeepCopy(); }
            set { temperatureControl = value.DeepCopy(); }
        }

        public HomeRooms Rooms
        {
            get { return rooms.DeepCopy(); }
            set { rooms = value.DeepCopy(); }
        }

        public HomeUtilities Utilities
        {
            get { return utilities.DeepCopy(); }
            set { utilities = value.DeepCopy(); }
        }

    //Calculate homesize
    private int CalculateHomeSize()
        {
            homeSize = 0; 
            foreach (Room room in rooms.List)
            {
                homeSize += room.Width * room.Height;
            }
            return homeSize;
        }

        public Home DeepCopy()
        {
            return new Home(HomeID, Agent, Address, PropertyType, YearConstructed, GarageType, Description, DateListed, SaleStatus, Images, Amenities, TemperatureControl, Rooms, Utilities);
        }
    }
}
