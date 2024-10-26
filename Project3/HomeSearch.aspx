<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeSearch.aspx.cs" Inherits="Project3.HomeSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Browse</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Homes" Text="<h1>Homes</h1>" runat="server"></asp:Label>
            <asp:PlaceHolder ID="phHomes" runat="server"> </asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
