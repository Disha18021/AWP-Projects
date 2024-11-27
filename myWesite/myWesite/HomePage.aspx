<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="myWesite.HomePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home - Crochet Store</title>
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
        <a href="OrderHistory.aspx">User's order history</a>
    </div>
</div>
<div class="container">
<h1> Home Page</h1>
</div>
    <div class="container">
    <img src="/Images/bg.jpg" alt =" bg image" style="width:100%;height:500px;" />
    <div class="row">
    <div class="column">
        <img src="/Images/bg7.jpg" alt="Snow" style="width:100%">
    </div>
    <div class="column">
        <img src="/Images/bg4.jpg" alt="Forest" style="width:100%">
    </div>
    <div class="column">
        <img src="/Images/bg8.jpg" alt="flower" style="width:100%">
    </div>
    </div>
    <img src="/Images/bg2.jpg" alt =" bg2 image" style="width:100%;height:500px;" />
    </div>
    </form>
</body>
</html>
