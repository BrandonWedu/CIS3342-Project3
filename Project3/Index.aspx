<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback = "True" CodeBehind="Index.aspx.cs" Inherits="Project3.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>sillow - Dashboard</title>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;300;400;500;600;700;800;900&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="styles/style.css" />
    <link rel="stylesheet" href="styles/home-search-container.css" />
    <link rel="stylesheet" href="styles/search-container.css" />
    <link rel="stylesheet" href="styles/main-item-container.css" />
</head>
<body>
    <form id="frmIndex" runat="server">
        <header>
            <asp:Literal ID="litTitle" Text="<h1>Sillow: Dashboard</h1>" runat="server"></asp:Literal>
            <div>
                <asp:Label ID="lblAgentName" runat="server" Visible="false"></asp:Label>
                <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" />
                <asp:Button ID="btnSignUp" Text="Sign Up" runat="server" OnClick="btnSignUp_Click" />
                <asp:Button ID="btnSignOut" Text="Sign Out" runat="server" Visible="false" OnClick="btnSignOut_Click"/>
            </div>
        </header>
        <div>
            <asp:Label ID="lblLoginText" runat="server"></asp:Label>
            <br />
            <asp:Button ID="btnAddHome" Text="Add Home" runat="server" OnClick="btnAddHome_Click" />
            <asp:Button ID="btnViewShowings" Text="View Showings" runat="server" OnClick="btnViewShowings_Click" />
            <asp:Button ID="btnViewOffers" Text="View Offers" runat="server" OnClick="btnViewOffers_Click" />
        </div>
        
        <div class="search-container">
           <asp:Label ID="lblSearch" Text="<h1>Search</h1>" runat="server"></asp:Label>
            <div>
                <asp:Label ID="lblSearchStreet" Text="Street:" runat="server"></asp:Label>
                <asp:TextBox ID="txtSearchStreet" runat="server"></asp:TextBox>
                <asp:Label ID="lblSearchCity" Text="City:" runat="server"></asp:Label>
                <asp:TextBox ID="txtSearchCity" runat="server"></asp:TextBox>
                <asp:Label ID="lblSearchState" Text="State:" runat="server"></asp:Label>
                <asp:TextBox ID="txtSearchState" runat="server"></asp:TextBox>
                <asp:Label ID="lblSearchZipCode" Text="ZipCode:" runat="server"></asp:Label>
                <asp:TextBox ID="txtSearchZipCode" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblSearchPriceRange" Text="Price Range:" runat="server"></asp:Label>
                <asp:Label ID="lblSearchPriceRangeMin" Text="Min:" runat="server"></asp:Label>
                <asp:TextBox ID="txtSearchPriceRangeMin" runat="server"></asp:TextBox>
                <asp:Label ID="lblSearchPriceRangeMax" Text="Max:" runat="server"></asp:Label>
                <asp:TextBox ID="txtSearchPriceRangeMax" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblSearchPropertyType" Text="Property Type:" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlPropertyType" runat="server"></asp:DropDownList>
            </div>
            <div>
                <asp:Label ID="lblSearchHouseSize" Text="HouseSize:" runat="server"></asp:Label>
                <asp:Label ID="lblSearchHouseSizeMin" Text="Min:" runat="server"></asp:Label>
                <asp:TextBox ID="txtSearchHouseSizeMin" runat="server"></asp:TextBox>
                <asp:Label ID="lblSearchHouseSizeMax" Text="Max:" runat="server"></asp:Label>
                <asp:TextBox ID="txtSearchHouseSizeMax" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblSearchBedrooms" Text="Minimum Bedrooms:" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlSearchBedrooms" runat="server"></asp:DropDownList>
            </div>
            <div>
                <asp:Label ID="lblSearchBathrooms" Text="Minimum Bathrooms:" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlSearchBathrooms" runat="server"></asp:DropDownList>
            </div>
            <div>
                <asp:Label ID="lblSearchAmenities" Text="Amenities:" runat="server"></asp:Label>
            </div>
            <div class="grid">
                <asp:PlaceHolder ID="phAmenities" runat="server"></asp:PlaceHolder>
            </div>
            <div>
                <asp:Label ID="lblSearchMarketStatus" Text="Status:" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlSearchMarketStatus" runat="server"></asp:DropDownList>
            </div>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <asp:Label ID="lblSearchError" Visible="false" runat="server"></asp:Label>
        </div>
        <div class="main-item-container">
           <asp:Label ID="lblHomes" Text="<h1>Homes</h1>" runat="server"></asp:Label>
           <asp:PlaceHolder ID="phHomes" runat="server"> </asp:PlaceHolder> 
        </div>
    </form>
</body>
</html>
