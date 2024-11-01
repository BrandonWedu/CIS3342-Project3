<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfferView.aspx.cs" Inherits="Project3.OfferView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblOffer" Text="<h1>Offers</h1>" runat="server"></asp:Label>
            <asp:PlaceHolder ID="phOffer" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
