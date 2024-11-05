using RetailClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project3
{
    public partial class ShowingView : System.Web.UI.Page
    {
        Agent agent;
        Showings showings;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Agent"] == null){
                Response.Redirect("Index.aspx");
            }
            agent = (Agent)Session["Agent"];
            showings = RetailHelper.GetShowingsByAgentID((int)agent.AgentID);
            for (int i = 0; i < showings.List.Count; i++)
            {
                GenerateShowing(i);
            }
        }
        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void GenerateShowing(int count)
        {
            Panel panel = new Panel();
            panel.ID = $"pnlShowingContainer{count}";
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
            lblClientNameData.Text = showings.List[count].Client.FirstName + " " + showings.List[count].Client.LastName;
            lblClientNameData.ID = $"lblClientNameData{count}";
            panel.Controls.Add(lblClientNameData);
            
            Label lblClientAddress = new Label();
            lblClientAddress.Text = "Client Address";
            lblClientAddress.ID = $"lblClientAddress{count}";
            panel.Controls.Add(lblClientAddress);

            Label lblClientAddressData  = new Label();
            lblClientAddressData.Text = showings.List[count].Client.Address.ToString();
            lblClientAddressData.ID = $"lblClientAddressData{count}";
            panel.Controls.Add(lblClientAddressData);

            Label lblClientPhoneNumber = new Label();
            lblClientPhoneNumber.Text = "Client PhoneNumber:";
            lblClientPhoneNumber.ID = $"lblClientPhoneNumber{count}";
            panel.Controls.Add(lblClientPhoneNumber);

            Label lblClientPhoneNumberData = new Label();
            lblClientPhoneNumberData.Text = showings.List[count].Client.PhoneNumber;
            lblClientPhoneNumberData.ID = $"lblClientPhoneNumberData{count}";
            panel.Controls.Add(lblClientPhoneNumberData);

            Label lblClientEmail = new Label();
            lblClientEmail.Text = "Client Email:";
            lblClientEmail.ID = $"lblClientEmail{count}";
            panel.Controls.Add(lblClientEmail);

            Label lblClientEmailData = new Label();
            lblClientEmailData.Text = showings.List[count].Client.Email;
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
            lblHomeAddressData .Text = showings.List[count].Home.Address.ToString();
            lblHomeAddressData .ID = $"lblHomeAddressData {count}";
            panel.Controls.Add(lblHomeAddressData );

            Label lblShowingTime = new Label();
            lblShowingTime.Text = "Showing Time:";
            lblShowingTime.ID = $"lblShowingTime{count}";
            panel.Controls.Add(lblShowingTime);
            
            Label lblShowingTimeData = new Label();
            lblShowingTimeData.Text = $"{showings.List[count].ShowingTime}";
            lblShowingTimeData.ID = $"lblShowingTimeData{count}";
            panel.Controls.Add(lblShowingTimeData);

            Label lblShowingRequestCreated = new Label();
            lblShowingRequestCreated.Text = $"Showing Request Created:";
            lblShowingRequestCreated.ID = $"lblShowingRequestCreated{count}";
            panel.Controls.Add(lblShowingRequestCreated);

            Label lblShowingRequestCreatedData = new Label();
            lblShowingRequestCreatedData.Text = $"{showings.List[count].TimeRequestCreated}";
            lblShowingRequestCreatedData.ID = $"lblShowingRequestCreatedData{count}";
            panel.Controls.Add(lblShowingRequestCreatedData);

            Label lblShowingStatus = new Label();
            lblShowingStatus.Text = $"Showing Status:";
            lblShowingStatus.ID = $"lblShowingStatus{count}";
            panel.Controls.Add(lblShowingStatus);

            DropDownList ddlShowingStatus = new DropDownList();
            ddlShowingStatus.ID = $"ddlShowingStatus{count}";
            foreach(ShowingStatus type in Enum.GetValues(typeof(ShowingStatus)))
            {
                ddlShowingStatus.Items.Add(type.ToString());
            }
            ddlShowingStatus.SelectedIndex = (int)showings.List[count].Status;
            panel.Controls.Add(ddlShowingStatus);

            Button btnUpdate = new Button();
            btnUpdate.ID = $"btnUpdate_{count}";
            btnUpdate.Text = "Update Status";
            btnUpdate.Click += new EventHandler(btnUpdate_Click);
            panel.Controls.Add(btnUpdate);

            phShowing.Controls.Add(panel);
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            int buttonID = int.Parse(((Button)sender).ID.Split('_').Last());
            Session["Home"] = showings.List[buttonID].Home;
            Response.Redirect("HomeProfile.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int buttonID = int.Parse(((Button)sender).ID.Split('_').Last());
            //update home status
            Showing showing = showings.List[buttonID];
            DropDownList ddlShowingStatus = (DropDownList)phShowing.FindControl($"ddlShowingStatus{buttonID}");
            showing.Status = (ShowingStatus)ddlShowingStatus.SelectedIndex;
            RetailHelper.UpdateShowingStatus(showing);
        }
    }
}