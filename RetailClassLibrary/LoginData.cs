using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibrary
{
    //Holds User Login information
    public class LoginData : ICloneable<LoginData>
    {
        //Fields
        private string username;
        private string password;

        //Constructor
        public LoginData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        //Get
        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        //Return a Deep Copy
        public LoginData DeepCopy()
        {
            return new LoginData(username, password);
        }
    }
}
