using RealEstateClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project3
{
    public partial class HomeEdit : System.Web.UI.Page
    {
        Agent agent;
        Home home;
        protected void Page_Load(object sender, EventArgs e)
        {
            agent = (Agent)Session["Agent"];
            home = (Home)Session["Home"];
        }
    }
}