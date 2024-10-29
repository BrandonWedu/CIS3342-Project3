using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RetailClassLibrary;

namespace Project3
{
    public partial class ShowingSchedule : System.Web.UI.Page
    {
        Home home;
        protected void Page_Load(object sender, EventArgs e)
        {
            home = (Home)Session["Home"];
            if (!IsPostBack)
            {
                for (int i = 1; i < 25; i++) 
                { 
                    ddlHour.Items.Add(i.ToString());
                }
                for (int i = 0; i < 60; i+= 15) 
                { 
                    ddlMinute.Items.Add(i == 0? "00" : i.ToString());
                }
            }
        }

        protected void btnSubmitShowing_Click(object sender, EventArgs e)
        {
            Client client = new Client(txtFirstName.Text, txtLastName.Text, new Address(txtStreet.Text, txtCity.Text, txtState.Text, txtZipCode.Text), txtPhoneNumber.Text, txtEmail.Text);
            DateTime timeRequested = new DateTime(calShowingTime.SelectedDate.Year, calShowingTime.SelectedDate.Month, calShowingTime.SelectedDate.Day, int.Parse(ddlHour.Text), int.Parse(ddlMinute.Text), 0);
            RetailHelper.ScheduleShowing(new Showing(
                home,
                client,
                DateTime.Now,
                timeRequested,
                ShowingStatus.Pending
                ));
        }
    }
}