<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchHome.aspx.cs" Inherits="Project3.SearchHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <asp:Label ID="lblHomes" Text="<h1>Homes</h1>" runat="server"></asp:Label>
           <asp:PlaceHolder ID="phHomes" runat="server"> </asp:PlaceHolder> 
        </div>
    </form>
</body>
</html>
