<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowingView.aspx.cs" Inherits="Project3.ShowingView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblShowing" Text="<h1>Showings</h1>" runat="server"></asp:Label>
            <asp:PlaceHolder ID="phShowing" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
