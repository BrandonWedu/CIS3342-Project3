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
    public partial class AccountRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Companies companies = RealEstateHelper.GetCompanies();
            foreach(Company company in companies.List)
            {
                ddlCompany.Items.Add($"Name: {company.Name} ID: {company.CompanyID}");
            }
        }

        protected string ValidateInput()
        {
            string errorString = "";
            if(!Validation.IsAlphaNumeric(txtUsername.Text) || !Validation.IsUnder51Characters(txtUsername.Text))
            {
                errorString = "Enter a valid Username<br/>";

            } 
            else
            {
                errorString += RealEstateHelper.GetAgentByUsername(txtUsername.Text) == null ? string.Empty : "Username Taken<br/>";
            }
            errorString += (Validation.IsPassword(txtPassword.Text) && Validation.IsUnder51Characters(txtPassword.Text)) ? string.Empty : "Enter a valid Password</br>";
            errorString += (Validation.IsAlphaNumeric(txtFirstName.Text) && Validation.IsUnder51Characters(txtFirstName.Text)) ? string.Empty : "Enter a valid First Name</br>";
            errorString += (Validation.IsAlphaNumeric(txtLastName.Text) && Validation.IsUnder51Characters(txtLastName.Text)) ? string.Empty : "Enter a valid Last Name</br>";
            errorString += (Validation.IsAlphaNumericWithSpace(txtPersonalStreet.Text) && Validation.IsUnder51Characters(txtPersonalStreet.Text)) ? string.Empty : "Enter a valid Personal Street</br>";
            errorString += (Validation.IsAlphaNumericWithSpace(txtPersonalCity.Text) && Validation.IsUnder51Characters(txtPersonalCity.Text)) ? string.Empty : "Enter a valid Personal City</br>";
            errorString += (Validation.IsAlphaNumericWithSpace(txtPersonalState.Text) && Validation.IsUnder51Characters(txtPersonalState.Text)) ? string.Empty : "Enter a valid Personal State</br>";
            errorString += (Validation.IsAlphaNumericWithDash(txtPersonalZipCode.Text) && Validation.IsUnder51Characters(txtPersonalZipCode.Text)) ? string.Empty : "Enter a valid Personal Zip Code</br>";
            errorString += (Validation.IsAlphaNumeric(txtPersonalPhoneNumber.Text) && Validation.IsUnder51Characters(txtPersonalPhoneNumber.Text)) ? string.Empty : "Enter a valid Personal Phone Number</br>";
            errorString += (Validation.IsEmail(txtPersonalEmail.Text) && Validation.IsUnder51Characters(txtPersonalEmail.Text)) ? string.Empty : "Enter a valid Personal Email</br>";
            errorString += (Validation.IsAlphaNumericWithSpace(txtWorkStreet.Text) && Validation.IsUnder51Characters(txtWorkStreet.Text)) ? string.Empty : "Enter a valid Work Street</br>";
            errorString += (Validation.IsAlphaNumericWithSpace(txtWorkCity.Text) && Validation.IsUnder51Characters(txtWorkCity.Text)) ? string.Empty : "Enter a valid Work City</br>";
            errorString += (Validation.IsAlphaNumericWithSpace(txtWorkState.Text) && Validation.IsUnder51Characters(txtWorkState.Text)) ? string.Empty : "Enter a valid Work State</br>";
            errorString += (Validation.IsAlphaNumericWithDash(txtWorkZipCode.Text) && Validation.IsUnder51Characters(txtWorkZipCode.Text)) ? string.Empty : "Enter a valid Work Zip Code</br>";
            errorString += (Validation.IsAlphaNumeric(txtWorkPhoneNumber.Text) && Validation.IsUnder51Characters(txtWorkPhoneNumber.Text)) ? string.Empty : "Enter a valid Work Phone Number</br>";
            errorString += (Validation.IsEmail(txtWorkEmail.Text) && Validation.IsUnder51Characters(txtWorkEmail.Text)) ? string.Empty : "Enter a valid Work Email</br>";

            if (pnlAddCompany.Visible)
            {
                if(!Validation.IsAlphaNumericWithSpace(txtCompanyName.Text) || !Validation.IsUnder51Characters(txtCompanyName.Text))
                {
                    errorString += "Enter a valid Company Name";
                } else
                {
                    errorString += RealEstateHelper.GetCompanyByName(txtCompanyName.Text) == null ? string.Empty : "Company Already Exists</br>";
                }
                errorString += (Validation.IsAlphaNumericWithSpace(txtCompanyStreet.Text) && Validation.IsUnder51Characters(txtCompanyStreet.Text)) ? string.Empty : "Enter a valid Company Street m</br>";
                errorString += (Validation.IsAlphaNumericWithSpace(txtCompanyCity.Text) && Validation.IsUnder51Characters(txtCompanyCity.Text)) ? string.Empty : "Enter a valid Company City</br>";
                errorString += (Validation.IsAlphaNumericWithSpace(txtCompanyState.Text) && Validation.IsUnder51Characters(txtCompanyState.Text)) ? string.Empty : "Enter a valid Company State</br>";
                errorString += (Validation.IsAlphaNumericWithDash(txtCompanyZipCode.Text) && Validation.IsUnder51Characters(txtCompanyZipCode.Text)) ? string.Empty : "Enter a valid Company Zip Code</br>";
                errorString += (Validation.IsAlphaNumeric(txtCompanyPhoneNumber.Text) && Validation.IsUnder51Characters(txtCompanyPhoneNumber.Text)) ? string.Empty : "Enter a valid Company Phone Number</br>";
                errorString += (Validation.IsEmail(txtCompanyEmail.Text) && Validation.IsUnder51Characters(txtCompanyEmail.Text)) ? string.Empty : "Enter a valid Company Email</br>";
            }
            return errorString;
        }

        protected void btnSubmitAccountRegistration_Click(object sender, EventArgs e)
        {
            string err = ValidateInput();
            if (err.Length > 0)
            {
                lblError.Text = err;
                return;
            }
            if (RealEstateHelper.AccountRegistration(
                new Agent
                    (
                        new LoginData(txtUsername.Text, txtPassword.Text),
                        new Address(txtWorkStreet.Text, txtWorkCity.Text, txtWorkState.Text, txtWorkZipCode.Text),
                        txtWorkPhoneNumber.Text,
                        txtWorkEmail.Text,
                        pnlCompany.Visible == true? 
                            RealEstateHelper.GetCompanyByID(ExtractID(ddlCompany.SelectedValue)) :
                            new Company( txtCompanyName.Text, new Address(txtCompanyStreet.Text, txtCompanyCity.Text, txtCompanyState.Text, txtCompanyZipCode.Text), txtCompanyPhoneNumber.Text, txtCompanyEmail.Text),
                        txtFirstName.Text,
                        txtLastName.Text,
                        new Address(txtPersonalStreet.Text, txtPersonalCity.Text, txtPersonalState.Text, txtPersonalZipCode.Text),
                        txtPersonalPhoneNumber.Text, 
                        txtPersonalEmail.Text
                    )
                ) == false)
            {
                //update error username exists
            } else
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountLogin.aspx");
        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btnAddNewCompany_Click(object sender, EventArgs e)
        {
            pnlAddCompany.Visible = true;
            pnlCompany.Visible = false;
        }

        protected void btnExistingCompany_Click(object sender, EventArgs e)
        {
            pnlAddCompany.Visible = false;
            pnlCompany.Visible = true;
        }
        
        protected int ExtractID(string companySelection)
        {
            //get the index after "ID: "
            int index = companySelection.IndexOf("ID: ") + 4;
            return int.Parse(companySelection.Substring(index));
        }
    }
}