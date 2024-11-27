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
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LoadCartItems();
                Repeater1.DataSource = null;
                Repeater1.DataBind();
                if (Session["UserId"] == null)
                {
                    Response.Redirect("Register.aspx"); // Redirect to login page
                }
            }
        }
        protected void ViewCartButton_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                ErrorMessageLabel.Text = "User not logged in.";
                return;
            }
            System.Diagnostics.Debug.WriteLine("Session UserId: " + Session["UserId"]);
            int userId = int.Parse(Session["UserId"].ToString());
            LoadCartItems(userId);
        }

        private void LoadCartItems(int userId)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLExpress;Initial Catalog=myDB;Integrated Security=True;"))
            {
                string query = "SELECT p.ProductName, p.Price, c.Quantity FROM Cart c JOIN Products p ON c.ProductId = p.ProductId WHERE c.UserId = @UserId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);

                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable cartTable = new DataTable();
                    adapter.Fill(cartTable);

                    if (cartTable.Rows.Count > 0)
                    {
                        Repeater1.DataSource = cartTable;
                        Repeater1.DataBind();
                    }
                    else
                    {
                        ErrorMessageLabel.Text = "Your cart is empty.";
                        Repeater1.DataSource = null;
                        Repeater1.DataBind();
                    }
                }
            }
        }
        protected void PlaceOrderButton_Click(object sender, EventArgs e)
        {
            int productId;
            int quantity;
            try
            {
                if (Session["UserId"] == null)
                {
                    ErrorMessageLabel.Text = "Session expired. Redirecting to login.";
                    Response.Redirect("Register.aspx");
                    return;
                }

                System.Diagnostics.Debug.WriteLine("Session UserId: " + Session["UserId"]);
                int userId = int.Parse(Session["UserId"].ToString());

                if (string.IsNullOrEmpty(ProductIDTextBox.Text.Trim()) || string.IsNullOrEmpty(QuantityTextBox.Text.Trim()))
                {
                    ErrorMessageLabel.Text = "Product ID and Quantity must be provided.";
                    System.Diagnostics.Debug.WriteLine("Input validation failed: ProductID or Quantity missing.");
                    return;
                }

                if (!int.TryParse(ProductIDTextBox.Text.Trim(), out productId) || !int.TryParse(QuantityTextBox.Text.Trim(), out quantity) || quantity <= 0)
                {
                    ErrorMessageLabel.Text = "Invalid Product ID or Quantity.";
                    System.Diagnostics.Debug.WriteLine("Invalid input: ProductID or Quantity.");
                    return;
                }

                System.Diagnostics.Debug.WriteLine("Order Details: UserId={0}, ProductId={1}, Quantity={2}",userId, productId, quantity);

                decimal totalAmount = 0;

                // Database operations
                string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=myDB;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Fetch product price
                    string priceQuery = "SELECT Price FROM Products WHERE ProductId = @ProductId";
                    using (SqlCommand priceCmd = new SqlCommand(priceQuery, conn))
                    {
                        priceCmd.Parameters.AddWithValue("@ProductId", productId);
                        object priceObj = priceCmd.ExecuteScalar();
                        if (priceObj == null)
                        {
                            ErrorMessageLabel.Text = "Invalid Product ID.";
                            System.Diagnostics.Debug.WriteLine("Product not found.");
                            return;
                        }

                        decimal productPrice = (decimal)priceObj;
                        totalAmount = productPrice * quantity;
                        System.Diagnostics.Debug.WriteLine("Product Price: {0}, Total Amount: {1}", productPrice, totalAmount);
                    }

                    // Insert order
                    string query = "INSERT INTO Orders (UserID, ProductID, Quantity, OrderDate, TotalAmount) VALUES (@UserID, @ProductID, @Quantity, @OrderDate, @TotalAmount)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                        cmd.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine("Order inserted successfully.");
                    }

                    // Clear cart
                    string clearCartQuery = "DELETE FROM Cart WHERE UserID = @UserID";
                    using (SqlCommand clearCartCmd = new SqlCommand(clearCartQuery, conn))
                    {
                        clearCartCmd.Parameters.AddWithValue("@UserID", userId);
                        clearCartCmd.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine("Cart cleared successfully.");
                    }
                }
            

                // Set session and redirect
                Session["TotalAmount"] = totalAmount;
                System.Diagnostics.Debug.WriteLine("Redirecting to OrderConfirmation.aspx. Total Amount: {0}", totalAmount);
                Response.Redirect("OrderConfirmation.aspx");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in PlaceOrderButton_Click: " + ex.Message);
                ErrorMessageLabel.Text = "An error occurred: " + ex.Message;
            }
        }
    }
}
