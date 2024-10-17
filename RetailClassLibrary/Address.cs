using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    //Contains data for an Address
    public class Address
    {
        //Fields
        private string street;
        private string city;
        private string state;
        private string zipCode;

        //Constructor
        public Address(string street, string city, string state, string zipCode)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
        }

        //Get Set
        public string Street
        {
            get { return street; }
            set { this.street = value; }
        }
        public string City
        {
            get { return city; }
            set { this.city = value; }
        }
        public string State
        {
            get { return state; }
            set { this.state = value; }
        }
        public string ZipCode
        {
            get { return ZipCode; }
            set { this.zipCode = value; }
        }

        //Return a deep copy of the object
        internal Address DeepCopy()
        {
            return new Address(street, city, state, zipCode);
        }
    }
}
