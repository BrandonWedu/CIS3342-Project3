using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    internal class Contingency : ICloneable<Contingency>
    {
        //Fields
        private int? contengencyID;
        private string description;

        //Constructor without id
        public Contingency(string description) 
        {
            contengencyID = null;
            this.description = description;
        }
        //Constructor with id
        public Contingency(int? contengencyID,  string description)
        {
            this.contengencyID = contengencyID;
            this.description += description;
        }

        //GetSet
        public int? ContengencyID
        {
            get { return contengencyID; }
            set { contengencyID = value; }
        }
        public string Description
        {
            get { return description; } 
            set { description = value; }
        }

        //Implement Interface
        public Contingency DeepCopy()
        {
            return new Contingency(contengencyID, description);
        }
    }
}
