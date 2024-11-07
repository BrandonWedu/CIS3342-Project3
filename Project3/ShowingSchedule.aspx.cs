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
    public partial class ShowingSchedule : System.Web.UI.Page
    {
        Home home;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Home)Session["Home"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            home = (Home)Session["Home"];
            if (!IsPostBack)
            {
                for (int i = 1; i < 24; i++) 
                { 
                    ddlHour.Items.Add(i.ToString());
                }
                for (int i = 0; i < 60; i+= 15) 
                { 
                    ddlMinute.Items.Add(i == 0? "00" : i.ToString());
                }
            }
        }
        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
        protected void btnHomeProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeProfile.aspx");
        }

        protected string Validator()
        {
            string errorString = "";

            errorString += (Validation.IsAlphaNumeric(txtFirstName.Text) && Validation.IsUnder51Characters(txtFirstName.Text)) ? string.Empty : "Enter a valid First Name</br>";
            errorString += (Validation.IsAlphaNumeric(txtLastName.Text) && Validation.IsUnder51Characters(txtLastName.Text)) ? string.Empty : "Enter a valid Last Name</br>";
            errorString += (Validation.IsAlphaNumeric(txtPhoneNumber.Text) && Validation.IsUnder51Characters(txtPhoneNumber.Text)) ? string.Empty : "Enter a valid Phone Number</br>";
            errorString += (Validation.IsEmail(txtEmail.Text) && Validation.IsUnder51Characters(txtEmail.Text)) ? string.Empty : "Enter a valid Email</br>";

            errorString += (Validation.IsAlphaNumeric(txtStreet.Text) && Validation.IsUnder51Characters(txtStreet.Text)) ? string.Empty : "Enter a valid Street</br>";
            errorString += (Validation.IsAlphaNumeric(txtCity.Text) && Validation.IsUnder51Characters(txtCity.Text)) ? string.Empty : "Enter a valid City</br>";
            errorString += (Validation.IsAlphaNumeric(txtState.Text) && Validation.IsUnder51Characters(txtState.Text)) ? string.Empty : "Enter a valid State</br>";
            errorString += (Validation.IsAlphaNumericWithDash(txtZipCode.Text) && Validation.IsUnder51Characters(txtZipCode.Text)) ? string.Empty : "Enter a valid Zip Code</br>";

            errorString += calShowingTime.SelectedDate > DateTime.Now ? string.Empty : "Select A Valid Showing Date</br>";
            errorString += ddlHour.SelectedIndex>-1 && ddlMinute.SelectedIndex>-1 ? string.Empty : "Select a valid time</br>";

            return errorString;
        }

        protected void btnSubmitShowing_Click(object sender, EventArgs e)
        {
            string err = Validator();
            if (err.Length > 0)
            {
                lblError.Text = err;
                lblError.Visible = true;
                return;
            }
            Client client = new Client(txtFirstName.Text, txtLastName.Text, new Address(txtStreet.Text, txtCity.Text, txtState.Text, txtZipCode.Text), txtPhoneNumber.Text, txtEmail.Text);
            DateTime timeRequested = new DateTime(calShowingTime.SelectedDate.Year, calShowingTime.SelectedDate.Month, calShowingTime.SelectedDate.Day, int.Parse(ddlHour.Text), int.Parse(ddlMinute.Text), 0);
            RealEstateHelper.ScheduleShowing(new Showing(
                home,
                client,
                DateTime.Now,
                timeRequested,
                ShowingStatus.Pending
                ));
            Response.Redirect("HomeProfile.aspx");
        }
    }
}