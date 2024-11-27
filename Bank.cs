using System;
using System.Collections.Generic;

class Bank
{
    static List<Account> accounts = new List<Account>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Welcome to the Banking System");
            Console.WriteLine("1. Banker");
            Console.WriteLine("2. Customer");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            int option;
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid option. Please enter a valid number.");
                continue;
            }

            switch (option)
            {
                case 1:
                    BankerMenu();
                    break;
                case 2:
                    CustomerMenu();
                    break;
                case 3:
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }
        }
    }

    static void BankerMenu()
    {
        Console.WriteLine("\nBanker Menu");
        Console.WriteLine("1. Create Account");
        Console.WriteLine("2. Display All Accounts");
        Console.WriteLine("3. Back to Main Menu");
        Console.Write("Choose an option: ");

        int option;
        if (!int.TryParse(Console.ReadLine(), out option))
        {
            Console.WriteLine("Invalid option. Please enter a valid number.");
            return;
        }

        switch (option)
        {
            case 1:
                CreateAccount();
                break;
            case 2:
                DisplayAllAccounts();
                break;
            case 3:
                Console.WriteLine("Returning to main menu...");
                break;
            default:
                Console.WriteLine("Invalid option. Please choose a valid option.");
                break;
        }
    }

    static void CreateAccount()
    {
        Console.WriteLine("\nCreating Account");
        Console.Write("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter account holder name: ");
        string accountName = Console.ReadLine();
        Console.Write("Enter account password: ");
        string password = Console.ReadLine();

        Account newAccount = new Account(accountNumber, accountName, password);
        accounts.Add(newAccount);

        Console.WriteLine("Account created successfully.");
    }

    static void DisplayAllAccounts()
    {
        Console.WriteLine("\nDisplaying All Accounts");
        foreach (var account in accounts)
        {
            Console.WriteLine("Account Number: {0} Name: {1}",account.AccountNumber,account.AccountName);
	 
        }
    }

    static void CustomerMenu()
    {
        Console.WriteLine("\nCustomer Menu");
        Console.Write("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter account name: ");
        string accountName = Console.ReadLine();
        Console.Write("Enter account password: ");
        string password = Console.ReadLine();

        Account customerAccount = accounts.Find(account => account.AccountNumber == accountNumber && 
                                                           account.AccountName == accountName &&
                                                           account.Password == password);

        if (customerAccount == null)
        {
            Console.WriteLine("Account not found or credentials invalid.");
            return;
        }

        while (true)
        {
            Console.WriteLine("\n1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Choose an option: ");

            int option;
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid option. Please enter a valid number.");
                continue;
            }

            switch (option)
            {
                case 1:
                    Console.Write("Enter amount to deposit: ");
                    double depositAmount = double.Parse(Console.ReadLine());
                    customerAccount.Deposit(depositAmount);
                    break;
                case 2:
                    Console.Write("Enter amount to withdraw: ");
                    double withdrawAmount = double.Parse(Console.ReadLine());
                    if (customerAccount.Withdraw(withdrawAmount))
                    {
                        Console.WriteLine("Withdrawal successful.");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Current Balance: {0}",customerAccount.Balance);
                    break;
                case 4:
                    Console.WriteLine("Returning to main menu...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }
        }
    }
}

class Account
{
    private readonly int accountNumber;
    private readonly string accountName;
    private readonly string password;
    private double balance;

    public int AccountNumber
    {
        get { return accountNumber; }
    }

    public string AccountName
    {
        get { return accountName; }
    }

    public string Password
    {
        get { return password; }
    }

    public double Balance
    {
        get { return balance; }
    }

    public Account(int accountNumber, string accountName, string password)
    {
        this.accountNumber = accountNumber;
        this.accountName = accountName;
        this.password = password;
        this.balance = 0;
    }

    public void Deposit(double amount)
    {
        balance += amount;
    }

    public bool Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            return true;
        }
        return false;
    }
}
