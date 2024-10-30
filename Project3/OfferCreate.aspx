<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfferCreate.aspx.cs" Inherits="Project3.OfferCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblClientInformation" Text="<h1>Client Information</h1>" runat="server"></asp:Label>
            <br/>
            <asp:Label ID="lblFirstName" Text="First Name" runat="server" />
            <asp:TextBox ID="txtFirstName" placeholder="Enter First Name" runat="server" />
            <br/>
            <asp:Label ID="lblLastName" Text="Last Name" runat="server" />
            <asp:TextBox ID="txtLastName" placeholder="Enter Last Name" runat="server" />
            <br/>
            <asp:Label ID="lblAddress" Text="Address" runat="server" />
            <br/>
            <asp:Label ID="lblStreet" Text="Street" runat="server" />
            <asp:TextBox ID="txtStreet" placeholder="Enter Street" runat="server" />
            <br/>
            <asp:Label ID="lblCity" Text="City" runat="server" />
            <asp:TextBox ID="txtCity" placeholder="Enter City" runat="server" />
            <br/>
            <asp:Label ID="lblState" Text="State" runat="server" />
            <asp:TextBox ID="txtState" placeholder="Enter State" runat="server" />
            <br/>
            <asp:Label ID="lblZipCode" Text="Zip Code" runat="server" />
            <asp:TextBox ID="txtZipCode" placeholder="Enter Zip Code" runat="server" />
            <br/>
            <asp:Label ID="lblPhoneNumber" Text="Phone Number" runat="server" />
            <asp:TextBox ID="txtPhoneNumber" placeholder="Enter Phone Number" runat="server" />
            <br/>
            <asp:Label ID="lblEmail" Text="Email" runat="server" />
            <asp:TextBox ID="txtEmail" placeholder="Enter Email" runat="server" />
        </div>
        <div>
            <asp:Label ID="lblOfferInformation" Text="Offer Information" runat="server"></asp:Label>
            <br/>
            <asp:Label ID="lblAmount" Text="Offer Amount" runat="server"></asp:Label>
            <asp:TextBox ID="txtAmount" Placeholder="Enter Offer Amount" runat="server"></asp:TextBox>
            <asp:DropDownList ID="ddlTypeOfSale" runat="server"></asp:DropDownList>
            <asp:Label ID="lblSellPriorHomeFirst" Text="Sell Prior Home First" runat="server"></asp:Label>
            <asp:RadioButtonList ID="rdSellPriorHomeFirst" runat="server">
                <asp:ListItem ID="rdTrue" Text="Required" runat="server" />
                <asp:ListItem ID="rdFalse" Text="Not Required" runat="server" />
            </asp:RadioButtonList>
            <asp:Calendar ID="calMoveInByDate" runat="server"></asp:Calendar>
        </div>
        <div>
            <asp:Label ID="lblContingencies" Text="<h1>Contingencies</h1>" runat="server"></asp:Label>
            <asp:PlaceHolder ID="phContingencies" runat="server"></asp:PlaceHolder>
            <asp:Button ID="btnAddContingency" Text="Add Contingency" runat="server" OnClick="btnAddContingency_Click" />
        </div>
        <asp:Button ID="btnSubmitOffer" Text="Submit Offer" runat="server" onclick="btnSubmitOffer_Click"/>
    </form>
</body>
</html>
