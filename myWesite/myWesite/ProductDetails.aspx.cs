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
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int productId = Convert.ToInt32(Request.QueryString["ProductId"]);
                LoadProductDetails(productId);
            }
        }
        private void LoadProductDetails(int productId)
        {
            //string connString = WebConfigurationManager.ConnectionStrings["Data Source=localhost\\SQLExpress;Initial Catalog=myDB;Integrated Security=True;"].ConnectionString;
            using (SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLExpress;Initial Catalog=myDB;Integrated Security=True;"))
            {
                string query = "SELECT * FROM Products WHERE ProductId = @ProductId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ProductImage.Src = reader["ImageUrl"].ToString();
                    ProductName.InnerText = reader["ProductName"].ToString();
                    ProductPrice.InnerText = "Price: Rs." + reader["Price"].ToString();
                    ProductDescription.InnerText = reader["Description"].ToString();
                }
            }
        }

        protected void AddToCartButton_Click(object sender, EventArgs e)
        {
            int quantity = 1; // Default quantity set to 1.
      
            int productId = int.Parse(Request.QueryString["ProductId"]);
            int userId = int.Parse(Session["UserId"].ToString());

            //string connString = WebConfigurationManager.ConnectionStrings["CrochetDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLExpress;Initial Catalog=myDB;Integrated Security=True;"))
            {
                string query = "INSERT INTO Cart (UserId, ProductId, Quantity) VALUES (@UserId, @ProductId, @Quantity)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                cmd.Parameters.AddWithValue("@Quantity", quantity);

                conn.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Product added to cart.');</script>");
            }
        }
    }
}