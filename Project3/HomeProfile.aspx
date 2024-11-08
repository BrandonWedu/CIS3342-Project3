<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback = "True" CodeBehind="HomeProfile.aspx.cs" Inherits="Project3.HomeProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Profile</title>
    <link rel="stylesheet" href="styles/style.css" />
    <link rel="stylesheet" href="styles/home-profile.css" />
    <link rel="stylesheet" href="styles/item-container.css" />
</head>
<body>
    <form id="frmHomeProfile" runat="server">
        <header>
        <asp:Literal ID="litTitle" Text="<h1>Sillow: Home Profile</h1>" runat="server"></asp:Literal>
        <div>
            <asp:Button ID="btnDashboard" Text="Dashboard" runat="server" OnClick="btnDashboard_Click" />
        </div>
        </header>

        <div class="home-profile">
            <asp:Literal ID="litHomeInformation" Text="<h1>Home Information</h1>"  runat="server" />

            <div class="image-container">
                <asp:PlaceHolder ID="phImages" runat="server"> </asp:PlaceHolder>
            </div>

            <div class="main-item-container">
            <asp:Button ID="btnScheduleShowing" Visible="false" Text="Schedule Showing" runat="server" onclick="btnScheduleShowing_Click"/>
            <asp:Button ID="btnMakeOffer" runat="server" Visible="false" Text="Make Offer" onclick="btnMakeOffer_Click"/>

            <div class="item-container">
            <asp:Literal ID="litSaleStatus" Text="<h1>Sale Status</h1>" runat="server" />
            <asp:Label ID="lblSaleStatus" runat="server" />
            </div>

            <div class="item-container">
            <asp:Literal ID="litHomeCost" Text="<h1>Asking Price</h1>" runat="server" />
            <asp:Label ID="lblHomeCost" runat="server"></asp:Label>
            </div>

            <div class="item-container">
            <asp:Literal ID="litTimeOnMarket" Text="<h1>Time On Market</h1>" runat="server" />
            <asp:Label ID="lblTimeOnMarket" runat="server" />
            </div>

            <div class="item-container">
            <asp:Literal ID="litHomeAddress" Text="<h1>Home Address</h1>" runat="server" />
            <asp:Label ID="lblHomeAddress" runat="server" />
            </div>

            <div class="item-container">
            <asp:Literal ID="litHomeDescription" Text="<h1>Home Description</h1>" runat="server" />
            <asp:Label ID="lblHomeDescription" runat="server" />
            </div>

            <div class="item-container">
            <asp:Literal ID="litPropertyType" Text="<h1>Property Type</h1>" runat="server" />
            <asp:Label ID="lblPropertyType" runat="server" />
            </div>
            
            <div class="item-container">
            <asp:Literal ID="litYearConstructed" Text="<h1>Year Constructed</h1>" runat="server" />
            <asp:Label ID="lblYearConstructed" runat="server" />
            </div>

            <div class="item-container">
            <asp:Literal ID="litDarageType" Text="<h1>Garage Type</h1>" runat="server" />
            <asp:Label ID="lblGarageType" runat="server" />
            </div>

            <div class="item-container">
            <asp:Literal ID="litTempatureControl" Text="<h1>Tempature Control</h1>" runat="server" />
            <asp:Label ID="lblTempatureControlInformation" runat="server" />
            </div>

            <div class="item-container">
            <asp:Literal ID="litUtility" Text="<h1>Utilities</h1>" runat="server" />
            <asp:PlaceHolder ID="phUtilities" runat="server"> </asp:PlaceHolder>
            </div>

            <div class="item-container">
            <asp:Literal ID="litRoom" Text="<h1>Rooms</h1>"  runat="server" />
            <asp:PlaceHolder ID="phRooms" runat="server"> </asp:PlaceHolder>
            </div>

            <div class="item-container">
            <asp:Literal ID="litAmenity" Text="<h1>Amenities</h1>"  runat="server" />
            <asp:PlaceHolder ID="phAmenities" runat="server"> </asp:PlaceHolder>
            </div>
        </div>
        </div>
    </form>
</body>
</html>
