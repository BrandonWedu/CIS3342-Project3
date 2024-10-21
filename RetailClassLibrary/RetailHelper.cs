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
        public static bool Login(string username, string password)
        {
            //Return if login was successful
            return ReadAgent.Login(username, password);
        }

        //Account Registration
        public static bool AccountRegistration()
        {
            //Run sql to make a new user
        }
    }
}
