using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace myWesite
{
    public partial class Register : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateUserTableIfNotExists();
            CreateCartTableIfNotExists();
            CreateOrderTableIfNotExists();
        }
        private void CreateUserTableIfNotExists()
        {
            //string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=myDB;Integrated Security=True;";
            string connString = WebConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            //using (SqlConnection conn = new SqlConnection(connString))
            string createTableQuery = @"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users')
                BEGIN
                    CREATE TABLE Users
                    (
                        UserId INT IDENTITY(1,1) PRIMARY KEY,
                        Name NVARCHAR(100),
                        Email NVARCHAR(100),
                        Password NVARCHAR(255)
                    );
                END
            ";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(createTableQuery, conn);
                    cmd.ExecuteNonQuery();  // Executes the SQL statement
                }
                catch (Exception ex)
                {
                    // Handle any errors (optional)
                    Response.Write("Error: " + ex.Message);
                }
            }
        }
        private void CreateCartTableIfNotExists()
        {
            //string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=myDB;Integrated Security=True;";
            string connString = WebConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            //using (SqlConnection conn = new SqlConnection(connString))
            string createTableQuery = @"
        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Cart')
        BEGIN
            CREATE TABLE Cart
            (
                CartId INT IDENTITY(1,1) PRIMARY KEY,
                UserId INT NOT NULL,
                ProductId INT NOT NULL,
                Quantity INT NOT NULL,
                FOREIGN KEY (UserId) REFERENCES Users(UserId)
            );
        END
    ";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(createTableQuery, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle any errors (optional)
                    Response.Write("Error: " + ex.Message);
                }
            }
        }
        private void CreateOrderTableIfNotExists()
        {
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=myDB;Integrated Security=True;";
            string createTableQuery = @"
        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Orders')
        BEGIN
            CREATE TABLE Orders
            (
                OrderId INT IDENTITY(1,1) PRIMARY KEY,
                UserId INT NOT NULL,
                ProductId INT NOT NULL,
                Quantity INT NOT NULL,
                TotalAmount DECIMAL(10, 2),
                OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
                FOREIGN KEY (UserId) REFERENCES Users(UserId)
            );
        END
    ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(createTableQuery, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle any errors (optional)
                    Response.Write("Error: " + ex.Message);
                }
            }
        }


        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            string username = RegisterUsernameTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string password = RegisterPasswordTextBox.Text.Trim();

            // Validate fields
            string validationMessage = ValidateInput(username, email, password);
            if (!string.IsNullOrWhiteSpace(validationMessage))
            {
                ErrorMessageLabel.Text = validationMessage;
                return;
            }

            // Hash the password
            string hashedPassword = HashPassword(password);

            // Database connection
            //string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=myDB;Integrated Security=True;";
            //using (SqlConnection conn = new SqlConnection(connectionString))
            string connString = WebConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO Users (Name, Email, Password) VALUES (@Name, @Email, @Password)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", username);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        Response.Write("<script>alert('Registration successful!');</script>");
                        Response.Redirect("Register.aspx");
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627) // Unique constraint violation
                        {
                            ErrorMessageLabel.Text = "Username or email already exists. Please try a different one.";
                        }
                        else
                        {
                            ErrorMessageLabel.Text = "Database error occurred during registration.";
                            Console.WriteLine("SQL Error: " + ex.Message); // Log the error
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorMessageLabel.Text = "An unexpected error occurred.";
                        Console.WriteLine("Error: " + ex.Message); // Log the error
                    }
                }
            }
        }
        private string ValidateInput(string username, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return "All fields are required.";
            }

            if (username.Length > 50)
            {
                return "Username must not exceed 50 characters.";
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return "Invalid email format.";
            }

            if (email.Length > 100)
            {
                return "Email must not exceed 100 characters.";
            }

            if (password.Length < 8 || password.Length > 50 || !System.Text.RegularExpressions.Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"))
            {
                return "Password must be 8-50 characters long, include at least one letter, one number, and one special character.";
            }

            return string.Empty;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            string hashedPassword = HashPassword(password);
            //string connectionString = "Your_Connection_String_Here";
            //using (SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLExpress;Initial Catalog=myDB;Integrated Security=True;"))
            string connString = WebConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                //SqlCommand cmd = new SqlCommand("SELECT UserId FROM Users WHERE Name = @Name AND Password = HASHBYTES('SHA2_256', @Password)", conn);
                using (SqlCommand cmd = new SqlCommand("SELECT UserId FROM Users WHERE Name = @Name AND Password = @Password", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", username);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    object result = cmd.ExecuteScalar(); // Returns UserId if successful, null otherwise
                    if (result != DBNull.Value && result != null)
                    {
                        int userId = Convert.ToInt32(result);

                        // Store UserId in the session
                        Session["UserId"] = userId;

                        // Redirect to homepage or desired page
                        Response.Redirect("Products.aspx");
                    }
                    else
                    {
                        // Handle invalid login
                        ErrorMessageLabel.Text = "Invalid username or password.";
                    }
                }
            }
        }
    }
}