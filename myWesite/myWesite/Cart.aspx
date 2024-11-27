<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="myWesite.Cart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Cart</title>
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
    <div>
       <h1>Your Cart</h1>
        <asp:TextBox ID="ProductIDTextBox" runat="server" Placeholder=" Product ID"></asp:TextBox>
        <asp:TextBox ID="QuantityTextBox" runat="server" Placeholder=" Quantity of product"></asp:TextBox>
        <asp:TextBox ID="UserIdTextBox" runat="server" Placeholder="User ID"></asp:TextBox>
        <asp:Button ID="ViewCartButton" runat="server" Text="View Cart" OnClick="ViewCartButton_Click" />
        <asp:Label ID="ErrorMessageLabel" runat="server"></asp:Label>
    <div class="container">
        
        <asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
        <div class="cart-item">
            <h2><%# Eval("ProductName") %></h2>
            <p>Price: Rs. <%# Eval("Price") %></p>
            <p>Quantity: <%# Eval("Quantity") %></p>
        </div>
    </ItemTemplate>
</asp:Repeater>

    </div>

    <div class="footer">
        &copy; 2024 MyWebsite. All Rights Reserved.
    </div>
   <asp:Button ID="PlaceOrderButton" runat="server" Text="Place Order" OnClick="PlaceOrderButton_Click" />

    </div>
    </form>
</body>
</html>
