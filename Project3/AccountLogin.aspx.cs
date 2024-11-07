using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealEstateClassLibrary;
using Utilities;

namespace Project3
{
    public partial class Login : System.Web.UI.Page
    {
        Agent agent;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmitLogin_Click(object sender, EventArgs e)
        {
            if (!Validation.IsAlphaNumeric(txtUsername.Text) || !Validation.IsPassword(txtPassword.Text))
            {
                lblError.Text = "You must enter a proper username and password.";
                return;
            }
            int login = RealEstateHelper.Login(txtUsername.Text, txtPassword.Text);
            if (login > -1)
            {
                agent = RealEstateHelper.GetAgentByID(login);
                Session["Agent"] = agent;
                Response.Redirect("Index.aspx");
            } else
            {
                lblError.Text = "Username or Password Incorrect.";
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountRegistration.aspx");
        }
        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}