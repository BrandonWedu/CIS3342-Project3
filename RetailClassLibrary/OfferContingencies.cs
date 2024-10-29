using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    //Contains a list of Contingency
    public class OfferContingencies : ListOfObjects<Contingency>, ICloneable<OfferContingencies>
    {
        //Constructor without list
        public OfferContingencies() { } 
        //Constructor with list 
        public OfferContingencies(List<Contingency> contingencies)
        {
            foreach(Contingency contingency in contingencies)
            {
                Add(contingency);
            }
        }

        //Implement Interface
        public OfferContingencies DeepCopy()
        {
            return new OfferContingencies(ListDeepCopy());
        }
    }
}
