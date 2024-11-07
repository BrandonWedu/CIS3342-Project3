<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback = "True" CodeBehind="AccountRegistration.aspx.cs" Inherits="Project3.AccountRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sillow - Agent Account Creation</title>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;300;400;500;600;700;800;900&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="styles/style.css" />
    <link rel="stylesheet" href="styles/item-container.css" />
    <link rel="stylesheet" href="styles/main-item-container.css" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <asp:Literal ID="litTitle" Text="<h1>Sillow: Agent Account Creation</h1>" runat="server"></asp:Literal>
            <div>
                <asp:Button ID="btnDashboard" Text="Dashboard" runat="server" OnClick="btnDashboard_Click" />
                <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click"/>
            </div>
        </header>
        <div class="main-item-container">
            <div class="item-container">
                <asp:Literal ID="litLoginInformation" Text="<h2>Login Information</h2>" runat="server" />
                <asp:Label ID="lblUsername" Text="Username" runat="server" />
                <asp:TextBox ID="txtUsername" placeholder="Enter Username" runat="server" />
                <asp:Label ID="lblPassword" Text="Password" runat="server" />
                <asp:TextBox ID="txtPassword" placeholder="Enter Password" TextMode="Password" runat="server" />
                <asp:Label ID="lblFirstName" Text="First Name" runat="server" />
                <asp:TextBox ID="txtFirstName" placeholder="Enter First Name" runat="server" />
                <asp:Label ID="lblLastName" Text="Last Name" runat="server" />
                <asp:TextBox ID="txtLastName" placeholder="Enter Last Name" runat="server" />
            </div>
            <div class="item-container">
                <asp:Literal ID="litPersonalAddress" Text="<h2>Personal Address</h2>" runat="server" />
                <asp:Label ID="lblPersonalStreet" Text="Street" runat="server" />
                <asp:TextBox ID="txtPersonalStreet" placeholder="Enter Street" runat="server" />
                <asp:Label ID="lblPersonalCity" Text="City" runat="server" />
                <asp:TextBox ID="txtPersonalCity" placeholder="Enter City" runat="server" />
                <asp:Label ID="lblPersonalState" Text="State" runat="server" />
                <asp:TextBox ID="txtPersonalState" placeholder="Enter State" runat="server" />
                <asp:Label ID="lblPersonalZipCode" Text="Zip Code" runat="server" />
                <asp:TextBox ID="txtPersonalZipCode" placeholder="Enter Zip Code" runat="server" />
            </div>
            <div class="item-container">
                <asp:Literal ID="litPesonalContactInformation" Text="<h2>Personal Contact Information</h2>" runat="server" />
                <asp:Label ID="lblPersonalPhoneNumber" Text="Personal Phone Number" runat="server" />
                <asp:TextBox ID="txtPersonalPhoneNumber" placeholder="Enter Phone Number" runat="server" />
                <asp:Label ID="lblPersonalEmail" Text="Personal Email" runat="server" />
                <asp:TextBox ID="txtPersonalEmail" placeholder="Enter Email" runat="server" />
            </div>
            <br/>
            <div class="item-container">
                <asp:Literal ID="litWorkAddress" Text="<h2>Work Address</h2>" runat="server" />
                <asp:Label ID="lblWorkStreet" Text="Street" runat="server" />
                <asp:TextBox ID="txtWorkStreet" placeholder="Enter Street" runat="server" />
                <asp:Label ID="lblWorkCity" Text="City" runat="server" />
                <asp:TextBox ID="txtWorkCity" placeholder="Enter City" runat="server" />
                <asp:Label ID="lblWorkState" Text="State" runat="server" />
                <asp:TextBox ID="txtWorkState" placeholder="Enter State" runat="server" />
                <asp:Label ID="lblWorkZipCode" Text="Zip Code" runat="server" />
                <asp:TextBox ID="txtWorkZipCode" placeholder="Enter Zip Code" runat="server" />
            </div>
            <div class="item-container">
                <asp:Literal ID="litWorkContactInformation" Text="<h2>Work Contact Information</h2>" runat="server" />
                <asp:Label ID="lblWorkPhoneNumber" Text="Work Phone Number" runat="server" />
                <asp:TextBox ID="txtWorkPhoneNumber" placeholder="Enter Phone Number" runat="server" />
                <asp:Label ID="lblWorkEmail" Text="Work Email" runat="server" />
                <asp:TextBox ID="txtWorkEmail" placeholder="Enter Email" runat="server" />
            </div>
            <asp:Panel ID="pnlCompany" Visible="true" runat="server">
                <div class="item-container">
                    <asp:Literal ID="litCompanySelection" Text="<h2>Company Information</h2>" runat="server" />
                    <asp:DropDownList ID="ddlCompany" runat="server"></asp:DropDownList>
                    <asp:Button ID="btnAddNewCompany" runat="server" Text="Add New Company" OnClick="btnAddNewCompany_Click"/>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlAddCompany" Visible="false" runat="server">
                <div class="item-container">
                    <asp:Literal ID="litCompanyInformation" Text="<h2>Company Information</h2>" runat="server" />
                    <asp:Label ID="lblCompanyName" Text="Company Name" runat="server" />
                    <asp:TextBox ID="txtCompanyName" placeholder="Enter Company Name" runat="server" />
                    <asp:Button ID="btnExistingCompany" runat="server" Text="Existing Company" OnClick="btnExistingCompany_Click" />
                </div>
                <div class="item-container">
                    <asp:Literal ID="litCompanyAddress" Text="<h2>Company Address</h2>" runat="server" />
                    <asp:Label ID="lblCompanyStreet" Text="Street" runat="server" />
                    <asp:TextBox ID="txtCompanyStreet" placeholder="Enter Street" runat="server" />
                    <asp:Label ID="lblCompanyCity" Text="City" runat="server" />
                    <asp:TextBox ID="txtCompanyCity" placeholder="Enter City" runat="server" />
                    <asp:Label ID="lblCompanyState" Text="State" runat="server" />
                    <asp:TextBox ID="txtCompanyState" placeholder="Enter State" runat="server" />
                    <asp:Label ID="lblCompanyZipCode" Text="Zip Code" runat="server" />
                    <asp:TextBox ID="txtCompanyZipCode" placeholder="Enter Zip Code" runat="server" />
                </div>
                <div class="item-container">
                    <asp:Literal ID="litCompanyContactInformation" Text="<h2>Company Contact Information</h2>" runat="server" />
                    <asp:Label ID="lblCompanyPhoneNumber" Text="Company Phone Number" runat="server" />
                    <asp:TextBox ID="txtCompanyPhoneNumber" placeholder="Enter Phone Number" runat="server" />
                    <asp:Label ID="lblCompanyEmail" Text="Company Email" runat="server" />
                    <asp:TextBox ID="txtCompanyEmail" placeholder="Enter Email" runat="server" />
                </div>
            </asp:Panel>
            <div class="item-container">
                <asp:button ID="btnSubmitAccountRegistration" Text="Create Account" runat="server" OnClick="btnSubmitAccountRegistration_Click" />
                <asp:Label ID="lblError" CssClass="error" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
