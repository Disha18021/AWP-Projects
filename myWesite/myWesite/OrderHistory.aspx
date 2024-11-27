<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="myWesite.OrderHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Order History</title>
    <link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div class="navbar">
        <div class="brand">Crochet Website</div>
        <div>
            <a href="HomePage.aspx">Home</a>
            <a href="AboutUs.aspx">About Us</a>
            <a href="Products.aspx">Products</a>
            <a href="Cart.aspx">Cart</a>
            <a href="OrderHistory.aspx">Order History</a>
        </div>
    </div>
    <div>
        <h1>Your Order History</h1>
        
        <asp:Repeater ID="OrderHistoryRepeater" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>Product Name</th>
                        <th>Quantity</th>
                        <th>Price</th>
                        <th>Order Date</th>
                        <th>Total Amount</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ProductName") %></td>
                    <td><%# Eval("Quantity") %></td>
                    <td>Rs. <%# Eval("Price") %></td>
                    <td><%# Eval("OrderDate", "{0:yyyy-MM-dd}") %></td>
                    <td>Rs. <%# Eval("TotalAmount") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        
    </div>

    <div class="footer">
        &copy; 2024 MyWebsite. All Rights Reserved.
    </div>

    </form>
</body>
</html>
