<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountRegistration.aspx.cs" Inherits="Project3.AccountRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblUsername" Text="Username" runat="server" />
            <asp:TextBox ID="txtUsername" placeholder="Enter Username" runat="server" />
            <br/>
            <asp:Label ID="lblPassword" Text="Password" runat="server" />
            <asp:TextBox ID="txtPassword" placeholder="Enter Password" TextMode="Password" runat="server" />
            <br/>
            <asp:Label ID="lblFirstName" Text="First Name" runat="server" />
            <asp:TextBox ID="txtFirstName" placeholder="Enter First Name" runat="server" />
            <br/>
            <asp:Label ID="lblLastName" Text="Last Name" runat="server" />
            <asp:TextBox ID="txtLastName" placeholder="Enter Last Name" runat="server" />
            <br/>
            <asp:Label ID="lblPersonalAddress" Text="Personal Address" runat="server" />
            <br/>
            <asp:Label ID="lblPersonalStreet" Text="Street" runat="server" />
            <asp:TextBox ID="txtPersonalStreet" placeholder="Enter Street" runat="server" />
            <br/>
            <asp:Label ID="lblPersonalCity" Text="City" runat="server" />
            <asp:TextBox ID="txtPersonalCity" placeholder="Enter City" runat="server" />
            <br/>
            <asp:Label ID="lblPersonalState" Text="State" runat="server" />
            <asp:TextBox ID="txtPersonalState" placeholder="Enter State" runat="server" />
            <br/>
            <asp:Label ID="lblPersonalZipCode" Text="Zip Code" runat="server" />
            <asp:TextBox ID="txtPersonalZipCode" placeholder="Enter Zip Code" runat="server" />
            <br/>
            <asp:Label ID="lblPersonalPhoneNumber" Text="Personal Phone Number" runat="server" />
            <asp:TextBox ID="txtPersonalPhoneNumber" placeholder="Enter Phone Number" runat="server" />
            <br/>
            <asp:Label ID="lblPersonalEmail" Text="Personal Email" runat="server" />
            <asp:TextBox ID="txtPersonalEmail" placeholder="Enter Email" runat="server" />
            <br/>
            <asp:Label ID="lblWorkAddress" Text="Work Address" runat="server" />
            <br/>
            <asp:Label ID="lblWorkStreet" Text="Street" runat="server" />
            <asp:TextBox ID="txtWorkStreet" placeholder="Enter Street" runat="server" />
            <br/>
            <asp:Label ID="lblWorkCity" Text="City" runat="server" />
            <asp:TextBox ID="txtWorkCity" placeholder="Enter City" runat="server" />
            <br/>
            <asp:Label ID="lblWorkState" Text="State" runat="server" />
            <asp:TextBox ID="txtWorkState" placeholder="Enter State" runat="server" />
            <br/>
            <asp:Label ID="lblWorkZipCode" Text="Zip Code" runat="server" />
            <asp:TextBox ID="txtWorkZipCode" placeholder="Enter Zip Code" runat="server" />
            <br/>
            <asp:Label ID="lblWorkPhoneNumber" Text="Work Phone Number" runat="server" />
            <asp:TextBox ID="txtWorkPhoneNumber" placeholder="Enter Phone Number" runat="server" />
            <br/>
            <asp:Label ID="lblWorkEmail" Text="Work Email" runat="server" />
            <asp:TextBox ID="txtWorkEmail" placeholder="Enter Email" runat="server" />
            <br />
            <asp:Label ID="lblCompanyID" Text="Company ID" runat="server" />
            <asp:TextBox ID="txtCompanyID" placeholder="Enter Company ID" runat="server" />
        </div>
        <asp:button ID="btnSubmitAccountRegistration" Text="Create Account" runat="server" OnClick="btnSubmitAccountRegistration_Click" />
    </form>
</body>
</html>
