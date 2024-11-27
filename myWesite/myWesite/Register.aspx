<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="myWesite.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div class="navbar">
    <div class="brand">Crochet Website</div>
    <div>
        <a href="HomePage.aspx">Home</a>
        <a href="AboutUs.aspx" >About Us</a>
        <a href="Register.aspx">Register</a>
        <a href="Cart.aspx">Cart</a>
        <a href="Products.aspx">Products</a>
    </div>
</div>
<div class="container">
    <h1>Login</h1>
    <asp:TextBox ID="UsernameTextBox" runat="server" Placeholder="addName" ></asp:TextBox>
    <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" Placeholder="addPassword" ></asp:TextBox>
    <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
    </div>

    <div class="container">
    <h1>Register</h1>
    <asp:TextBox ID="RegisterUsernameTextBox" runat="server" Placeholder="addName" ></asp:TextBox><br />
    <asp:TextBox ID="EmailTextBox" runat="server" Placeholder="addEmail"></asp:TextBox><br />
    <asp:TextBox ID="RegisterPasswordTextBox" runat="server" TextMode="Password" Placeholder="addPasswrod" ></asp:TextBox><br />
    <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" />

    </div>
       <asp:Label ID="ErrorMessageLabel" runat="server" align="center"></asp:Label>
    </form>
</body>
</html>
