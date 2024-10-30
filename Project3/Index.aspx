<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project3.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <ul>
                <li>
                    <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" />
                    <asp:Button ID="btnSignUp" Text="Sign Up" runat="server" OnClick="btnSignUp_Click" />
                </li>
            </ul>
        </header>
        <div>
            <asp:Label ID="loginTest" runat="server"></asp:Label>
            <asp:Button ID="btnAddHome" Text="Add Home" runat="server" OnClick="btnAddHome_Click" />
            <asp:Button ID="btnViewHomes" Text="View Home" runat="server" OnClick="btnViewHomes_Click" />
            <asp:Button ID="btnViewShowings" Text="View Showings" runat="server" OnClick="btnViewShowings_Click" />
            <asp:Button ID="btnViewOffers" Text="View Offers" runat="server" OnClick="btnViewOffers_Click" />
        </div>
    </form>
</body>
</html>
