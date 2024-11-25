﻿using RetailClassLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibrary
{
    public static class RealEstateHelper
    {
        // Login
        public static int Login(string username, string password)
        {
            //Returns -1 if login unsuccessful
            return ReadAgent.Login(username, password);
        }

        //Account Registration
        public static bool AccountRegistration(Agent agent)
        {
            if (agent.Company.CompanyID != null)
            {
                return WriteAgent.CreateNew(agent) > -1;     
            }
            int companyID = WriteCompany.CreateNew(agent.Company);
            if(companyID > -1) 
            {
                agent.Company.CompanyID = companyID;
                return WriteAgent.CreateNew(agent) > -1;     
            }
            return false;
        }

        public static Agent GetAgentByUsername(string username)
        {
            return ReadAgent.GetAgentByUsername(username);
        }

        public static Companies GetCompanies()
        {
            return ReadCompany.GetCompanies();
        }
        public static Company GetCompanyByID(int companyID)
        {
            return ReadCompany.GetByCompanyID(companyID);
        }
        public static Company GetCompanyByName(string name)
        {
            return ReadCompany.GetByCompanyName(name);
        }

        //Get Agent by ID
        public static Agent GetAgentByID(int agentID)
        {
            //Returns null if login unsuccessful
            return ReadAgent.GetAgentByID(agentID);
        }

        //Create a new Home
        public static bool CreateNewHome(Home home)
        {
            int homeID = WriteHome.CreateNew(home);
            if(homeID > -1)
            {
                home.HomeID = homeID;
                //add all the other data to home based on id
                foreach (Image image in home.Images.List) 
                {
                    int imageID = WriteHomeImage.CreateNew(homeID, image);
                    if (imageID > -1)
                    {
                        image.ImageID = imageID;
                    }
                }
                foreach (Room room in home.Rooms.List) 
                {
                    int roomID = WriteRoom.CreateNew(homeID, room);
                    if (roomID > -1)
                    {
                        room.RoomID = roomID;
                    }
                }
                foreach (Utility utility in home.Utilities.List) 
                {
                    int utilityID = WriteUtility.CreateNew(homeID, utility);
                    if (utilityID > -1)
                    {
                        utility.UtilityID = utilityID;
                    }
                }
                foreach (Amenity amenity in home.Amenities.List) 
                {
                    int amenityID = WriteAmenity.CreateNew(homeID, amenity);
                    if (amenityID > -1)
                    {
                        amenity.AmenityID = amenityID;
                    }
                }
                int temperatureControlID = WriteTemperatureControl.CreateNew(homeID, home.TemperatureControl);
                if (temperatureControlID > -1)
                {
                    home.TemperatureControl.TempatureControlID = temperatureControlID;
                }
                return true;
            }
            return false;
        }
        public static Homes GetHomes()
        {
            return ReadHome.GetHomes();
        }
        public static Home GetHomeByID(int homeID)
        {
            return ReadHome.GetHomeByID(homeID);
        }
        public static bool ScheduleShowing(Showing showing)
        {
            return WriteShowing.CreateNew(showing) > -1;
        }
        public static Showings GetShowingsByAgentID(int agentID)
        {
            return ReadShowing.GetShowingsByAgentID(agentID);
        }
        public static bool CreateOffer(Offer offer)
        {
            int offerID = WriteOffer.CreateNew(offer);
            if (offerID > -1)
            {
                foreach (Contingency contingency in offer.Contingencies.List)
                {
                   WriteContingency.CreateNew(offerID, contingency);
                }
            }else
            {
                return false;
            }
            return true;
        }
        public static Showings GetShowings()
        {
            return ReadShowing.GetShowings();
        }
        public static bool UpdateShowingStatus(Showing showing)
        {
            return WriteShowing.UpdateStatus(showing);
        }
        public static bool UpdateOffer(Offer offer)
        {
            if (offer.Status.Equals(OfferStatus.accepted)) 
            {
                offer.Home.SaleStatus = SaleStatus.Sold;
                if (!WriteHome.UpdateSaleStatus(offer.Home)) { return false; }
            }
            
             if (offer.Status.Equals(OfferStatus.rejected)) 
            {
                offer.Home.SaleStatus = SaleStatus.ForSale;
                if (!WriteHome.UpdateSaleStatus(offer.Home)) { return false; }
            }

            if(offer.Status.Equals(OfferStatus.accepted) || offer.Status.Equals(OfferStatus.rejected))
            {
                //email the user
                Email email = new Email();
                email.SendMail(offer);
            }
            return WriteOffer.UpdateStatus(offer);
        }
        public static Offers GetOffersByAgentID(int agentID)
        {
            return ReadOffer.GetOffersByAgentID(agentID);
        }
        public static Homes SearchHomes(string street, string city, string state, string zipCode, int? priceMin, int? priceMax, PropertyType? propertyType, int? houseSizeMin, int? houseSizeMax, int? bedroomMin, double? bathroomMin, List<AmenityType> amenities, SaleStatus? saleStatus)
        {
            Homes homes = ReadHome.GetHomes();
            return HomesSearch.Search(homes, street, city, state, zipCode, priceMin, priceMax, propertyType, houseSizeMin, houseSizeMax, bedroomMin, bathroomMin, amenities, saleStatus);
        }
    }
}
