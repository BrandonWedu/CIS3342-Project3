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

    //Contains House Data
    public  class Home : ICloneable<Home>
    {
        //Fields
        private int? houseID;
        private Agent agent;
        private Address address;
        private PropertyType type;
        private int homeSize;
        private DateTime dateConstructed;
        private string garage;
        private string description;
        private DateTime dateListed;
        private SaleStatus saleStatus;
        private HomeImages images;
        private HomeAmenities amenities;
        private TemperatureControl temperatureControl;
        private HomeRooms rooms;
        private HomeUtilities utilities;

        //Constructor without id
        public Home(Agent agent, Address address, PropertyType type, DateTime dateConstructed, string garage, string description, DateTime dateListed, SaleStatus saleStatus, HomeImages images, HomeAmenities amenities, TemperatureControl temperatureControl, HomeRooms rooms, HomeUtilities utilities) {
            this.houseID = null;
            this.agent = agent.DeepCopy();
            this.address = address.DeepCopy();
            this.type = type;
            this.dateConstructed = new DateTime(dateConstructed.Ticks);
            this.garage = garage;
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
        public Home(int? houseID, Agent agent, Address address, PropertyType type, DateTime dateConstructed, string garage, string description, DateTime dateListed, SaleStatus saleStatus, HomeImages images, HomeAmenities amenities, TemperatureControl temperatureControl, HomeRooms rooms, HomeUtilities utilities) {
            this.houseID = houseID;
            this.agent = agent.DeepCopy();
            this.address = address.DeepCopy();
            this.type = type;
            this.dateConstructed = new DateTime(dateConstructed.Ticks);
            this.garage = garage;
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

        //Calculate homesize
        private void CalculateHomeSize()
        {
            
        }

        public Home DeepCopy()
        {
            return new Home(houseID, agent, address, type, dateConstructed, garage, description, dateListed, saleStatus, images, amenities, temperatureControl, rooms, utilities);
        }
    }
}
