using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankApp
{
    public partial class Default : System.Web.UI.Page
    {
        static List<Account> accounts = new List<Account>();
        Account loggedInCustomer = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
        }

        protected void btnBanker_Click(object sender, EventArgs e)
        {
            MainMenu.Visible = false;
            BankerMenu.Visible = true;
        }

        protected void btnCustomer_Click(object sender, EventArgs e)
        {
            MainMenu.Visible = false;
            CustomerMenu.Visible = true;
        }

        protected void btnBankerBack_Click(object sender, EventArgs e)
        {
            BankerMenu.Visible = false;
            MainMenu.Visible = true;
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            CreateAccountPanel.Visible = true;
            BankerMenu.Visible = false;
        }

        protected void btnCreateAccountBack_Click(object sender, EventArgs e)
        {
            CreateAccountPanel.Visible = false;
            BankerMenu.Visible = true;
        }

        protected void btnSubmitAccount_Click(object sender, EventArgs e)
        {
            int accountNumber = int.Parse(txtAccountNumber.Text);
            string accountName = txtAccountName.Text;
            string password = txtPassword.Text;

            accounts.Add(new Account(accountNumber, accountName, password));
            lblMessage.Text = "Account created successfully.";
            CreateAccountPanel.Visible = false;
            BankerMenu.Visible = true;
        }

        protected void btnDisplayAccounts_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "All Accounts:<br />";
            foreach (var account in accounts)
            {
                lblMessage.Text += string.Format("Account Number: {0}, Name: {1}<br />",account.AccountNumber, account.AccountName);
            }
        }

        protected void btnCustomerBack_Click(object sender, EventArgs e)
        {
            CustomerMenu.Visible = false;
            MainMenu.Visible = true;
        }

        protected void btnLoginCustomer_Click(object sender, EventArgs e)
        {
            int accountNumber = int.Parse(txtCustomerAccountNumber.Text);
            string accountName = txtCustomerAccountName.Text;
            string password = txtCustomerPassword.Text;

            loggedInCustomer = accounts.Find(a => a.AccountNumber == accountNumber && a.AccountName == accountName && a.Password == password);

            if (loggedInCustomer != null)
            {
                Session["LoggedInCustomer"] = loggedInCustomer;
                lblMessage.Text = "Login successful!";
                CustomerMenu.Visible = false;
                LoggedInCustomerMenu.Visible = true;
            }
            else
            {
                lblMessage.Text = "Invalid credentials.";
            }
        }

        protected void btnDeposit_Click(object sender, EventArgs e)
        {
            //loggedInCustomer.Deposit(100); // Example deposit amount
            //lblMessage.Text = "Deposit successful.";
            loggedInCustomer = Session["LoggedInCustomer"] as Account;
            if (loggedInCustomer != null)
            {
                double depositAmount;
        
                // Parse the user input for deposit amount
                if (double.TryParse(txtDepositAmount.Text, out depositAmount) && depositAmount > 0)
                {
                    loggedInCustomer.Deposit(depositAmount);
                    lblMessage.Text = string.Format("Deposit of {0} successful. Current Balance: {1}",depositAmount,loggedInCustomer.Balance);
                }
                else
                {
                    lblMessage.Text = "Invalid deposit amount. Please enter a positive number.";
                }
            }
            else
            {
                lblMessage.Text = "No customer logged in. Please log in to deposit money.";
            }
        }

        protected void btnWithdraw_Click(object sender, EventArgs e)
        {
            loggedInCustomer = Session["LoggedInCustomer"] as Account;
            if (loggedInCustomer != null)
            {
                double withdrawAmount;

                // Parse the user input for withdrawal amount
                if (double.TryParse(txtWithdrawAmount.Text, out withdrawAmount) && withdrawAmount > 0)
                {
                    if (loggedInCustomer.Withdraw(withdrawAmount))
                    {
                        lblMessage.Text = string.Format("Withdrawal of {0} successful. Current Balance: {1}", withdrawAmount, loggedInCustomer.Balance);
                    }
                    else
                    {
                        lblMessage.Text = "Insufficient balance.";
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid withdrawal amount. Please enter a positive number.";
                }
            }
            else
            {
                lblMessage.Text = "No customer logged in. Please log in to withdraw money.";
            }
        }

        protected void btnCheckBalance_Click(object sender, EventArgs e)
        {
            loggedInCustomer = Session["LoggedInCustomer"] as Account;
            if (loggedInCustomer != null)
            {
                lblMessage.Text = string.Format("Current Balance: {0}", loggedInCustomer.Balance);

            }
            else
            {
                lblMessage.Text = "No customer logged in. Please log in to check balance.";
            }
        }

        protected void btnLogoutCustomer_Click(object sender, EventArgs e)
        {
            LoggedInCustomerMenu.Visible = false;
            MainMenu.Visible = true;
            loggedInCustomer = null;
        }
    }

    public class Account
    {
        public int AccountNumber { get; private set; }
        public string AccountName { get; private set; }
        public string Password { get; private set; }
        public double Balance { get; private set; }

        public Account(int accountNumber, string accountName, string password)
        {
            AccountNumber = accountNumber;
            AccountName = accountName;
            Password = password;
            Balance = 0;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public bool Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }
}
