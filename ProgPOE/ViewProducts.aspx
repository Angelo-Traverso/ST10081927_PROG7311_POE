<%@ Page Title="View Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="ProgPOE.ViewProducts" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <h2>View Products</h2>
            <div class="form-group">
                <label for="ddlProductType">Product Type</label>
                <asp:DropDownList ID="ddlProductType" CssClass="form-control" runat="server">
                    <asp:ListItem Text="All" Value=""></asp:ListItem>
                    <asp:ListItem Text="Type 1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Type 2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Type 3" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtStartDate">Start Date</label>
                <asp:TextBox ID="txtStartDate" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtEndDate">End Date</label>
                <asp:TextBox ID="txtEndDate" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-primary" />
            <hr />
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                      <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Surname" HeaderText="Surname" />
                            <asp:BoundField DataField="ProdCode" HeaderText="Product Code" />
                            <asp:BoundField DataField="ProdName" HeaderText="Product Name" />
                            <asp:BoundField DataField="Price" HeaderText="Product Price" />
                            <asp:BoundField DataField="ProdQuantity" HeaderText="Product Quantity" />
                            <asp:BoundField DataField="ProdDateAdded" HeaderText="Date Added" />

                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </main>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</asp:Content>