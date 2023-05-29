<%@ Page Title="View Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="ProgPOE.ViewProducts" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="Styles/ViewProducts.css" type="text/css" media="screen" />

    <div class="container d-flex justify-content-center align-items-center">
        <div class="row">
            <div class="col-md-4">
                <p>
                    <button class="btn btn-info" type="button" data-bs-toggle="collapse" data-bs-target="#collapseWidthExample" aria-expanded="false" aria-controls="collapseWidthExample">
                        Help
                    </button>
                </p>
                <div>
                    <div class="collapse collapse-horizontal" id="collapseWidthExample">
                        <div class="card card-body" style="width: 300px;">
                            You can select any filter criteria you wish. You can either sort by a farmer, Sort by a Product Type, a start and end date or you can mix and match your filters to get specific results.
                        </div>
                    </div>
                </div>
                <div class="wrapper fadeInDown">
                    <div class="formContent" style="margin-right: 30px">
                        <h2 style="text-align: center">Filter</h2>
                        <div class="form-group">
                            <label for="ddlFarmer" class="fadeIn first">Farmer</label>
                            <br>
                            <asp:DropDownList ID="ddlFarmer" Class="ddl fadeIn first" runat="server">
                                <asp:ListItem Text="All" Value=""></asp:ListItem>
                            </asp:DropDownList>
                            <label for="ddlProductType" class="fadedIn first">Product Type</label>
                            <asp:DropDownList ID="ddlProductType" Class="ddl fadeIn first" runat="server">
                                <asp:ListItem Text="All" Value=""></asp:ListItem>
                            </asp:DropDownList>
                            <br>
                            <label for="txtStartDate">Start Date</label>
                            <br>
                            <asp:TextBox ID="txtStartDate" TextMode="Date" class="fadeIn second" runat="server"></asp:TextBox>
                            <br>
                            <label for="txtEndDate">End Date</label>
                            <br>
                            <asp:TextBox ID="txtEndDate" TextMode="Date" class="fadeIn second" runat="server"></asp:TextBox>
                            <br>
                            <asp:CompareValidator ControlToValidate="txtEndDate" runat="server" ControlToCompare="txtStartDate" ID="cvDates" Operator="GreaterThan" Display="Dynamic" ErrorMessage="Start Date Can't be greater than End Date" ForeColor="Red" Type="Date"></asp:CompareValidator>
                            <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-primary" OnClick="btnFilter_Click" />
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-warning" OnClick="btnReset_Click" />
                        </div>
                    </div>
                    <div class="formContent2">
                        <div class="col-md-8">
                            <div class="row">
                                <h2>Product List</h2>
                                <asp:Label runat="server" ID="lblNoProductsFound" Visible="false" Text="No products found for filtered criteria!" ForeColor="Red"></asp:Label>
                                <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" CssClass="table table-active table-striped-columns table-hover">
                                    <Columns>
                                        <asp:BoundField DataField="FarmerName" HeaderText="Name" />
                                        <asp:BoundField DataField="FarmerSurname" HeaderText="Surname" />
                                        <asp:BoundField DataField="ProductCode" HeaderText="Product Code" />
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                        <asp:BoundField DataField="ProductType" HeaderText="Product Type" />
                                        <asp:BoundField DataField="Price" HeaderText="Product Price(Rands)" />
                                        <asp:BoundField DataField="Quantity" HeaderText="Product Quantity" />
                                        <asp:BoundField DataField="Date" HeaderText="Date Added" DataFormatString="{0:yyyy/MM/dd}" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</asp:Content>
