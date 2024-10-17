﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    //enum for types of utilities
    public enum UtilityTypes
    {
        Electricity,
        NaturalGas,
        WellWater,
        PublicSupply,
        PublicSewer, 
        Septic,
        Internet,
        CableTelevision,
        TrashCollection,
        Telephone,
        WasteManagement,
        StormwaterManagement
    }
    //Contains data for Utility
    internal class Utility
    {
        //Fields
        private int utilityID;
        private UtilityTypes type;
        private string information;

        //Constructor
        public Utility(int utilityID, UtilityTypes type, string information) 
        {
            this.utilityID = utilityID;
            this.type = type;
            this.information = information;
        }

        //Get Set
        public int UtilityID
        {
            get { return utilityID; }
            set { utilityID = value; }
        }
        public UtilityTypes Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Information
        {
            get { return information; }
            set { information = value; }
        }

        //Return Deep Copy
        internal Utility DeepCopy()
        {
            return new Utility(utilityID, type, information);
        }
    }
}