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
            //returns based on creation sucess 
            return WriteAgent.CreateNewAgent(agent);     
        }

        //Get Agent by ID
        public static Agent GetAgentByID(int agentID)
        {
            // return (true, agent) if successful
            // return (false, null) if unsucessful
            return ReadAgent.GetAgentByID(agentID);
        }

        //Create a new Home
        public static bool CreateNewHome(Home home)
        {
            int homeID = WriteHome.CreateNewHome(home);
            if(homeID > -1)
            {
                //add all the other data to home based on id

                return true;
            }
            return false;
        }
    }
}
