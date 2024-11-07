<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback = "True" CodeBehind="HomeAdd.aspx.cs" Inherits="Project3.HomeAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sillow - Create Home Listing</title>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;300;400;500;600;700;800;900&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="styles/style.css" />
    <link rel="stylesheet" href="styles/item-container.css" />
    <link rel="stylesheet" href="styles/main-item-container.css" />
</head>
<body>
    <form id="frmAddHome" runat="server">
        <header>
            <asp:Literal ID="litTitle" Text="<h1>Sillow: Create Home Listing</h1>" runat="server"></asp:Literal>
            <div>
                <asp:Button ID="btnDashboard" Text="Dashboard" runat="server" OnClick="btnDashboard_Click" />
            </div>
        </header>

        <div class="main-item-container">
            <div class="item-container">
                <asp:Literal ID="litHomeAddress" Text="<h2>Home Address</h2>"  runat="server" />
                <asp:Label ID="lblHomeStreet" Text="Street" runat="server" />
                <asp:TextBox ID="txtHomeStreet" placeholder="Enter Street" runat="server" />
                <asp:Label ID="lblHomeCity" Text="City" runat="server" />
                <asp:TextBox ID="txtHomeCity" placeholder="Enter City" runat="server" />
                <asp:Label ID="lblHomeState" Text="State" runat="server" />
                <asp:TextBox ID="txtHomeState" placeholder="Enter State" runat="server" />
                <asp:Label ID="lblHomeZipCode" Text="Zip Code" runat="server" />
                <asp:TextBox ID="txtHomeZipCode" placeholder="Enter Zip Code" runat="server" />
            </div>

            <div class="item-container">
                <asp:Literal ID="litHomeInformation" Text="<h2>Home Information</h2>" runat="server"></asp:Literal>
                <asp:Label ID="lblHomeCost" Text="Cost" runat="server"></asp:Label>
                <asp:TextBox ID="txtHomeCost" Placeholder="Enter Cost" runat="server"></asp:TextBox>
                <asp:Label ID="lblPropertyType" Text="Property Type" runat="server" />
                <asp:DropDownList ID="ddlPropertyType" runat="server" />
                <asp:Label ID="lblYearConstructed" Text="Year Constructed" runat="server" />
                <asp:TextBox ID="txtYearConstructed" Placeholder="Enter Year Constructed" runat="server" />
                <asp:Label ID="lblGarageType" Text="Garage Type" runat="server" />
                <asp:DropDownList ID="ddlGarageType" runat="server" />
                <asp:Label ID="lblHomeDescription" Text="Home Description" runat="server" />
                <asp:TextBox ID="txtHomeDescription" Placeholder="Enter Home Description" runat="server" />
                <asp:Label ID="lblSaleStatus" Text="SaleStatus" runat="server" />
                <asp:DropDownList ID="ddlSaleStatus" runat="server" />
            </div>

            <div class="item-container">
                <asp:Literal ID="litTempatureControlInformation" Text="<h2>Add Tempature Control Information</h2>"  runat="server" />
                <asp:Label ID="lblCooling" Text="Cooling" runat="server" />
                <asp:DropDownList ID="ddlCooling" runat="server" />
                <asp:Label ID="lblHeating" Text="Heating" runat="server" />
                <asp:DropDownList ID="ddlHeating" runat="server" />
            </div>

            <div class="item-container">
                <asp:Literal ID="litRoomInformation" Text="<h2>Add Room Information</h2>"  runat="server" />
                <asp:PlaceHolder ID="phRooms" runat="server"> </asp:PlaceHolder>
                <asp:Button ID="btnGenerateRoom" Text="Add Room" runat="server" OnClick="btnGenerateRoom_Click" />
            </div>

            <div class="item-container">
                <asp:Literal ID="litUtilityInformation" Text="<h2>Add Utility Information</h2>"  runat="server" />
                <asp:PlaceHolder ID="phUtilities" runat="server"> </asp:PlaceHolder>
                <asp:Button ID="btnGenerateUtility" Text="Add Utility" runat="server" OnClick="btnGenerateUtility_Click" />
            </div>

            <div class="item-container">
                <asp:Literal ID="litAmenityInformation" Text="<h2>Add Amenity Information</h2>"  runat="server" />
                <asp:PlaceHolder ID="phAmenities" runat="server"> </asp:PlaceHolder>
                <asp:Button ID="btnGenerateAmenity" Text="Add Amenity" runat="server" OnClick="btnGenerateAmenity_Click"/>
            </div>

            <div class="item-container">
                <asp:Literal ID="litImageInformation" Text="<h2>Add Image</h2>"  runat="server" />
                <asp:PlaceHolder ID="phImages" runat="server"> </asp:PlaceHolder>
                <asp:Button ID="btnGenerateImage" Text="Add Image" runat="server" OnClick="btnGenerateImage_Click"/>
            </div>
            <asp:Button ID="btnSubmitHomeListing" Text="Submit Home Listing" runat="server" OnClick="btnSubmitHomeListing_Click" />
            <asp:Label ID="lblError" CssClass="error" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
