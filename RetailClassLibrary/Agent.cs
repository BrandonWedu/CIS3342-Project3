﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    //Contains Agent data and extends User
    internal class Agent : User
    {
        //Fields
        private int agentID;
        private LoginData loginData;
        private Address workAddress;
        private string workPhoneNumber;
        private string workEmail;
        private Company company;

        //Constructor
        public Agent(int agentID, LoginData loginData, string agentUsername, string agentPassword, Address workAddress, string workPhoneNumber, string workEmail, Company company, string firstName, string lastName, Address address, string phoneNumber, string email) : base(firstName, lastName, address, phoneNumber, email)
        {
            this.agentID = agentID;
            this.loginData = loginData;
            this.workAddress = workAddress;
            this.workPhoneNumber = workPhoneNumber;
            this.workEmail = workEmail;
            this.company = company;
        }

        //Get Set
        public int AgentID
        {
            get { return agentID; }
            set { agentID = value; }
        }
        public LoginData LoginData
        {
            get { return loginData.DeepCopy(); }
            set { loginData = value.DeepCopy(); }
        }
        public Address WorkAddress
        {
            get { return workAddress.DeepCopy(); }
            set { workAddress = value.DeepCopy(); }
        }
        public string WorkPhoneNumber
        {
            get { return workPhoneNumber; }
            set { workPhoneNumber = value; }
        }
        public string WorkEmail
        {
            get { return workEmail; }
            set { workEmail = value; }
        }
        public Company Company
        {
            get { return company.DeepCopy(); }
            set { company = value.DeepCopy(); }
        }
    }
}