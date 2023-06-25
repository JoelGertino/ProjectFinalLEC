using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.ModelTypeManagement.Controller;

namespace ProjectFinalLEC.Views
{
    public partial class UpdateModelType : System.Web.UI.Page
    {
        ModelTypeController MC = new ModelTypeController();
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
        }

        protected void UpdateBTN_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                int id = Convert.ToInt32(Request.QueryString["ModelTypeID"]);
                string name, description, image;
                int price, stock;
                HttpPostedFile file = FileUpload1.PostedFile;
                double fileSize = file.ContentLength / 1048576;
                name = ModelTypeNameTxt.Text.ToString();
                description = ModelTypeDescTxt.Text.ToString();
                image = FileUpload1.FileName;
                price = Convert.ToInt32(ModelTypePriceTxt.Text.ToString());
                stock = Convert.ToInt32(ModelTypeStockTxt.Text.ToString());
                bool TempBool = MC.UpdateModelTypeController(id, name, description, price, stock, image, fileSize);

                if (TempBool)
                {
                    FileUpload1.SaveAs(Server.MapPath("~") + "/Assets/ModelTypes/" + FileUpload1.FileName);
                    Response.Redirect("~/Views/HomePage.aspx");
                }
                else
                {
                    Errlbl.Text = "Invalid Data";
                }
            }
        }

        protected void CancelBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}