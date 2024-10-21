using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    //Showing Status Enum
    public enum ShowingStatus
    {

    }
    //Contains data for showing
    internal class Showing : ICloneable<Showing>
    {
        //Fields
        private int? showingID;
        private Home home;
        private Client client;
        private DateTime showingTime;
        private ShowingStatus status;

        // Constructor with no ID
        public Showing(Home home, Client client, DateTime showingTime, ShowingStatus status)
        {
            showingID = null;
            this.home = home.DeepCopy();
            this.client = client.DeepCopy();
            this.showingTime = new DateTime(showingTime.Ticks);
            this.status = status;
        }

        // Constructor with ID
        public Showing(int? showingID, Home home, Client client, DateTime showingTime, ShowingStatus status)
        {
            this.showingID = showingID;
            this.home = home.DeepCopy();
            this.client = client.DeepCopy();
            this.showingTime = new DateTime(showingTime.Ticks);
            this.status = status;
        }

        //Get Set
        public int? ShowingID
        {
            get { return showingID; }
            set { showingID = value; }
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

        public DateTime ShowingTime
        {
            get { return new DateTime(showingTime.Ticks); }
            set { showingTime = new DateTime(value.Ticks); }
        }

        public ShowingStatus Status
        {
            get { return status; }
            set { status = value; }
        }
        
        //Implement Interface
        public Showing DeepCopy()
        {
            return new Showing(showingID, home.DeepCopy(), client.DeepCopy(), new DateTime(showingTime.Ticks), status);
        }
    }
}
