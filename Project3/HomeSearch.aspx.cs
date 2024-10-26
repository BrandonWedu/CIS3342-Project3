using RetailClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project3
{
    public partial class HomeSearch : System.Web.UI.Page
    {
        Agent agent;
        Homes homes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Agent"] != null)
            {
                agent = (Agent)Session["Agent"];
                //put code back here when ready to test
            }
            if (!IsPostBack)
            {

            }
            homes = RetailHelper.GetHomes();
            foreach (Home home in homes.List)
            {
                GenerateHome(home);
            }
        }
        protected void GenerateHome(Home home)
        {
            Panel panel = new Panel();
            panel.ID = $"Homeontainer{home.HomeID}";
            panel.CssClass = "home-container";

            System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
            //find main image 
            image.ImageUrl =

            if (agent != null)
            {
                //Add edit home button
                Button editButton = new Button();
                editButton.ID = $"btnEdit_{home.HomeID}";
                editButton.Text = "Edit Home";
                editButton.Click += new EventHandler(EditHome);
                panel.Controls.Add(editButton);
            }
            phHomes.Controls.Add(panel);
        }
        protected void EditHome(object sender, EventArgs e)
        {
            string buttonID = ((Button)sender).ID;
            string homeID = buttonID.Split('_').Last();
            //Redirect to home and save in session 
        }
    }
}