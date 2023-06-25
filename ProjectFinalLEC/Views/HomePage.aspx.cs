using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.BrandManagement.Controller;

namespace ProjectFinalLEC.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        UpdateController UC = new UpdateController();
        BrandController BC = new BrandController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CardRepeater.DataSource = BC.getAllBrand();
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
                }

                if (Session["Admin"] != null)
                {
                    AddArtistBtn.Visible = true;
                    foreach (RepeaterItem item in CardRepeater.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            LinkButton UpdateButton = (LinkButton)item.FindControl("UpdateButton");
                            LinkButton DeleteButton = (LinkButton)item.FindControl("DeleteButton");

                            // Set the visibility of UpdateButton and DeleteButton to true
                            UpdateButton.Visible = true;
                            DeleteButton.Visible = true;
                        }
                    }


                }
            }
        }

        protected void OpenDetail_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = (LinkButton)sender;
            string id = linkbtn.CommandArgument;
            Response.Redirect("~/Views/DetailBrand.aspx?id=" + id);
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            LinkButton updateButton = (LinkButton)sender;
            string id = updateButton.CommandArgument;
            Response.Redirect("~/Views/UpdateBrand.aspx?id=" + id);
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            LinkButton deleteButton = (LinkButton)sender;
            string idTemp = deleteButton.CommandArgument;
            int id = Convert.ToInt32(idTemp);
            UC.DeleteBrandController(id);
            Response.Redirect("~/Views/HomePage.aspx");
        }
        

        protected void AddArtistBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/AddBrand.aspx");
        }
    }
}