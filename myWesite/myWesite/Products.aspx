<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="myWesite.Products" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Products</title>
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
        <h1>Products</h1>
</div>
    <div class="container">

    <asp:Repeater ID="ProductsRepeater" runat="server">
        <ItemTemplate>
            <div>
                <img src='<%# Eval("ImageUrl") %>' alt='<%# Eval("ProductName") %>' style="width:200px;height:200px;" />
                <h2><%# Eval("ProductName") %></h2>
                <p>Price: Rs.<%# Eval("Price") %></p>
                <a href='ProductDetails.aspx?ProductId=<%# Eval("ProductId") %>'>View Details</a>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    </div>
    </div>
    </form>
</body>
</html>
