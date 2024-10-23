using RetailClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project3
{
    public partial class index : System.Web.UI.Page
    {
        Agent agent;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["agent"] != null)
            {
                agent = (Agent)Session["agent"];
                loginTest.Text = agent.LoginData.Username;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountLogin.aspx");
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountRegistration.aspx");
        }

        protected void btnAddHome_Click(object sender, EventArgs e)
        {
            if (agent != null)
            {
                Session["agent"] = agent;
                Response.Redirect("HomeAdd.aspx");
            }
        }
    }
}