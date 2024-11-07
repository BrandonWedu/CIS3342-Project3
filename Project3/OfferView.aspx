<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback = "True" CodeBehind="OfferView.aspx.cs" Inherits="Project3.OfferView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sillow - Offer Manager</title>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;300;400;500;600;700;800;900&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="styles/style.css" />
    <link rel="stylesheet" href="styles/item-container.css" />
    <link rel="stylesheet" href="styles/main-item-container.css" />
</head>
<body>
    <form id="frmOfferManager" runat="server">
        <header>
            <asp:Literal ID="litTitle" Text="<h1>Sillow: Showing Manager</h1>" runat="server"></asp:Literal>
            <div>
                <asp:Button ID="btnDashboard" Text="Dashboard" runat="server" OnClick="btnDashboard_Click" />
            </div>
        </header>

        <div class="main-item-container">
            <asp:Literal ID="litOffer" Text="<h1>Offers</h1>" runat="server"></asp:Literal>
            <asp:PlaceHolder ID="phOffer" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
