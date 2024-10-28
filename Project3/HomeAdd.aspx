<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeAdd.aspx.cs" Inherits="Project3.HomeAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Home Listing</title>
</head>
<body>
    <form id="frmAddHome" runat="server">
        <asp:Label ID="lblHomeInformation" Text="<h1>Add Home Information</h1>"  runat="server" />
        <br />
            <asp:Label ID="lblHomeStreet" Text="Street" runat="server" />
            <asp:TextBox ID="txtHomeStreet" placeholder="Enter Street" runat="server" />
            <br/>
            <asp:Label ID="lblHomeCity" Text="City" runat="server" />
            <asp:TextBox ID="txtHomeCity" placeholder="Enter City" runat="server" />
            <br/>
            <asp:Label ID="lblHomeState" Text="State" runat="server" />
            <asp:TextBox ID="txtHomeState" placeholder="Enter State" runat="server" />
            <br/>
            <asp:Label ID="lblHomeZipCode" Text="Zip Code" runat="server" />
            <asp:TextBox ID="txtHomeZipCode" placeholder="Enter Zip Code" runat="server" />
            <br/>
        <asp:Label ID="lblHomeCost" Text="Cost" runat="server"></asp:Label>
        <asp:TextBox ID="txtHomeCost" Placeholder="Enter Cost" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblPropertyType" Text="Property Type" runat="server" />
        <asp:DropDownList ID="ddlPropertyType" runat="server" />
            <br/>
        <asp:Label ID="lblYearConstructed" Text="Year Constructed" runat="server" />
        <asp:TextBox ID="txtYearConstructed" Placeholder="Enter Year Constructed" runat="server" />

            <br/>
        <asp:Label ID="lblGarageType" Text="Garage Type" runat="server" />
        <asp:DropDownList ID="ddlGarageType" runat="server" />
            <br/>
        <asp:Label ID="lblHomeDescription" Text="Home Description" runat="server" />
        <asp:TextBox ID="txtHomeDescription" Placeholder="Enter Home Description" runat="server" />
            <br/>
        <asp:Label ID="lblSaleStatus" Text="SaleStatus" runat="server" />
        <asp:DropDownList ID="ddlSaleStatus" runat="server" />
            <br/>

        <asp:Label ID="lblRoomInformation" Text="<h1>Add Room Information</h1>"  runat="server" />
        <asp:PlaceHolder ID="phRooms" runat="server"> </asp:PlaceHolder>
        <asp:Button ID="btnGenerateRoom" Text="Add Room" runat="server" OnClick="btnGenerateRoom_Click" />
        <br />
        <asp:Label ID="lblUtilityInformation" Text="<h1>Add Utility Information</h1>"  runat="server" />
        <asp:PlaceHolder ID="phUtilities" runat="server"> </asp:PlaceHolder>
        <asp:Button ID="btnGenerateUtility" Text="Add Utility" runat="server" OnClick="btnGenerateUtility_Click" />
        <br />
        <asp:Label ID="lblAmenityInformation" Text="<h1>Add Amenity Information</h1>"  runat="server" />
        <asp:PlaceHolder ID="phAmenities" runat="server"> </asp:PlaceHolder>
        <asp:Button ID="btnGenerateAmenity" Text="Add Amenity" runat="server" OnClick="btnGenerateAmenity_Click"/>
        <br />
        <asp:Label ID="lblTempatureControlInformation" Text="<h1>Add Tempature Control Information</h1>"  runat="server" />
        <br />
        <asp:Label ID="lblCooling" Text="Cooling" runat="server" />
        <asp:DropDownList ID="ddlCooling" runat="server" />
            <br/>
        <asp:Label ID="lblHeating" Text="Heating" runat="server" />
        <asp:DropDownList ID="ddlHeating" runat="server" />
            <br/>
        <asp:Label ID="lblImageInformation" Text="<h1>Add Image</h1>"  runat="server" />
        <asp:PlaceHolder ID="phImages" runat="server"> </asp:PlaceHolder>
        <asp:Button ID="btnGenerateImage" Text="Add Image" runat="server" OnClick="btnGenerateImage_Click"/>
        <br />
        <asp:Button ID="btnSubmitHomeListing" Text="Submit Home Listing" runat="server" OnClick="btnSubmitHomeListing_Click" />
    </form>
</body>
</html>
