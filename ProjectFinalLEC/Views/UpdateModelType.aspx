<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Template.Master" AutoEventWireup="true" CodeBehind="UpdateModelType.aspx.cs" Inherits="ProjectFinalLEC.Views.UpdateModelType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 2% 0% ">
        <div class="d-flex justify-content-around ">
            <div class="flex-left-gig">
                <h1><asp:Label ID="ModelTypeLBL" runat="server"></asp:Label></h1>
                <asp:Image ID="ModelTypeImage" runat="server" class="card-img-top title-hover" style="max-width:400px;"/>
            </div>
            <div class="flex-right-gig">
                <asp:Panel ID="BtnPanel" runat="server" >
                    <div class="d-flex flex-column ">
                        <asp:Label ID="ModelTypeNameLBL" runat="server" Text="ModelType Name"></asp:Label>
                        <asp:TextBox ID="ModelTypeNameTxt" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="ModelTypeDescLBL" runat="server" Text="ModelType Description"></asp:Label>
                        <asp:TextBox ID="ModelTypeDescTxt" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="ModelTypePriceLBL" runat="server" Text="ModelType Price"></asp:Label>
                        <asp:TextBox ID="ModelTypePriceTxt" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="ModelTypeStockLBL" runat="server" Text="ModelType Stock"></asp:Label>
                        <asp:TextBox ID="ModelTypeStockTxt" runat="server"></asp:TextBox>               
                        <br />
                        <asp:Label ID="ModelTypeImageLBL" runat="server" Text="ModelType Image"></asp:Label>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <br />
                        <asp:Label ID="Errlbl" runat="server" Text=""></asp:Label>
                        <br />

                        <asp:Button ID="UpdateBTN" runat="server" Text="Update" OnClick="UpdateBTN_Click" />
                        <asp:Button ID="CancelBTN" runat="server" Text="Cancel" OnClick="CancelBTN_Click" />

                        <br />
                    </div>
                </asp:Panel>
            </div>
            
           
        </div>
       
     </div>
</asp:Content>
