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
            if (Session["Agent"] != null)
            {
                agent = (Agent)Session["Agent"];
                loginTest.Text = agent.LoginData.Username;
                btnLogin.Visible = false;
                btnSignUp.Visible = false;
                btnSignOut.Visible = true;
            } else
            {
                btnLogin.Visible = true;
                btnSignUp.Visible = true;
                btnSignOut.Visible = false;
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
                Session["Agent"] = agent;
                Response.Redirect("HomeAdd.aspx");
            }
        }

        protected void btnViewHomes_Click(object sender, EventArgs e)
        {
            if (agent != null)
            {
                Session["Agent"] = agent;
            }
            Response.Redirect("SearchHome.aspx");
        }

        protected void btnViewShowings_Click(object sender, EventArgs e)
        {
            if (agent != null)
            {
                Session["Agent"] = agent;
            Response.Redirect("ShowingView.aspx");
            }
        }

        protected void btnViewOffers_Click(object sender, EventArgs e)
        {
            if (agent != null)
            {
                Session["Agent"] = agent;
                Response.Redirect("OfferView.aspx");
            }
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session["Agent"] = null;
            Response.Redirect("Index.aspx");
        }
    }
}