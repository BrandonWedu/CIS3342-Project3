using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RetailClassLibrary;

namespace Project3
{
    public partial class OfferCreate : System.Web.UI.Page
    {
        Home home;
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void GenerateContingency(int count)
        {
            Panel panel = new Panel();
            panel.ID = $"Contingency{count}";
            panel.CssClass = "add-item-container";

            Label lblDescription = new Label();
            lblDescription.ID = $"lblDescription{count}";
            lblDescription.Text = "Contengency Description: ";
            panel.Controls.Add(lblDescription);
            TextBox txtDescription = new TextBox();
            txtDescription.ID = $"txtDescription{count}";
            txtDescription.Attributes["Placeholder"] = "Enter Contingency Description";
            panel.Controls.Add(txtDescription);

            phContingencies.Controls.Add(panel);
        }
        protected void btnAddContingency_Click(object sender, EventArgs e)
        {
            int count = (int)ViewState["ContingencyCount"];
            GenerateContingency(count);
            ViewState["ContingencyCount"] = count + 1;
        }

        protected void btnSubmitOffer_Click(object sender, EventArgs e)
        {
            OfferContingencies contingencies = new OfferContingencies();
            for (int i = 0; i < (int)ViewState["ContingencyCount"]; i++)
            {
                TextBox txtDescription = (TextBox)phContingencies.FindControl($"txtDescription{i}");
                contingencies.Add(new Contingency(txtDescription.Text));
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
            RetailHelper.CreateOffer( offer );
        }

    }
}