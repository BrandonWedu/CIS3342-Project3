using RealEstateClassLibrary;
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
        Homes homes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Agent"] != null)
            {
                agent = (Agent)Session["Agent"];
                loginTest.Text = agent.LoginData.Username;
                btnLogin.Visible = false;
                btnSignUp.Visible = false;
                btnSignOut.Visible = true;
                btnAddHome.Visible = true;
                btnViewOffers.Visible = true;
                btnViewShowings.Visible = true;
            } else
            {
                btnLogin.Visible = true;
                btnSignUp.Visible = true;
                btnSignOut.Visible = false;
                btnAddHome.Visible = false;
                btnViewOffers.Visible = false;
                btnViewShowings.Visible = false;
            }
            homes = RealEstateHelper.GetHomes();
            foreach (Home home in homes.List)
            {
                GenerateHome(home);
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
        protected void GenerateHome(Home home)
        {
            //Create DIV
            Panel panel = new Panel();
            panel.ID = $"HomeContainer{home.HomeID}";
            panel.CssClass = "home-container";

            //Display Main Image
            System.Web.UI.WebControls.Image imgHome = new System.Web.UI.WebControls.Image();
            foreach (RealEstateClassLibrary.Image image in home.Images.List)
            {
                if (image.MainImage)
                {
                    imgHome.ImageUrl = image.Url;
                }
            }
            panel.Controls.Add(imgHome);

            //AddCost
            Label lblCost = new Label();
            lblCost.ID = $"lblCost_{home.HomeID}";
            lblCost.Text = home.Cost.ToString();
            panel.Controls.Add(lblCost);

            //Add beds
            Label lblBeds = new Label();
            lblBeds.ID = $"lblBeds_{home.HomeID}";
            lblBeds.Text = home.Rooms.GetBedrooms().ToString();
            panel.Controls.Add(lblBeds);

            //Add bath
            Label lblBath = new Label();
            lblBath.ID = $"lblBath_{home.HomeID}";
            int full = home.Rooms.GetFullBaths();
            int half = home.Rooms.GetHalfBaths();
            lblBath.Text = full.ToString() + (full > 1 ? "Bedrooms" : "Bedroom") + " " + half.ToString() + (half > 1 ? "Bedrooms" : "Bedroom");
            panel.Controls.Add(lblBath);

            //Add size
            Label lblSize = new Label();
            lblSize.ID = $"lblSize_{home.HomeID}";
            lblSize.Text = $"{home.HomeSize} Square ft";
            panel.Controls.Add(lblSize);

            //Add Address
            Label lblAddress = new Label();
            lblAddress.ID = $"lblAddress_{home.HomeID}";
            lblAddress.Text = home.Address.ToString();
            panel.Controls.Add(lblAddress);

            //Add View Home Button
            Button btnViewHome = new Button();
            btnViewHome.ID = $"btnViewHome_{home.HomeID}";
            btnViewHome.Text = "View Home";
            btnViewHome.Click += new EventHandler(ViewHome);
            panel.Controls.Add(btnViewHome);

            phHomes.Controls.Add(panel);
        }
        protected void ViewHome(object sender, EventArgs e)
        {
            string homeID = ((Button)sender).ID.Split('_').Last();
            foreach (Home home in homes.List)
            {
                if (home.HomeID == int.Parse(homeID))
                {
                    Session["Home"] = home;
                    Response.Redirect("HomeProfile.aspx");
                }
            }

        }
    }
}