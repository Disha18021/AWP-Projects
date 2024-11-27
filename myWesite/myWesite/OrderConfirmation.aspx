<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderConfirmation.aspx.cs" Inherits="myWesite.OrderConfirmation" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="styles.css">
    <title>Order Confirmation</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        .container {
            width: 60%;
            margin: 20px auto;
            border: 1px solid #ccc;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0px 2px 5px rgba(0, 0, 0, 0.2);
        }
        h1, h2 {
            text-align: center;
        }
        .form-group {
            margin-bottom: 15px;
        }
        label {
            display: block;
            margin-bottom: 5px;
        }
        input[type="text"], input[type="number"] {
            width: 100%;
            padding: 8px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .btn {
            padding: 10px 15px;
            background-color: #007BFF;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        .btn:hover {
            background-color: #0056b3;
        }
        .error-message {
            color: red;
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navbar -->
        <div class="navbar">
            <div class="brand">Crochet Website</div>
            <div>
                <a href="HomePage.aspx">Home</a>
                <a href="AboutUs.aspx">About Us</a>
                <a href="Register.aspx">Register</a>
                <a href="Cart.aspx">Cart</a>
                <a href="Products.aspx">Products</a>
            </div>
        </div>

        <!-- Payment Section -->
        <div class="container" id="PaymentSection" runat="server" visible="true">
            <h1>Payment Details</h1>
            </div>
            <div class="container">
            
            <div class="form-group">
                <label for="CardHolderName">Cardholder Name</label>
                <asp:TextBox ID="CardHolderName" runat="server" CssClass="form-control" Placeholder="Enter name on card"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="CardNumber">Card Number</label>
                <asp:TextBox ID="CardNumber" runat="server" CssClass="form-control" Placeholder="Enter 16-digit card number"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="ExpiryDate">Expiry Date</label>
                <asp:TextBox ID="ExpiryDate" runat="server" CssClass="form-control" Placeholder="MM/YY"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="CVV">CVV</label>
                <asp:TextBox ID="CVV" runat="server" CssClass="form-control" Placeholder="Enter 3-digit CVV"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="PaymentAmountLabel" runat="server" Text="Amount to Pay: Rs. 0"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Button ID="PayNowButton" runat="server" CssClass="btn" Text="Pay Now" OnClick="PayNowButton_Click" />
            </div>
            <div class="error-message">
                <asp:Label ID="ErrorMessage" runat="server" Text="" />
            </div>
        </div>

        <!-- Order Confirmation Section -->
        <div class="container" id="ConfirmationSection" runat="server" visible="false">
            <h1>Order Confirmation</h1>

            <div class="order-details">
                <h2>Thank you for your order!</h2>
                <p><strong>Order ID:</strong> <asp:Label ID="OrderIdLabel" runat="server" /></p>
                <p><strong>Total Amount:</strong> <asp:Label ID="TotalAmountLabel" runat="server" /></p>
                <p>Your order has been placed successfully. You will receive a confirmation email shortly.</p>
            </div>
        </div>
    </form>
</body>
</html>

