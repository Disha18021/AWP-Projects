<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="myWesite.ProductDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Details</title>
    <link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div class="body">
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
    <h1>Product Details</h1>
</div>
    <div class="container">

    <asp:Panel ID="ProductDetailsPanel" runat="server">
    <img id="ProductImage" runat="server" style="width:300px;height:300px;" />
    <h2 id="ProductName" runat="server"></h2>
    <p id="ProductPrice" runat="server"></p>
    <p id="ProductDescription" runat="server"></p>
    <asp:Button ID="AddToCartButton" runat="server" Text="Add to Cart" OnClick="AddToCartButton_Click" />
    </asp:Panel>
    </div>
    </div>
    </form>
</body>
</html>
