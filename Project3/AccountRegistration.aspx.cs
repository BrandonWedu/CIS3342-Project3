using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RetailClassLibrary;

namespace Project3
{
    public partial class AccountRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitAccountRegistration_Click(object sender, EventArgs e)
        {
            RetailHelper.AccountRegistration(
                new Agent
                    (
                        new LoginData(txtUsername.Text, txtPassword.Text),
                        new Address(txtWorkStreet.Text, txtWorkCity.Text, txtWorkStreet.Text, txtWorkZipCode.Text),
                        txtWorkPhoneNumber.Text,
                        txtWorkEmail.Text,
                        new Company(int.Parse(txtCompanyID.Text)),
                        txtFirstName.Text,
                        txtLastName.Text,
                        new Address(txtPersonalStreet.Text, txtPersonalCity.Text, txtPersonalStreet.Text, txtPersonalZipCode.Text),
                        txtPersonalPhoneNumber.Text, 
                        txtPersonalEmail.Text
                    )
                );
        }
    }
}