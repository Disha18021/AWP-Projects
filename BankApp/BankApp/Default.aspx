<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BankApp.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Banking System</title>
    <!-- Include Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <style>
        body {
            background-color: #f8f9fa;
            font-family: Arial, sans-serif;
        }
        h2, h3 {
            text-align: center;
            color: Maroon;
        }
        #form1 {
            margin: 0 auto;
            max-width: 600px;
            padding: 20px;
            background: #ffffff;
            box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }
        label {
            font-weight: bold;
            color: #495057;
        }
        .btn {
            margin: 5px 0;
            background-color: Maroon;
        }
        .btn-primary {
            background-color: #007bff;
            border-color: #007bff;
        }
        .btn-danger {
            background-color: #dc3545;
            border-color: #dc3545;
        }
        .form-control {
            margin-bottom: 15px;
        }
        .alert {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Welcome to the Banking System</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

            <!-- Main Menu -->
            <asp:Panel ID="MainMenu" runat="server" Visible="true">
            <div class="d-grid gap-2">
                <asp:Button ID="btnBanker" Text="Banker" runat="server" OnClick="btnBanker_Click" />
                <asp:Button ID="btnCustomer" Text="Customer" runat="server" OnClick="btnCustomer_Click" />
                </div>
            </asp:Panel>

            <!-- Banker Menu -->
            <asp:Panel ID="BankerMenu" runat="server" Visible="false">
                <h3>Banker Menu</h3>
                <div class="d-grid gap-2">
                <asp:Button ID="btnCreateAccount" Text="Create Account" runat="server" OnClick="btnCreateAccount_Click" />
                <asp:Button ID="btnDisplayAccounts" Text="Display All Accounts" runat="server" OnClick="btnDisplayAccounts_Click" />
                <asp:Button ID="btnBankerBack" Text="Back" runat="server" OnClick="btnBankerBack_Click" />
                </div>
            </asp:Panel>

            <!-- Create Account Panel -->
            <asp:Panel ID="CreateAccountPanel" runat="server" Visible="false">
                <h3>Create Account</h3>
                <label>Account Number:</label>
                <asp:TextBox ID="txtAccountNumber" runat="server"></asp:TextBox><br />
                <label>Account Name:</label>
                <asp:TextBox ID="txtAccountName" runat="server"></asp:TextBox><br />
                <label>Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                <div class="d-grid gap-2">
                <asp:Button ID="btnSubmitAccount" Text="Submit" runat="server" OnClick="btnSubmitAccount_Click" />
                <asp:Button ID="btnCreateAccountBack" Text="Back" runat="server" OnClick="btnCreateAccountBack_Click" />
                </div>
            </asp:Panel>

            <!-- Customer Menu -->
            <asp:Panel ID="CustomerMenu" runat="server" Visible="false">
                <h3>Customer Menu</h3>
                <label>Account Number:</label>
                <asp:TextBox ID="txtCustomerAccountNumber" runat="server"></asp:TextBox><br />
                <label>Account Name:</label>
                <asp:TextBox ID="txtCustomerAccountName" runat="server"></asp:TextBox><br />
                <label>Password:</label>
                <asp:TextBox ID="txtCustomerPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                <div class="d-grid gap-2">
                <asp:Button ID="btnLoginCustomer" Text="Login" runat="server" OnClick="btnLoginCustomer_Click" />
                <asp:Button ID="btnCustomerBack" Text="Back" runat="server" OnClick="btnCustomerBack_Click" />
                </div>
            </asp:Panel>

            <!-- Logged-In Customer Menu -->
            <asp:Panel ID="LoggedInCustomerMenu" runat="server" Visible="false">
                <h3>Customer Options</h3>
                <label>Deposit Amount:</label>
                <asp:TextBox ID="txtDepositAmount" runat="server"></asp:TextBox><br />
                <asp:Button ID="btnDeposit" Text="Deposit" runat="server" OnClick="btnDeposit_Click" /><br />
                <label>Withdraw Amount:</label>
                <asp:TextBox ID="txtWithdrawAmount" runat="server"></asp:TextBox><br />
                <asp:Button ID="btnWithdraw" Text="Withdraw" runat="server" OnClick="btnWithdraw_Click" /><br />
                

                <asp:Label ID="Label1" runat="server" />

                <asp:Button ID="btnCheckBalance" Text="Check Balance" runat="server" OnClick="btnCheckBalance_Click" /><br />
                <asp:Button ID="btnLogoutCustomer" Text="Logout" runat="server" OnClick="btnLogoutCustomer_Click" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
