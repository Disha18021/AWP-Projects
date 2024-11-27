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
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }
        private void LoadProducts()
        {
            //string connString = WebConfigurationManager.ConnectionStrings["Data Source=localhost\\SQLExpress;Initial Catalog=myDB;Integrated Security=True;"].ConnectionString;
            using (SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLExpress;Initial Catalog=myDB;Integrated Security=True;"))
            {
                string query = "SELECT * FROM Products";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ProductsRepeater.DataSource = reader;
                ProductsRepeater.DataBind();
            }
        }
    }
}