<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback = "True" CodeBehind="Index.aspx.cs" Inherits="Project3.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>sillow - Dashboard</title>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;300;400;500;600;700;800;900&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="styles/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <asp:Literal ID="litTitle" Text="<h1>Sillow: Dashboard</h1>" runat="server"></asp:Literal>
            <div>
                <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" />
                <asp:Button ID="btnSignUp" Text="Sign Up" runat="server" OnClick="btnSignUp_Click" />
                <asp:Button ID="btnSignOut" Text="Sign Out" runat="server" Visible="false" OnClick="btnSignOut_Click"/>
            </div>
        </header>
        <div>
            <asp:Label ID="loginTest" runat="server"></asp:Label>
            <asp:Button ID="btnAddHome" Text="Add Home" runat="server" OnClick="btnAddHome_Click" />
            <asp:Button ID="btnViewShowings" Text="View Showings" runat="server" OnClick="btnViewShowings_Click" />
            <asp:Button ID="btnViewOffers" Text="View Offers" runat="server" OnClick="btnViewOffers_Click" />
        </div>


        
       <asp:Label ID="lblHomes" Text="<h1>Homes</h1>" runat="server"></asp:Label>
       <asp:PlaceHolder ID="phHomes" runat="server"> </asp:PlaceHolder> 




    </form>
</body>
</html>
