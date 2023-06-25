using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.BrandManagement.Controller;
using ProjectFinalLEC.ModelTypeManagement.Controller;

namespace ProjectFinalLEC.Views
{
    public partial class DetailBrand : System.Web.UI.Page
    {
        BrandController BC = new BrandController();
        ModelTypeController MC = new ModelTypeController();
        UpdateController UC = new UpdateController();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            Brand brandId = BC.getID(id);
            ItemLbl.Text = brandId.BrandName;
            ItemImage.ImageUrl = "../Assets/Brands/" + brandId.BrandImage;

            CardRepeater.DataSource = MC.GetAllModelTypesController(brandId.BrandID);
            CardRepeater.DataBind();

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
                foreach (RepeaterItem item in CardRepeater.Items)
                {
                    LinkButton ModelTypeDetail = item.FindControl("ModelTypeDetail") as LinkButton;
                    ModelTypeDetail.Enabled = false;
                    ModelTypeDetail.Attributes["style"] = "cursor: not-allowed; pointer-events: none;";
                }
            }
            if (Session["Admin"] != null)
            {
                BtnPanel.Visible = true;
                AddModelTypeBtn.Visible = true;
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            Response.Redirect("~/Views/UpdateBrands.aspx?id=" + id);
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            UC.DeleteBrandController(id);
            Response.Redirect("~/Views/HomePage.aspx");
        }

        protected void AddModelTypeBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            Response.Redirect("~/Views/AddModelType.aspx?id=" + id);
        }

        protected void ModelTypeDetail_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = (LinkButton)sender;
            string id = linkbtn.CommandArgument;
            Response.Redirect("~/Views/DetailModelType.aspx?ModelTypeID=" + id);
        }
    }
}