<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Template.Master" AutoEventWireup="true" CodeBehind="AddModelType.aspx.cs" Inherits="ProjectFinalLEC.Views.AddModelType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            display: flex;
            justify-content: center;
            margin-top: 50px;
        }

        .form-container {
            display: flex;
            flex-direction: column;
            align-items: flex-start;
            margin-top: 20px;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            width: 400px;
        }

        .form-container label {
            margin-bottom: 10px;
        }

        .form-container input[type="text"],
        .form-container input[type="file"],
        .form-container input[type="submit"],
        .form-container input[type="button"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            box-sizing: border-box;
        }

        .form-container .heading {
            text-align: center;
            width: 100%; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form-container">
            <div class="heading"> 
                <h1>Add ModelType</h1>
            </div>

            <asp:Label ID="ModelTypeNameLBL" runat="server" Text="ModelType Name"></asp:Label>
            <asp:TextBox ID="ModelTypeNameTXT" runat="server"></asp:TextBox>

            <br />

            <asp:Label ID="ModelTypeDescLBL" runat="server" Text="ModelType Description"></asp:Label>
            <asp:TextBox ID="ModelTypeDescTXT" runat="server"></asp:TextBox>

            <br />

            <asp:Label ID="ModelTypePriceLBL" runat="server" Text="ModelType Price"></asp:Label>
            <asp:TextBox ID="ModelTypePriceTXT" runat="server"></asp:TextBox>

            <br />

            <asp:Label ID="ModelTypeStockLBL" runat="server" Text="ModelType Stock"></asp:Label>
            <asp:TextBox ID="ModelTypeStockTXT" runat="server"></asp:TextBox>

            <br />

            <asp:Label ID="ModelTypeImageLBL" runat="server" Text="ModelType Image"></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" />

            <br />

            <asp:Label ID="ErrLbl" runat="server" Text="" ForeColor="Red"></asp:Label>

            <br />

            <asp:Button ID="SubmitBTN" runat="server" Text="Submit" OnClick="SubmitBTN_Click" Cssclass="btn btn-primary mb-3" />
            <asp:Button ID="CancelBTN" runat="server" Text="Cancel" OnClick="CancelBTN_Click" Cssclass="btn btn-outline-danger mb-3"  />
        </div>
    </div>
</asp:Content>
