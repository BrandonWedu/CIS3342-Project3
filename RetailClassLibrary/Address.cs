using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    //Contains data for an Address
    [Serializable]
    public class Address : ICloneable<Address>
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
            get { return zipCode; }
            set { this.zipCode = value; }
        }

        public override string ToString()
        {
            return $"{street}, {city}, {state} {ZipCode}";
        }

        public Address DeepCopy()
        {
            return new Address(Street, City, State, ZipCode);
        }
    }
}
