using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.ModelTypeManagement.Controller;
using ProjectFinalLEC.CartManagement.Controller;

namespace ProjectFinalLEC.Views
{
    public partial class DetailModelType : System.Web.UI.Page
    {
        ModelTypeController MC = new ModelTypeController();
        CartController CC = new CartController();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ModelTypeID"]);
            ModelType modeltypeid = MC.getModelTypeID(id);
            ModelTypeLBL.Text = modeltypeid.ModelTypeName;
            ModelTypeImage.ImageUrl = "../Assets/ModelTypes/" + modeltypeid.ModelTypeImage;

            ModelTypeStockLBL.Text = "ModelType Stock: " + modeltypeid.ModelTypeStock.ToString();
            ModelTypeDescLBL.Text = "ModelType Description: " + modeltypeid.ModelTypeDescription;
            Price priceId = MC.getPricebyId(modeltypeid.ModelTypePrice);
            ModelTypePriceLBL.Text = "ModelType Price: " + priceId.Currency + priceId.Nominal;

            if (Session["User"] == null && Session["Admin"] == null)
            {
                Button btnCart = Master.FindControl("CartBTN") as Button;
                Button btnTrsct = Master.FindControl("TransactionBTN") as Button;
                Button btnUpdt = Master.FindControl("UpdateProfileBTN") as Button;
                Button btnLogout = Master.FindControl("LogoutBTN") as Button;
                btnCart.Visible = false;
                btnTrsct.Visible = false;
                btnUpdt.Visible = false;
                btnLogout.Visible = false;

            }
            if (Session["User"] != null)
            {
                int userid = -1;
                userid = (int)Session["User"];
                UpdateModelTypeBTN.Visible = false;
                DeleteModelTypeBTN.Visible = false;
            }
            else if (Session["Admin"] != null)
            {
                int userid = -1;
                userid = (int)Session["Admin"];
                UpdateModelTypeBTN.Visible = true;
                DeleteModelTypeBTN.Visible = true;
                AddCartBTN.Visible = false;
                QuantityTXT.Visible = false;
                QuantityLBL.Visible = false;
            }
        }

        protected void AddCartBTN_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(QuantityTXT.Text.ToString());
            int id = Convert.ToInt32(Request.QueryString["ModelTypeID"]);
            int userid = -1;
            if (Session["User"] != null)
            {

                userid = (int)Session["User"];
            }
            else if (Session["Admin"] != null)
            {

                userid = (int)Session["Admin"];
            }

            DateTime currentDateAndTime = DateTime.Now;
            string dateString = currentDateAndTime.ToString("yyyy-MM-dd");
            string timeString = currentDateAndTime.ToString("HH:mm:ss");

            CC.createOrderDate();

            bool tempBool = CC.CartControllerAdd(userid, id, quantity);
            if (tempBool)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
            else
            {
                Errlbl.Visible = true;
                Errlbl.Text = "Quantity is more than Available Stock!";
            }
        }

        protected void UpdateModelTypeBTN_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ModelTypeID"]);
            Response.Redirect("~/Views/UpdateModelType.aspx?ModelTypeID=" + id);
        }

        protected void DeleteModelTypeBTN_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ModelTypeID"]);
            MC.deleteModelTypeController(id);
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}