using RealEstateClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project3
{
    public partial class OfferView : System.Web.UI.Page
    {
        Agent agent;
        Offers offers;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Agent"] == null){
                Response.Redirect("Index.aspx");
            }
            agent = (Agent)Session["Agent"];
            offers = RealEstateHelper.GetOffersByAgentID((int)agent.AgentID);
            for (int i = 0; i < offers.List.Count; i++)
            {
                GenerateOffer(i);
            }
        }
        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
        protected void GenerateOffer(int count)
        {
            Panel panel = new Panel();
            panel.ID = $"pnlOfferContainer{count}";
            panel.CssClass = "item-container";
            
            Literal litClientInformation = new Literal();
            litClientInformation.Text = "<h2>Client Information</h2>";
            litClientInformation.ID = $"litClientInformation{count}";
            panel.Controls.Add(litClientInformation);


            Label lblClientName = new Label();
            lblClientName.Text = "Client Name:";
            lblClientName.ID = $"lblClientName{count}";
            panel.Controls.Add(lblClientName);
            
            Label lblClientNameData = new Label();
            lblClientNameData.Text = offers.List[count].Client.FirstName + " " + offers.List[count].Client.LastName;
            lblClientNameData.ID = $"lblClientNameData{count}";
            panel.Controls.Add(lblClientNameData);
            
            Label lblClientAddress = new Label();
            lblClientAddress.Text = "Client Address";
            lblClientAddress.ID = $"lblClientAddress{count}";
            panel.Controls.Add(lblClientAddress);

            Label lblClientAddressData  = new Label();
            lblClientAddressData.Text = offers.List[count].Client.Address.ToString();
            lblClientAddressData.ID = $"lblClientAddressData{count}";
            panel.Controls.Add(lblClientAddressData);

            Label lblClientPhoneNumber = new Label();
            lblClientPhoneNumber.Text = "Client PhoneNumber:";
            lblClientPhoneNumber.ID = $"lblClientPhoneNumber{count}";
            panel.Controls.Add(lblClientPhoneNumber);

            Label lblClientPhoneNumberData = new Label();
            lblClientPhoneNumberData.Text = offers.List[count].Client.PhoneNumber;
            lblClientPhoneNumberData.ID = $"lblClientPhoneNumberData{count}";
            panel.Controls.Add(lblClientPhoneNumberData);

            Label lblClientEmail = new Label();
            lblClientEmail.Text = "Client Email:";
            lblClientEmail.ID = $"lblClientEmail{count}";
            panel.Controls.Add(lblClientEmail);

            Label lblClientEmailData = new Label();
            lblClientEmailData.Text = offers.List[count].Client.Email;
            lblClientEmailData.ID = $"lblClientEmailData{count}";
            panel.Controls.Add(lblClientEmailData);

            Button btnHome = new Button();
            btnHome.ID = $"btnHome_{count}";
            btnHome.Text = "Home Listing";
            btnHome.Click += new EventHandler(btnHome_Click);
            panel.Controls.Add(btnHome);

            Label lblHomeAddress = new Label();
            lblHomeAddress.Text = "Home Address:";
            lblHomeAddress.ID = $"lblHomeAddress{count}";
            panel.Controls.Add(lblHomeAddress);

            Label lblHomeAddressData  = new Label();
            lblHomeAddressData .Text = offers.List[count].Home.Address.ToString();
            lblHomeAddressData .ID = $"lblHomeAddressData {count}";
            panel.Controls.Add(lblHomeAddressData);

            Label lblOfferAmount = new Label();
            lblOfferAmount.Text = "Offer Amount:";
            lblOfferAmount.ID = $"lblOfferAmount{count}";
            panel.Controls.Add(lblOfferAmount);
            
            Label lblOfferAmountData = new Label();
            lblOfferAmountData.Text = offers.List[count].Amount.ToString("C2");
            lblOfferAmountData.ID = $"lblOfferAmountData{count}";
            panel.Controls.Add(lblOfferAmountData);

            Label lblTypeOfSale = new Label();
            lblTypeOfSale.Text = "Type Of Sale:";
            lblTypeOfSale.ID = $"lblTypeOfSale{count}";
            panel.Controls.Add(lblTypeOfSale);
            
            Label lblTypeOfSaleData = new Label();
            lblTypeOfSaleData.Text = offers.List[count].Type.ToString();
            lblTypeOfSaleData.ID = $"lblTypeOfSaleData{count}";
            panel.Controls.Add(lblTypeOfSaleData);

            Label lblSellPriorHomeFirst = new Label();
            lblSellPriorHomeFirst.Text = "Sell Prior Home First:";
            lblSellPriorHomeFirst.ID = $"lblSellPriorHomeFirst{count}";
            panel.Controls.Add(lblSellPriorHomeFirst);
            
            Label lblSellPriorHomeFirstData = new Label();
            lblSellPriorHomeFirstData.Text = offers.List[count].SellPriorHomeFirst ? "Required" : "Not Required";
            lblSellPriorHomeFirstData.ID = $"lblSellPriorHomeFirstData{count}";
            panel.Controls.Add(lblSellPriorHomeFirstData);

            Label lblMoveInByDate = new Label();
            lblMoveInByDate.Text = "Move in by Date:";
            lblMoveInByDate.ID = $"lblMoveInByDate{count}";
            panel.Controls.Add(lblMoveInByDate);
            
            Label lblMoveInByDateData = new Label();
            lblMoveInByDateData.Text = offers.List[count].MoveInByDate.ToString();
            lblMoveInByDateData.ID = $"lblMoveInByDateData{count}";
            panel.Controls.Add(lblMoveInByDateData);

            Label lblOfferCreated = new Label();
            lblOfferCreated.Text = $"Offer Date Created:";
            lblOfferCreated.ID = $"lblOfferCreated{count}";
            panel.Controls.Add(lblOfferCreated);

            Label lblOfferCreatedData = new Label();
            lblOfferCreatedData.Text = offers.List[count].OfferCreated.ToString();
            lblOfferCreatedData.ID = $"lblOfferCreatedData{count}";
            panel.Controls.Add(lblOfferCreatedData);

            Label lblOfferStatus = new Label();
            lblOfferStatus.Text = $"Offer Status:";
            lblOfferStatus.ID = $"lblShowingStatus{count}";
            panel.Controls.Add(lblOfferStatus);

            DropDownList ddlOfferStatus = new DropDownList();
            ddlOfferStatus.ID = $"ddlOfferStatus{count}";
            foreach(OfferStatus type in Enum.GetValues(typeof(OfferStatus)))
            {
                ddlOfferStatus.Items.Add(type.ToString());
            }
            ddlOfferStatus.SelectedIndex = (int)offers.List[count].Status;
            panel.Controls.Add(ddlOfferStatus);

            for(int i = 0; i < offers.List[count].Contingencies.List.Count; i++)
            {
                Label lblContingency = new Label(); 
                lblContingency.ID = $"lblContingency{count}{i}";
                lblContingency.Text = $"Contingency {i + 1}:";
                panel.Controls.Add(lblContingency);

                Label lblContingencyData = new Label(); 
                lblContingencyData.ID = $"lblContingencyData{count}{i}";
                lblContingencyData.Text = offers.List[count].Contingencies.List[i].Description;
                panel.Controls.Add(lblContingencyData);
            }

            Button btnUpdate = new Button();
            btnUpdate.ID = $"btnUpdate_{count}";
            btnUpdate.Text = "Update Status";
            btnUpdate.Click += new EventHandler(btnUpdate_Click);
            panel.Controls.Add(btnUpdate);
            
            phOffer.Controls.Add(panel);
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            int buttonID = int.Parse(((Button)sender).ID.Split('_').Last());
            Session["Home"] = offers.List[buttonID].Home;
            Response.Redirect("HomeProfile.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int buttonID = int.Parse(((Button)sender).ID.Split('_').Last());
            //update home status
            Offer offer = offers.List[buttonID];
            DropDownList ddlOfferStatus = (DropDownList)phOffer.FindControl($"ddlOfferStatus{buttonID}");
            offer.Status = (OfferStatus)ddlOfferStatus.SelectedIndex;
            RealEstateHelper.UpdateOffer(offer);
        }
    }
}