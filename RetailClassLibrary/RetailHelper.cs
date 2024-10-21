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
        public static (bool, int) Login(string username, string password)
        {
            // return (true, agentID) if login successful
            // return (false, -1) if login unsucessful
            return ReadAgent.Login(username, password);
        }

        //Account Registration
        public static bool AccountRegistration(Agent agent)
        {
            //returns based on creation sucess 
            return WriteAgent.CreateNewAgent(agent);     
        }

        //Get Agent by ID
        public static (bool, Agent) GetAgentByID(int agentID)
        {
            // return (true, agent) if successful
            // return (false, null) if unsucessful
            return ReadAgent.GetAgentByID(agentID);
        }
    }
}
