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
            agent = (Agent)Session["Agent"];
            showings = RetailHelper.GetShowings();
            for (int i = 0; i < showings.List.Count; i++)
            {
                GenerateShowing(i);
            }
        }
        protected void GenerateShowing(int count)
        {
            Panel panel = new Panel();
            panel.ID = $"pnlShowingContainer{count}";
            panel.CssClass = "add-item-container";

            Label lblHomeID = new Label();
            lblHomeID.Text = $"Home ID: {showings.List[count].Home.HomeID}";
            lblHomeID.ID = $"lblHomeID{count}";
            panel.Controls.Add(lblHomeID);

            Label lblShowingTime = new Label();
            lblShowingTime.Text = $"Showing Time: {showings.List[count].ShowingTime}";
            lblShowingTime.ID = $"lblShowingTime{count}";
            panel.Controls.Add(lblShowingTime);

            
            Label lblShowingRequestCreated = new Label();
            lblShowingRequestCreated.Text = $"Showing Request Created: {showings.List[count].TimeRequestCreated}";
            lblShowingRequestCreated.ID = $"lblShowingRequestCreated{count}";
            panel.Controls.Add(lblShowingRequestCreated);

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