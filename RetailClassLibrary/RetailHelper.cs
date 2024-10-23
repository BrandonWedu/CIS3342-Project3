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
        public static int AccountRegistration(Agent agent)
        {
            //Returns -1 if login unsuccessful
            return WriteAgent.CreateNew(agent);     
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
                return true;
            }
            return false;
        }
    }
}
