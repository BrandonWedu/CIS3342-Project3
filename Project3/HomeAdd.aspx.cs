using RetailClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project3
{
    public partial class AddHome : System.Web.UI.Page
    {
        Agent agent;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["agent"] != null)
            {
                agent = (Agent)Session["agent"];
            }
        }
    }
}