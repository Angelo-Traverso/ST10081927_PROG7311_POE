<%@ Page Title="Add Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="ProgPOE.AddProduct" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <h2>Add New Product</h2>
            <div class="form-group">
                <label for="txtProductCode">Product Code</label>
                <asp:TextBox ID="txtProductCode" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtProductName">Product Name</label>
                <asp:TextBox ID="txtProductName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtProductQuantity">Product Quantity</label>
                <asp:TextBox ID="txtProductQuantity" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" CssClass="btn btn-primary" />
        </div>
    </main>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</asp:Content>