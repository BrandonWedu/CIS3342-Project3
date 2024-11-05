<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfferCreate.aspx.cs" Inherits="Project3.OfferCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create an Offer</title>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;300;400;500;600;700;800;900&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="styles/style.css" />
    <link rel="stylesheet" href="styles/item-container.css" />
    <link rel="stylesheet" href="styles/main-item-container.css" />
</head>
<body>
    <form id="frmOfferCreate" runat="server">
        <header>
            <asp:Literal ID="litTitle" Text="<h1>Sillow: Create an Offer</h1>" runat="server"></asp:Literal>
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
                <asp:Literal ID="litAddress" Text="<h2>Address</h2>" runat="server" />
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
                <asp:Literal ID="litOfferInformation" Text="<h2>Offer Information</h2>" runat="server"></asp:Literal>
                <asp:Label ID="lblAmount" Text="Offer Amount:" runat="server"></asp:Label>
                <asp:TextBox ID="txtAmount" Placeholder="Enter Offer Amount" runat="server"></asp:TextBox>
                <asp:Label ID="lblTypeOfSale" Text="Type of sale:" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlTypeOfSale" runat="server"></asp:DropDownList>
                <asp:Label ID="lblSellPriorHomeFirst" Text="Sell Prior Home First:" runat="server"></asp:Label>
                <div>
                    <asp:RadioButtonList ID="rdSellPriorHomeFirst" runat="server">
                        <asp:ListItem ID="rdTrue" Text="Required" runat="server" />
                        <asp:ListItem ID="rdFalse" Text="Not Required" runat="server" />
                    </asp:RadioButtonList>
                </div>
                <asp:Label ID="lblMoveInByDate" Text="Select Move In By Date:" runat="server"></asp:Label>
                <asp:Calendar ID="calMoveInByDate" runat="server"></asp:Calendar>
            </div>

        <div class="item-container">
            <asp:Literal ID="litContingencies" Text="<h2>Contingencies</h2>" runat="server"></asp:Literal>
            <asp:PlaceHolder ID="phContingencies" runat="server"></asp:PlaceHolder>
            <asp:Button ID="btnAddContingency" Text="Add Contingency" runat="server" OnClick="btnAddContingency_Click" />
        </div>

        <div class="item-container">
            <asp:Button ID="btnSubmitOffer" Text="Submit Offer" runat="server" onclick="btnSubmitOffer_Click"/>
            <asp:Label ID="lblError" cssClass="error" runat="server" Visible="false"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
