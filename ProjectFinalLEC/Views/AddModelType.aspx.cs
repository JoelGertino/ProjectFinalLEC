using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.ModelTypeManagement.Controller;
using ProjectFinalLEC.BrandManagement.Controller;

namespace ProjectFinalLEC.Views
{
    public partial class AddModelType : System.Web.UI.Page
    {
        ModelTypeController MC = new ModelTypeController();
        BrandController BC = new BrandController();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            Brand brandId = BC.getID(id);

            //ItemLbl.Text = id.ToString();
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

        protected void SubmitBTN_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string ModelTypename, ModelTypedesc, ModelTypeimage;
                int ModelTypeprice, ModelTypestock;
                ModelTypename = ModelTypeNameTXT.Text.ToString();
                ModelTypedesc = ModelTypeDescTXT.Text.ToString();
                ModelTypeprice = Convert.ToInt32(ModelTypePriceTXT.Text.ToString());
                ModelTypestock = Convert.ToInt32(ModelTypeStockTXT.Text.ToString());
                ModelTypeimage = FileUpload1.FileName;
                HttpPostedFile file = FileUpload1.PostedFile;
                double fileSize = file.ContentLength / 1048576;

                int id = Convert.ToInt32(Request.QueryString["id"]);
                Brand brandId = BC.getID(id);

                
                MC.AddPrice(ModelTypeprice);

                Price tempPrice = MC.getPrice(ModelTypeprice);
                
                bool tempBool = MC.AddModelTypeControl(ModelTypename, ModelTypedesc, tempPrice.PriceID, ModelTypestock, ModelTypeimage, brandId.BrandID, fileSize);
                if (tempBool)
                {
                    FileUpload1.SaveAs(Server.MapPath("~") + "/Assets/ModelTypes/" + FileUpload1.FileName);

                    Response.Redirect("~/Views/DetailBrand.aspx?id=" + id);
                }
                else
                {
                    ErrLbl.Text = "Invalid Input";
                }
            }
        }

        protected void CancelBTN_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Response.Redirect("~/Views/DetailBrand.aspx?id=" + id);
        }
    }
}