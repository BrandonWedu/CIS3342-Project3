using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    public static class RetailHelper
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
            return WriteAgent.CreateNew(agent) > -1;     
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
                int tempatureControlID = WriteTemperatureControl.CreateNew(homeID, home.TemperatureControl);
                if (tempatureControlID > -1)
                {
                    home.TemperatureControl.TempatureControlID = tempatureControlID;
                }
                return true;
            }
            return false;
        }
        public static Homes GetHomes()
        {
            return ReadHome.GetHomes();
        }
        public static bool ScheduleShowing(Showing showing)
        {
            return WriteShowing.CreateNew(showing) > -1;
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
    }
}
