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
    public partial class OfferCreate : System.Web.UI.Page
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
                ViewState["ContingencyCount"] = 0;
                foreach (TypeOfSale typeOfSale in Enum.GetValues(typeof(TypeOfSale)))
                {
                    ddlTypeOfSale.Items.Add(typeOfSale.ToString());
                }
            }
            if (ViewState["ContingencyCount"] != null)
            {
                int contingencyCount = (int)ViewState["ContingencyCount"];
                for (int i = 0; i < contingencyCount; i++)
                {
                    GenerateContingency(i);
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

        protected void GenerateContingency(int count)
        {
            Panel panel = new Panel();
            panel.ID = $"pnlContingency{count}";
            panel.CssClass = "item-container";

            Label lblDescription = new Label();
            lblDescription.ID = $"lblDescription{count}";
            lblDescription.Text = "Contengency Description: ";
            panel.Controls.Add(lblDescription);

            TextBox txtDescription = new TextBox();
            txtDescription.ID = $"txtDescription{count}";
            txtDescription.Attributes["Placeholder"] = "Enter Contingency Description";
            panel.Controls.Add(txtDescription);

            Button btnDelete = new Button();
            btnDelete.ID = $"btnContingencyDelete_{count}";
            btnDelete.Text = "Delete";
            btnDelete.Click += new EventHandler(btnDeleteContingency_Click);
            panel.Controls.Add(btnDelete);

            phContingencies.Controls.Add(panel);
        }
        protected void btnAddContingency_Click(object sender, EventArgs e)
        {
            int count = (int)ViewState["ContingencyCount"];
            GenerateContingency(count);
            ViewState["ContingencyCount"] = count + 1;
        }
        protected void btnDeleteContingency_Click(object sender, EventArgs e)
        {
            string divID = ((Button)sender).ID.Split('_').Last();
            phContingencies.FindControl($"pnlContingency{divID}").Visible = false;
        }

        protected string Validator()
        {
            string errorString = "";

            errorString += (Validation.IsAlphaNumeric(txtFirstName.Text) && Validation.IsUnder51Characters(txtFirstName.Text)) ? string.Empty : "Enter a valid First Name</br>";
            errorString += (Validation.IsAlphaNumeric(txtLastName.Text) && Validation.IsUnder51Characters(txtLastName.Text)) ? string.Empty : "Enter a valid Last Name</br>";
            errorString += (Validation.IsAlphaNumeric(txtPhoneNumber.Text) && Validation.IsUnder51Characters(txtPhoneNumber.Text)) ? string.Empty : "Enter a valid Phone Number</br>";
            errorString += (Validation.IsEmail(txtEmail.Text) && Validation.IsUnder51Characters(txtEmail.Text)) ? string.Empty : "Enter a valid Email</br>";

            errorString += (Validation.IsAlphaNumericWithSpace(txtStreet.Text) && Validation.IsUnder51Characters(txtStreet.Text)) ? string.Empty : "Enter a valid Street</br>";
            errorString += (Validation.IsAlphaNumericWithSpace(txtCity.Text) && Validation.IsUnder51Characters(txtCity.Text)) ? string.Empty : "Enter a valid City</br>";
            errorString += (Validation.IsAlphaNumericWithSpace(txtState.Text) && Validation.IsUnder51Characters(txtState.Text)) ? string.Empty : "Enter a valid State</br>";
            errorString += (Validation.IsAlphaNumericWithDash(txtZipCode.Text) && Validation.IsUnder51Characters(txtZipCode.Text)) ? string.Empty : "Enter a valid Zip Code</br>";

            errorString += (Validation.IsInteger(txtAmount.Text)) ? string.Empty : "Enter a valid Offer Amount (integer)</br>";
            errorString += ddlTypeOfSale.SelectedIndex>-1 ? string.Empty : "Select a Type Of Sale</br>";
            errorString += rdSellPriorHomeFirst.SelectedIndex > -1 ? string.Empty : "Select a Type Of Sale</br>";
            errorString += calMoveInByDate.SelectedDate > DateTime.Now ? string.Empty : "Select A Valid Move In By Date</br>";

            for (int i = 0; i < (int)ViewState["ContingencyCount"]; i++)
            {
                if (phContingencies.FindControl($"pnlContingency{i}").Visible == true)
                {
                    TextBox txtDescription = (TextBox)phContingencies.FindControl($"txtDescription{i}");
                    errorString += ((txtDescription.Text).Length > 0 ? string.Empty : "Enter valid Contingencies</br>");
                    return errorString;
                }
            }
            return errorString;
        }
        protected void btnSubmitOffer_Click(object sender, EventArgs e)
        {
            string err = Validator();
            if(err.Length > 0)
            {
                lblError.Text = err;
                lblError.Visible = true;
                return;
            } 

            OfferContingencies contingencies = new OfferContingencies();
            for (int i = 0; i < (int)ViewState["ContingencyCount"]; i++)
            {
                if (phContingencies.FindControl($"pnlContingency{i}").Visible == true)
                {
                    TextBox txtDescription = (TextBox)phContingencies.FindControl($"txtDescription{i}");
                    contingencies.Add(new Contingency(txtDescription.Text));
                }
            }

            Offer offer = new Offer(
                home,
                new Client(
                    txtFirstName.Text,
                    txtLastName.Text,
                    new Address (
                        txtStreet.Text, txtState.Text, txtCity.Text, txtZipCode.Text
                        ),
                    txtPhoneNumber.Text,
                    txtEmail.Text
                    ),
                DateTime.Now,
                int.Parse(txtAmount.Text),
                (TypeOfSale)ddlTypeOfSale.SelectedIndex,
                rdSellPriorHomeFirst.SelectedIndex == 0? true : false,
                calMoveInByDate.SelectedDate,
                OfferStatus.review,
                contingencies
                );
            RealEstateHelper.CreateOffer( offer );
            Response.Redirect("index.aspx");
        }
    }
}