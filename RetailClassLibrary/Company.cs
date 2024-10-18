using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RetailClassLibrary
{
    //Contains Company Information
    internal class Company : ICloneable<Company>
    {
        //Fields
        private int? companyID;
        private string name;
        private Address address;
        private string phoneNumber;
        private string email;

        //Constructor without id
        public Company(string name, Address address, string phoneNumber, string email)
        {
            this.companyID = null;
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
        //Constructor with id
        public Company(int? companyID, string name, Address address, string phoneNumber, string email)
        {
            this.companyID = companyID;
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        //Get Set
        public int? CompanyID
        {
            get { return companyID; }
            set { companyID = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Address Address
        {
            get { return address.DeepCopy(); }
            set { address = value.DeepCopy(); }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        //Return Deep Copy
        public Company DeepCopy()
        {
            return new Company(companyID, name, address.DeepCopy(), phoneNumber, email);
        }
    }
}
