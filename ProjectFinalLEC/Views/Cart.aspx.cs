using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.Transaction.Controller;
using ProjectFinalLEC.CartManagement.Controller;

namespace ProjectFinalLEC.Views
{
    public partial class Cart : System.Web.UI.Page
    {
        CartController CC = new CartController();
        TransactionController TC = new TransactionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            int userid = -1;
            if (Session["User"] != null)
            {
                userid = (int)Session["User"];
            }
            CardRepeater.DataSource = CC.GetModelTypeDetailsByCustomerId(userid);
            CardRepeater.DataBind();
        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            int userid = (int)Session["User"];

            List<Model.Cart> transactions = CC.Carts(userid);
            int headerID = TransactionController.InsertTransaction(userid);


            foreach (Model.Cart cart in transactions)
            {
                TC.CreateTransactionDetail(headerID, cart.ModelTypeID, cart.Qty);
                CC.updateStock(cart.ModelTypeID, cart.Qty);
            }

            CC.DeleteCart(userid);
            Response.Redirect("~/Views/TransactionHistory.aspx");
        }
    }
}