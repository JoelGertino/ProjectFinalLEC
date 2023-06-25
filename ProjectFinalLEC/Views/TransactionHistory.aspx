<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Template.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="ProjectFinalLEC.Views.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding:2% 10%">
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Transaction ID</th>
                    <th scope="col">Transaction Date</th>
                    <th scope="col">Customer Name</th>
                    <th scope="col">ModelType Picture</th>
                    <th scope="col">ModelType Name</th>          
                    <th scope="col">ModelType Quantity</th>
                    <th scope="col">ModelType Price</th>
                    
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="TableRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td scope="row"><%# Eval("TransactionID") %></td>
                            <td scope="row"><%# Eval("TransactionDate") %></td>
                            <td scope="row"><%# Eval("CustomerName") %></td>
                            <td scope="row">
                                <img src="../Assets/ModelTypes/<%# Eval("ModelTypeImage") %>"  style="max-width:200px" alt="ModelType Image" />
                            </td>
                            <td scope="row"><%# Eval("ModelTypeName") %></td>
                            <td scope="row"><%# Eval("Qty") %></td>
                            <td scope="row"><%# Eval("ModelTypePrice") %></td>
                            
                            
                            
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
