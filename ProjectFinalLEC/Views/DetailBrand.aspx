<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Template.Master" AutoEventWireup="true" CodeBehind="DetailBrand.aspx.cs" Inherits="ProjectFinalLEC.Views.DetailBrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .label-text {
            text-decoration: none;
            color: black;
        }

        .label-text:hover {
            text-decoration: none;
            color: black;
        }

        .title-hover {
            text-decoration: none;
            color: black;
        }

        .title-hover:hover {
            text-decoration: underline;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 2% 0% ">
        <div class="d-flex justify-content-around ">
            <div class="flex-left-gig">
                <h1><asp:Label ID="ItemLbl" runat="server"></asp:Label></h1>
                <asp:Image ID="ItemImage" runat="server" class="card-img-top title-hover" style="max-width:400px;"/>
                <h2><asp:Label ID="ItemPrice" runat="server"></asp:Label></h2>
            </div>
            <div class="flex-right-gig">
                <asp:Panel ID="BtnPanel" runat="server" Visible="false">
                    
                </asp:Panel>
            </div>
            
           
        </div>
         
         <div style="text-align: center; margin-top: 20px;">
            <h3>Brands Model</h3>
             <asp:Button ID="AddModelTypeBtn" runat="server" Text="Add ModelType" OnClick="AddModelTypeBtn_Click" Visible="false" Cssclass="btn btn-light"/> 
            
        </div>

        <div class="" style="display: grid; grid-template-columns: repeat(5, minmax(0, 1fr)); gap: 1rem;"
                id="post-data">

                <asp:Repeater ID="CardRepeater" runat="server">
                    <ItemTemplate>
                        <div class="card m-2 card-cloth">
                            <asp:LinkButton ID="ModelTypeDetail" runat="server" Style="cursor: pointer" CommandArgument='<%#Eval("ModelTypeID") %>' OnClick="ModelTypeDetail_Click">
                                <div>
                                    <p>
                                        <img src="../Assets/ModelTypes/<%# Eval("ModelTypeImage") %>" class="card-img-top" alt="...">
                                    </p>
                                    <div class="card-body">
                                        <asp:Label ID="Label2" runat="server" Text="ModelTypeName : " CssClass="label-text"></asp:Label>
                                        <p class="card-text title-hover"><%# Eval("ModelTypeName") %></p><br />

                                        <asp:Label ID="Label3" runat="server" Text="ModelTypePrice : " CssClass="label-text"></asp:Label>
                                        <p class="card-text title-hover"><%# Eval("ModelTypePrice") %></p><br />

                                        <asp:Label ID="Label4" runat="server" Text="ModelTypeStock : " CssClass="label-text"></asp:Label>
                                        <p class="card-text title-hover"><%# Eval("ModelTypeStock") %></p><br />

                                        <asp:Label ID="Label5" runat="server" Text="ModelTypeDescription : " CssClass="label-text"></asp:Label>
                                        <p class="card-text title-hover"><%# Eval("ModelTypeDescription") %></p><br />
                                    </div>
                                    
                                </div>
                            </asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
         <br />
         <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
