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
    public partial class UpdateBrand : System.Web.UI.Page
    {
        ModelTypeController MC = new ModelTypeController();
        UpdateController UC = new UpdateController();
        BrandController BC = new BrandController();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            Brand brandId = BC.getID(id);
            ItemLbl.Text = brandId.BrandName;
            ItemImage.ImageUrl = "../Assets/Brands/" + brandId.BrandImage;

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
            if (Session["Admin"] != null)
            {
                EditBtn.Visible = true;
                CancelBtn.Visible = true;
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            string name = BrandNameTXT.Text.ToString();
            string image = FileUpload1.FileName;
            int tempBool = UC.UpdateBrandController(id, name, image);
            if (tempBool == 1)
            {
                //Hapus dulu yang udah ada gambarnya di asset
                FileUpload1.SaveAs(Server.MapPath("~") + "/Assets/Brands/" + FileUpload1.FileName);
                Response.Redirect("~/Views/HomePage.aspx");
            }
            else if (tempBool == 0)
            {
                ErrLbl.Text = "Invalid Input";
            }
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}