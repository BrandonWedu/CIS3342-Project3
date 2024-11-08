using RealEstateClassLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

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
                lblAgentName.Text = $"Hello, {agent.FirstName} {agent.LastName}";
                lblAgentName.Visible = true;
                lblLoginText.Text =$"Hello {agent.FirstName} {agent.LastName} ({agent.LoginData.Username})! What would you like to do?";
                btnLogin.Visible = false;
                btnSignUp.Visible = false;
                btnSignOut.Visible = true;
                btnAddHome.Visible = true;
                btnViewOffers.Visible = true;
                btnViewShowings.Visible = true;
            } 
            else
            {
                btnLogin.Visible = true;
                btnSignUp.Visible = true;
                btnSignOut.Visible = false;
                btnAddHome.Visible = false;
                btnViewOffers.Visible = false;
                btnViewShowings.Visible = false;
            }
            if (!IsPostBack)
            {
                ddlPropertyType.Items.Add("Empty");
                foreach(PropertyType propertyType in Enum.GetValues(typeof(PropertyType)))
                {
                    ddlPropertyType.Items.Add(propertyType.ToString());
                }
                ddlSearchMarketStatus.Items.Add("Empty");
                foreach(SaleStatus saleStatus in Enum.GetValues(typeof(SaleStatus)))
                {
                    ddlSearchMarketStatus.Items.Add(saleStatus.ToString());
                }
                ddlSearchBedrooms.Items.Add("Empty");
                ddlSearchBathrooms.Items.Add("Empty");
                for (int i = 1; i < 11; i++)
                {
                    ddlSearchBedrooms.Items.Add(i.ToString());
                    ddlSearchBathrooms.Items.Add(i.ToString());
                    ddlSearchBathrooms.Items.Add((i+0.5).ToString());
                }
            }
            foreach(AmenityType amenity in Enum.GetValues(typeof(AmenityType)))
            {
                Panel pnlGridItem = new Panel();
                pnlGridItem.ID = $"pnlAmenityContainer_{(int)amenity}";

                CheckBox checkBox = new CheckBox();
                checkBox.ID = $"Amenity_{(int)amenity}";
                checkBox.Text = amenity.ToString();

                pnlGridItem.Controls.Add(checkBox);
                phAmenities.Controls.Add(pnlGridItem);
            }

            homes = RealEstateHelper.GetHomes();
            foreach (Home home in homes.List)
            {
                GenerateHome(home);
            }
        }
        //search button
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Get Data
            string street = txtSearchStreet.Text.Length == 0 ? null : txtSearchStreet.Text;
            string city = txtSearchCity.Text.Length == 0 ? null : txtSearchCity.Text;
            string state = txtSearchState.Text.Length == 0 ? null : txtSearchState.Text;
            string zipCode = txtSearchZipCode.Text.Length == 0 ? null : txtSearchZipCode.Text;
            string priceMin = txtSearchPriceRangeMin.Text.Length == 0 ? null : txtSearchPriceRangeMin.Text;
            string priceMax = txtSearchPriceRangeMax.Text.Length == 0 ? null : txtSearchPriceRangeMax.Text;
            string houseSizeMin = txtSearchHouseSizeMin.Text.Length == 0 ? null : txtSearchHouseSizeMin.Text;
            string houseSizeMax = txtSearchHouseSizeMax.Text.Length == 0 ? null : txtSearchHouseSizeMax.Text;
            int bedroomMin = ddlSearchBedrooms.SelectedIndex;
            int bathroomMin = ddlSearchBathrooms.SelectedIndex;
            //Amenities
            List<AmenityType> amenities = new List<AmenityType>();
            foreach(AmenityType amenity in Enum.GetValues(typeof(AmenityType)))
            {
                CheckBox checkBox = (CheckBox)phAmenities.FindControl($"Amenity_{(int)amenity}");
                if (checkBox.Checked)
                {
                    amenities.Add( amenity );
                }
            }

            PropertyType? propertyType = ddlPropertyType.SelectedIndex == 0? null : (PropertyType?)(ddlPropertyType.SelectedIndex - 1);
            SaleStatus? saleStatus = ddlSearchMarketStatus.SelectedIndex == 0? null : (SaleStatus?)(ddlSearchMarketStatus.SelectedIndex - 1);


            //nullable ints
            int? priceMinData = null;
            int? priceMaxData = null;
            int? houseSizeMinData = null;
            int? houseSizeMaxData = null;

            int? bedroomMinData = bedroomMin == 0? null : (int?)bedroomMin;
            double? bathroomMinData = bathroomMin == 0? null : (double?)double.Parse(ddlSearchBathrooms.SelectedValue);


            //Error Handling
            string searchError = "";
            if (priceMin != null) 
            { 
                if(Validation.IsInteger(priceMin))
                {
                    priceMinData = int.Parse(priceMin);
                }
                else
                {
                    searchError += "Price Min must be an integer"; 
                }
            }
            if (priceMax != null) 
            { 
                if(Validation.IsInteger(priceMax))
                {
                    priceMaxData = int.Parse(priceMax);
                }
                else
                {
                    searchError += "Price Max must be an integer"; 
                }
            }
            if (houseSizeMin != null) 
            { 
                if(Validation.IsInteger(houseSizeMin))
                {
                    houseSizeMinData = int.Parse(houseSizeMin);
                }
                else
                {
                    searchError += "House Size min must be an integer"; 
                }
            }
            if (houseSizeMax != null) 
            { 
                if(Validation.IsInteger(houseSizeMax))
                {
                    houseSizeMaxData = int.Parse(houseSizeMax);
                }
                else
                {
                    searchError += "House Size max must be an integer"; 
                }
            }

            if(searchError.Length > 0)
            {
                lblSearchError.Text = searchError;
                lblSearchError.Visible = true;
                return;
            } 
            else
            {
                homes = RealEstateHelper.SearchHomes(street, city, state, zipCode, priceMinData, priceMaxData, propertyType, houseSizeMinData, houseSizeMaxData, bedroomMinData, bathroomMinData, amenities, saleStatus);
                phHomes.Controls.Clear();
                foreach (Home home in homes.List)
                {
                    GenerateHome(home);
                }
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
            panel.ID = $"pnlHomeContainer{home.HomeID}";
            panel.CssClass = "home-search-container";

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

            Panel pnlInfo = new Panel();
            panel.ID = $"pnlHomeInformationContainer{home.HomeID}";

            //AddCost
            Label lblCost = new Label();
            lblCost.ID = $"lblCost_{home.HomeID}";
            lblCost.Text = $"Asking Price: {home.Cost.ToString("C2")}";
            pnlInfo.Controls.Add(lblCost);

            //Add Address
            Label lblAddress = new Label();
            lblAddress.ID = $"lblAddress_{home.HomeID}";
            lblAddress.Text = $"Home Address: {home.Address.ToString()}";
            pnlInfo.Controls.Add(lblAddress);

            //Add beds
            Label lblBeds = new Label();
            lblBeds.ID = $"lblBeds_{home.HomeID}";
            lblBeds.Text = $"Bedrooms: {home.Rooms.GetBedrooms()}";
            pnlInfo.Controls.Add(lblBeds);

            //Add bath
            Label lblBath = new Label();
            lblBath.ID = $"lblBath_{home.HomeID}";
            int full = home.Rooms.GetFullBaths();
            int half = home.Rooms.GetHalfBaths();
            lblBath.Text = $"Full Bathrooms: {full} </br>Half Bathrooms: {half}";
            pnlInfo.Controls.Add(lblBath);

            //Add size
            Label lblSize = new Label();
            lblSize.ID = $"lblSize_{home.HomeID}";
            lblSize.Text = $"Home Size: {home.HomeSize} Square ft";
            pnlInfo.Controls.Add(lblSize);

            //Add View Home Button
            Button btnViewHome = new Button();
            btnViewHome.ID = $"btnViewHome_{home.HomeID}";
            btnViewHome.Text = "View Home";
            btnViewHome.Click += new EventHandler(btnViewHome_Click);
            pnlInfo.Controls.Add(btnViewHome);

            panel.Controls.Add(pnlInfo);
            phHomes.Controls.Add(panel);
        }
        protected void btnViewHome_Click(object sender, EventArgs e)
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