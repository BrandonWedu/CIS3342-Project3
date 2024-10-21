<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project3.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <ul>
                <li>
                    <asp:Button ID="AccountLoginPage" Text="Login" OnClick="btnAccountLogin_Click" runat="server" />
                    <asp:Button ID="AccountRegistrationPage" Text="AccountRegistration" OnClick="btnAccountRegistration_Click" runat="server" />
                </li>
            </ul>
        </header>
        <div>
        </div>
    </form>
</body>
</html>
