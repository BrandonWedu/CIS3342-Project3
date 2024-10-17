﻿using System;
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
    public  class Home
    {
        //Fields
        private int houseID;
        private Agent agent;
        private Address address;
        private PropertyType propertyType;
        private int homeSize;
        private DateTime dateConstructed;
        private string garage;
        private string description;
        private DateTime dateListed;
        private SaleStatus saleStatus;
        private List<HomeImage> images;
        private List<amenity> amenities;
        private TempatureControl tempatureControl;
        private List<Room> rooms;
        private List<Utility> utilities;

        //Constructor

        //Get Set

        //Calculate homesize

    }
}