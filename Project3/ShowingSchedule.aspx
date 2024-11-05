<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowingSchedule.aspx.cs" Inherits="Project3.ShowingSchedule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sillow: Schedule Showing</title>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;300;400;500;600;700;800;900&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="styles/style.css" />
    <link rel="stylesheet" href="styles/item-container.css" />
    <link rel="stylesheet" href="styles/main-item-container.css" />
</head>
<body>
    <form id="frmShowingSchedule" runat="server">
        <header>
            <asp:Literal ID="litTitle" Text="<h1>Sillow: Request a Showing</h1>" runat="server"></asp:Literal>
            <div>
                <asp:Button ID="btnDashboard" Text="Dashboard" runat="server" OnClick="btnDashboard_Click" />
                <asp:Button ID="btnHomeProfile" Text="Home Profile" runat="server" OnClick="btnHomeProfile_Click" />
            </div>
        </header>

        <div class="main-item-container">
            <div class="item-container">
                <asp:Literal ID="litClientInformation" Text="<h2>Client Information</h2>" runat="server"></asp:Literal>
                <asp:Label ID="lblFirstName" Text="First Name" runat="server" />
                <asp:TextBox ID="txtFirstName" placeholder="Enter First Name" runat="server" />
                <asp:Label ID="lblLastName" Text="Last Name" runat="server" />
                <asp:TextBox ID="txtLastName" placeholder="Enter Last Name" runat="server" />
                <asp:Label ID="lblPhoneNumber" Text="Phone Number" runat="server" />
                <asp:TextBox ID="txtPhoneNumber" placeholder="Enter Phone Number" runat="server" />
                <asp:Label ID="lblEmail" Text="Email" runat="server" />
                <asp:TextBox ID="txtEmail" placeholder="Enter Email" runat="server" />
                <asp:Literal ID="litAddress" Text="<h2>Client Address</h2>" runat="server" />
                <asp:Label ID="lblStreet" Text="Street" runat="server" />
                <asp:TextBox ID="txtStreet" placeholder="Enter Street" runat="server" />
                <asp:Label ID="lblCity" Text="City" runat="server" />
                <asp:TextBox ID="txtCity" placeholder="Enter City" runat="server" />
                <asp:Label ID="lblState" Text="State" runat="server" />
                <asp:TextBox ID="txtState" placeholder="Enter State" runat="server" />
                <asp:Label ID="lblZipCode" Text="Zip Code" runat="server" />
                <asp:TextBox ID="txtZipCode" placeholder="Enter Zip Code" runat="server" />
            </div>
            
            <div class="item-container">
                <asp:Literal ID="litShowingInformation" Text="<h2>Showing Information</h2>" runat="server"></asp:Literal>
                <asp:Label ID="lblShowingTime" Text="Schedule Showing Time:" runat="server"></asp:Label>
                <asp:Calendar ID="calShowingTime" runat="server"></asp:Calendar>
                <asp:Label ID="lblTime" Text="Time: " runat="server"></asp:Label>
                <div>
                    <asp:DropDownList ID="ddlHour" runat="server"></asp:DropDownList>
                    <asp:Label ID="lblTimeDivider" Text=" : " runat="server"></asp:Label>
                    <asp:DropDownList ID="ddlMinute" runat="server"></asp:DropDownList>
                </div>
            </div>

            <div class="item-container">
                <asp:Button ID="btnSubmitShowing" Text="Submit Showing Request" runat="server" onClick="btnSubmitShowing_Click"/>
                <asp:Label ID="lblError" runat="server" CssClass="error" Visible="false"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
