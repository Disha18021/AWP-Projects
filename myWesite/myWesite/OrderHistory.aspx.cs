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
    public partial class OrderHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("Register.aspx"); // Redirect to login page
                }
                else
                {
                    int userId = int.Parse(Session["UserId"].ToString());
                    LoadOrderHistory(userId);
                }
            }
        }
        private void LoadOrderHistory(int userId)
        {
           // string connString = WebConfigurationManager.ConnectionStrings["Data Source=localhost\\SQLExpress;Initial Catalog=myDB;Integrated Security=True;"].ConnectionString; // Use your actual connection string

            using (SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLExpress;Initial Catalog=myDB;Integrated Security=True;"))
            {
                string query = "SELECT p.ProductName, o.Quantity, p.Price, o.OrderDate, o.TotalAmount " +
                               "FROM Orders o " +
                               "JOIN Products p ON o.ProductId = p.ProductId " +
                               "WHERE o.UserId = @UserId " +
                               "ORDER BY o.OrderDate DESC"; // Order by most recent

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    OrderHistoryRepeater.DataSource = dt;
                    OrderHistoryRepeater.DataBind();
                }
                else
                {
                    // If no orders found, display a message
                    OrderHistoryRepeater.Visible = false;
                    //LabelNoOrders.Visible = true;
                }
            }
        }
    }
}