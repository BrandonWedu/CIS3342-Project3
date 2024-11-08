using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealEstateClassLibrary;

namespace Project3
{
    public partial class HomeProfile : System.Web.UI.Page
    {
        Home home;
        protected void Page_Load(object sender, EventArgs e)
        {
            home = (Home)Session["Home"];
            //Display Images -------------------------------------------------------------------------------

            //SetValues
            lblTimeOnMarket.Text = home.TimeOnMarket().ToString() + " Days";
            lblHomeAddress.Text = home.Address.ToString();
            lblHomeCost.Text = home.Cost.ToString("C2");
            lblPropertyType.Text = home.PropertyType.ToString();
            lblYearConstructed.Text = home.YearConstructed.ToString();
            lblGarageType.Text = home.GarageType.ToString();
            lblHomeDescription.Text = home.Description.ToString();
            lblSaleStatus.Text = home.SaleStatus.ToString();
            lblTempatureControlInformation.Text = $"Cooling: {home.TemperatureControl.Cooling} <br/> Heating: {home.TemperatureControl.Heating}";

            //Add Utility
            string utilities = "";
            foreach (Utility utility in home.Utilities.List)
            {
                utilities += $"{utility.Type.ToString()} - {utility.Information}</br>";
            }
            Label lblUtilities = new Label();
            lblUtilities.ID = "lblUtilities";
            lblUtilities.Text = utilities;
            phUtilities.Controls.Add(lblUtilities);

            //Add Rooms
            string rooms = "";
            foreach (Room room in home.Rooms.List)
            {
                rooms += $"{room.Type.ToString()}: Height {room.Height} Width: {room.Width}</br>";
            }
            Label lblRooms = new Label();
            lblRooms.ID = "lblRooms";
            lblRooms.Text = rooms;
            phRooms.Controls.Add(lblRooms);

            //Add Amenities
            string amenities = "";
            foreach (Amenity amenity in home.Amenities.List)
            {
                amenities += $"{amenity.Type.ToString()} - {amenity.Description}</br>";
            }
            Label lblAmenities = new Label();
            lblAmenities.ID = "lblAmenities";
            lblAmenities.Text = amenities;
            phAmenities.Controls.Add(lblAmenities);
        }

        protected void GenerateImages()
        {

        }

        protected void btnScheduleShowing_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowingSchedule.aspx");
        }

        protected void btnMakeOffer_Click(object sender, EventArgs e)
        {
            Response.Redirect("OfferCreate.aspx");
        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}