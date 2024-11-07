using RealEstateClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project3
{
    public partial class SearchHome : System.Web.UI.Page
    {
        Agent agent;
        Homes homes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Agent"] != null)
            {
                agent = (Agent)Session["Agent"];
            }
            homes = RealEstateHelper.GetHomes();
            foreach (Home home in homes.List)
            {
                GenerateHome(home);
            }
        }
        protected void GenerateHome(Home home)
        {
            //Create DIV
            Panel panel = new Panel();
            panel.ID = $"Homeontainer{home.HomeID}";
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

            //Add edit home button
            if (agent != null)
            {
                Button editButton = new Button();
                editButton.ID = $"btnEdit_{home.HomeID}";
                editButton.Text = "Edit Home";
                editButton.Click += new EventHandler(EditHome);
                panel.Controls.Add(editButton);
            }

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
        protected void EditHome(object sender, EventArgs e)
        {
            string homeID = ((Button)sender).ID.Split('_').Last();
            //Redirect to home and save in session 
            foreach (Home home in homes.List)
            {
                if (home.HomeID == int.Parse(homeID))
                {
                    Session["Home"] = home;
                    Response.Redirect("HomeEdit.aspx");
                }
            }
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