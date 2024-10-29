﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeProfile.aspx.cs" Inherits="Project3.HomeProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblHomeInformation" Text="<h1>Add Home Information</h1>"  runat="server" />
            <br />
            <asp:PlaceHolder ID="phImages" runat="server"> </asp:PlaceHolder>
            <br />
            <asp:Label ID="lblHomeAddress" runat="server" />
            <br/>
            <asp:Button ID="btnScheduleShowing" Text="Schedule Showing" runat="server" onclick="btnScheduleShowing_Click"/>
            <asp:Button ID="btnMakeOffer" runat="server" Text="Make Offer" onclick="btnMakeOffer_Click"/>
            <br/>
            <asp:Label ID="lblHomeCost" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblPropertyType" runat="server" />
            <br/>
            <asp:Label ID="lblYearConstructed" runat="server" />
            <br/>
            <asp:Label ID="lblGarageType" runat="server" />
            <br/>
            <asp:Label ID="lblHomeDescription" runat="server" />
            <br/>
            <asp:Label ID="lblSaleStatus" runat="server" />
            <br/>
            <asp:Label ID="lblTempatureControlInformation" runat="server" />
            <br/>
            <asp:Label ID="lblUtilityInformation" Text="<h1>Utilities</h1>" runat="server" />
            <asp:PlaceHolder ID="phUtilities" runat="server"> </asp:PlaceHolder>
            <br/>
            <asp:Label ID="lblRoomInformation" Text="<h1>Rooms</h1>"  runat="server" />
            <asp:PlaceHolder ID="phRooms" runat="server"> </asp:PlaceHolder>
            <br/>
            <asp:Label ID="lblAmenityInformation" Text="<h1>Amenities</h1>"  runat="server" />
            <asp:PlaceHolder ID="phAmenities" runat="server"> </asp:PlaceHolder>
        </div>
    </form>
</body>
</html>