<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback = "True" CodeBehind="AccountLogin.aspx.cs" Inherits="Project3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sillow - Agent Login</title>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;300;400;500;600;700;800;900&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="styles/style.css" />
    <link rel="stylesheet" href="styles/item-container.css" />
    <link rel="stylesheet" href="styles/main-item-container.css" />
</head>
<body>
    <form id="LoginPage" runat="server">
        <header>
            <asp:Literal ID="litTitle" Text="<h1>Sillow: Agent Login</h1>" runat="server"></asp:Literal>
            <div>
                <asp:Button ID="btnDashboard" Text="Dashboard" runat="server" OnClick="btnDashboard_Click" />
                <asp:Button ID="btnSignUp" Text="Sign Up" runat="server" OnClick="btnSignUp_Click" />
            </div>
        </header>
        <div class="main-item-container">
            <div class="item-container">
                <asp:Label ID="lblUsername" Text="Username" runat="server" />
                <asp:TextBox ID="txtUsername" placeholder="Enter Username" runat="server" />
                <asp:Label ID="lblPassword" Text="Password" runat="server" />
                <asp:TextBox ID="txtPassword" placeholder="Enter Password" TextMode="Password" runat="server" />
                <asp:button ID="btnSubmitLogin" Text="Login" runat="server" OnClick="btnSubmitLogin_Click" />
                <asp:Label ID="lblError" CssClass="error" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
