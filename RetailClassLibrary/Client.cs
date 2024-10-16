using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    //Contains Client data and extends user
    public class Client : User
    {
        //Fields
        private int clientID;

        //Constructor
        public Client(int clientID, string firstName, string lastName, Address address, string phoneNumber, string email) : base(firstName, lastName, address, phoneNumber, email)
        {
            this.clientID = clientID;
        }

        //Get Set
        public int ClientID
        {
            get { return this.clientID; }
            set { this.clientID = value; }
        }

    }
}
