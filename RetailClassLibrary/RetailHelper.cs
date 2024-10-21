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
            //make a new account
            return WriteAgent.CreateNewAgent(agent);     
        }
    }
}
