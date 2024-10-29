<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowingSchedule.aspx.cs" Inherits="Project3.ShowingSchedule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Schedule Showing</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblClientInformation" Text="<h1>Client Information</h1>" runat="server"></asp:Label>
            <br/>
            <asp:Label ID="lblFirstName" Text="First Name" runat="server" />
            <asp:TextBox ID="txtFirstName" placeholder="Enter First Name" runat="server" />
            <br/>
            <asp:Label ID="lblLastName" Text="Last Name" runat="server" />
            <asp:TextBox ID="txtLastName" placeholder="Enter Last Name" runat="server" />
            <br/>
            <asp:Label ID="lblAddress" Text="Address" runat="server" />
            <br/>
            <asp:Label ID="lblStreet" Text="Street" runat="server" />
            <asp:TextBox ID="txtStreet" placeholder="Enter Street" runat="server" />
            <br/>
            <asp:Label ID="lblCity" Text="City" runat="server" />
            <asp:TextBox ID="txtCity" placeholder="Enter City" runat="server" />
            <br/>
            <asp:Label ID="lblState" Text="State" runat="server" />
            <asp:TextBox ID="txtState" placeholder="Enter State" runat="server" />
            <br/>
            <asp:Label ID="lblZipCode" Text="Zip Code" runat="server" />
            <asp:TextBox ID="txtZipCode" placeholder="Enter Zip Code" runat="server" />
            <br/>
            <asp:Label ID="lblPhoneNumber" Text="Phone Number" runat="server" />
            <asp:TextBox ID="txtPhoneNumber" placeholder="Enter Phone Number" runat="server" />
            <br/>
            <asp:Label ID="lblEmail" Text="Email" runat="server" />
            <asp:TextBox ID="txtEmail" placeholder="Enter Email" runat="server" />
        </div>
        <div>
            <asp:Label ID="lblShowingTime" Text="Schedule Showing Time" runat="server"></asp:Label>
            <asp:Calendar ID="calShowingTime" runat="server"></asp:Calendar>
            <br/>
            <asp:Label ID="lblTime" Text="Time: " runat="server"></asp:Label>
            <asp:DropDownList ID="ddlHour" runat="server"></asp:DropDownList>
            <asp:Label ID="lblTimeDivider" Text=" : " runat="server"></asp:Label>
            <asp:DropDownList ID="ddlMinute" runat="server"></asp:DropDownList>
        </div>
        <asp:Button ID="btnSubmitShowing" Text="Submit Showing Request" runat="server" onClick="btnSubmitShowing_Click"/>
    </form>
</body>
</html>
