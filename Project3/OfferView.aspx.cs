using RetailClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project3
{
    public partial class OfferView : System.Web.UI.Page
    {
        Agent agent;
        protected void Page_Load(object sender, EventArgs e)
        {
            agent = (Agent)Session["Agent"];
        }
        //show list of homes with number of offers 
        //on click make a new page with all the hoes offers and contingencies for each offer 
        // amke a button for accept and change the status accordingly with button not ddl
    }
}