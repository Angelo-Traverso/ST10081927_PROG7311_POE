<%@ Page Title="Add Farmer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddFarmer.aspx.cs" Inherits="ProgPOE.AddFarmer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <h2>Enter Information</h2>
            <div class="form-group">
                <div class="form-group">
                <label for="txtEmail">Username</label>
                <asp:TextBox ID="txtUSername" CssClass="form-control" placeholder="Email Address" runat="server"></asp:TextBox>
            </div>
                <div class="form-group">
                <label for="txtEmail">Password</label>
                <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="Email Address" runat="server"></asp:TextBox>
            </div>
                <label for="txtName">Name</label>
                <asp:TextBox ID="txtName" CssClass="form-control" TextMode="Password" placeholder="Name" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtSurname">Surname</label>
                <asp:TextBox ID="txtSurname" placeholder="Surname" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDateOfBirth">Date of Birth</label>
                <asp:TextBox ID="txtDateOfBirth" CssClass="form-control" placeholder="Date of Birth" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtCell">Cell</label>
                <asp:TextBox ID="txtCell" CssClass="form-control" placeholder="Cell Number" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtEmail">Email Address</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Email Address" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnSave" runat="server"  Text="Save" CssClass="btn btn-primary"/>
        </div>
    </main>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</asp:Content>
