using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    //Enum for sale types
    public enum TypeOfSale 
    {
        ConventionalMorgage,
        Cash
    }
    //Enum for OfferStatus
    public enum OfferStatus
    {
        review,
        accepted,
        rejected
    }

    //Contains data for an Offer
    internal class Offer
    {
        //Fields
        private int? offerID;
        private Home home;
        private Client client;
        private double amount;
        private TypeOfSale type;
        private bool sellPriorHomeFirst;
        private DateTime moveInByDate;
        private OfferStatus status;
        private OfferContingencies contingencies;

        // Constructor with no ID
        public Offer(Home home, Client client, double amount, TypeOfSale type, bool sellPriorHomeFirst, DateTime moveInByDate, OfferStatus status, OfferContingencies contingencies)
        {
            offerID = null;
            this.home = home.DeepCopy();
            this.client = client.DeepCopy();
            this.amount = amount;
            this.type = type;
            this.sellPriorHomeFirst = sellPriorHomeFirst;
            this.moveInByDate = new DateTime(moveInByDate.Ticks);
            this.status = status;
            this.contingencies = contingencies.DeepCopy();
        }

        // Constructor with ID
        public Offer(int offerID, Home home, Client client, double amount, TypeOfSale type, bool sellPriorHomeFirst, DateTime moveInByDate, OfferStatus status, OfferContingencies contingencies)
        {
            this.offerID = offerID;
            this.home = home.DeepCopy();
            this.client = client.DeepCopy();
            this.amount = amount;
            this.type = type;
            this.sellPriorHomeFirst = sellPriorHomeFirst;
            this.moveInByDate = new DateTime(moveInByDate.Ticks);
            this.status = status;
            this.contingencies = contingencies.DeepCopy();
        }

        //Get Set
        public int? OfferID
        {
            get { return offerID; }
            set { offerID = value; }
        }

        public Home Home
        {
            get { return home.DeepCopy(); }
            set { home = value.DeepCopy(); }
        }

        public Client Client
        {
            get { return client.DeepCopy(); }
            set { client = value.DeepCopy(); }
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public TypeOfSale Type
        {
            get { return type; }
            set { type = value; }
        }

        public bool SellPriorHomeFirst
        {
            get { return sellPriorHomeFirst; }
            set { sellPriorHomeFirst = value; }
        }

        public DateTime MoveInByDate
        {
            get { return new DateTime(moveInByDate.Ticks); }
            set { moveInByDate = new DateTime(value.Ticks); }
        }

        public OfferStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public OfferContingencies Contingencies
        {
            get { return contingencies.DeepCopy(); }
            set { contingencies = value.DeepCopy(); }
        }
    }
}
