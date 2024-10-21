using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    //Implements basic information for users of the application
    public abstract class User
    {
        //Fields
        protected string firstName;
        protected string lastName;
        protected Address address;
        protected string phoneNumber;
        protected string email;

        //Constructor
        public User(string firstName, string lastName, Address address, string phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        //Get and set
        public string FirstName
        {
            get { return firstName; }
            set { this.firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { this.lastName = value; }
        }
        public Address Address
        {
            get { return address.DeepCopy(); }
            set { this.address = value.DeepCopy(); }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { this.phoneNumber = value; }
        }
        public string Email
        {
            get { return email; }
            set { this.email = value; }
        }
    }
}
