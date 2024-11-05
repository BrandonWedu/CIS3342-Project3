<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowingView.aspx.cs" Inherits="Project3.ShowingView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sillow - Showing Manager</title>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;300;400;500;600;700;800;900&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="styles/style.css" />
    <link rel="stylesheet" href="styles/item-container.css" />
    <link rel="stylesheet" href="styles/main-item-container.css" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <asp:Literal ID="litTitle" Text="<h1>Sillow: Showing Manager</h1>" runat="server"></asp:Literal>
            <div>
                <asp:Button ID="btnDashboard" Text="Dashboard" runat="server" OnClick="btnDashboard_Click" />
                <asp:Button ID="btnHomeProfile" Text="Home Profile" runat="server" OnClick="btnHomeProfile_Click" />
            </div>
        </header>

        <div class="item-container">
            <asp:Literal ID="litShowing" Text="<h2>Showings</h2>" runat="server"></asp:Literal>
            <asp:PlaceHolder ID="phShowing" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
