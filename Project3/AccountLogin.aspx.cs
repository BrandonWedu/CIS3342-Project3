using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RetailClassLibrary;

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
            int login = RetailHelper.Login(txtUsername.Text, txtPassword.Text);
            lblSucess.Text = (login > -1).ToString() + login.ToString();
            if (login > -1)
            {
                agent = RetailHelper.GetAgentByID(login);
                Session["Agent"] = agent;
                Response.Redirect("Index.aspx");
            }
        }
    }
}