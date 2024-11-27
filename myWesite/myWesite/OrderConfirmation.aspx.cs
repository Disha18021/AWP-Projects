/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myWesite
{
    public partial class OrderConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["TotalAmount"] != null)
            {
                TotalAmountLabel.Text = "Total Amount: Rs. " + Session["TotalAmount"].ToString();
            }
            else
            {
                TotalAmountLabel.Text = "Order details are not available.";
            }
        }
    }
}*/
using System;
using System.Web.UI;

namespace myWesite
{
    public partial class OrderConfirmation : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TotalAmount"] != null)
                {
                    PaymentAmountLabel.Text = "Amount to Pay: Rs. " + Session["TotalAmount"].ToString();
                }
                else
                {
                    PaymentAmountLabel.Text = "Order details are not available.";
                }
            }
        }

        protected void PayNowButton_Click(object sender, EventArgs e)
        {
            // Validate form inputs
            if (string.IsNullOrEmpty(CardHolderName.Text))
            {
                ErrorMessage.Text = "Please enter the cardholder's name.";
                return;
            }

            if (string.IsNullOrEmpty(CardNumber.Text) || CardNumber.Text.Length != 16)
            {
                ErrorMessage.Text = "Please enter a valid 16-digit card number.";
                return;
            }

            if (string.IsNullOrEmpty(ExpiryDate.Text) || !ExpiryDate.Text.Contains("/"))
            {
                ErrorMessage.Text = "Please enter the expiry date in MM/YY format.";
                return;
            }

            if (string.IsNullOrEmpty(CVV.Text) || CVV.Text.Length != 3)
            {
                ErrorMessage.Text = "Please enter a valid 3-digit CVV.";
                return;
            }

            // Simulate successful payment
            Session["PaymentStatus"] = "Success";

            // Hide payment form and show confirmation
            PaymentSection.Visible = false;
            ConfirmationSection.Visible = true;

            // Display order details
            if (Session["TotalAmount"] != null)
            {
                TotalAmountLabel.Text = "Total Amount: Rs. " + Session["TotalAmount"].ToString();
                OrderIdLabel.Text = "ORD" + new Random().Next(10000, 99999); // Generate dummy order ID
            }
        }
    }
}
