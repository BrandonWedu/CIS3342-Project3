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
            Companies companies = RetailHelper.GetCompanies();
            foreach(Company company in companies.List)
            {
                ddlCompany.Items.Add($"Name: {company.Name} ID: {company.CompanyID}");
            }
        }

        protected void btnSubmitAccountRegistration_Click(object sender, EventArgs e)
        {
            if (RetailHelper.AccountRegistration(
                new Agent
                    (
                        new LoginData(txtUsername.Text, txtPassword.Text),
                        new Address(txtWorkStreet.Text, txtWorkCity.Text, txtWorkState.Text, txtWorkZipCode.Text),
                        txtWorkPhoneNumber.Text,
                        txtWorkEmail.Text,
                        pnlCompany.Visible == true? 
                            RetailHelper.GetCompanyByID(ExtractID(ddlCompany.SelectedValue)) :
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