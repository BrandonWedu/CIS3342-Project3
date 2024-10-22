<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountLogin.aspx.cs" Inherits="Project3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="LoginPage" runat="server">
        <div>
            <asp:Label ID="lblUsername" Text="Username" runat="server" />
            <asp:TextBox ID="txtUsername" placeholder="Enter Username" runat="server" />
            <br/>
            <asp:Label ID="lblPassword" Text="Password" runat="server" />
            <asp:TextBox ID="txtPassword" placeholder="Enter Password" TextMode="Password" runat="server" />
        </div>
        <asp:button ID="btnSubmitLogin" Text="Login" runat="server" OnClick="btnSubmitLogin_Click" />
        <asp:Label ID="lblSucess" runat="server" />
    </form>
</body>
</html>
