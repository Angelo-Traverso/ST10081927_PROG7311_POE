<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProgPOE._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="Styles/Login.css" type="text/css" media="screen" />

    <div class="wrapper fadeInDown">
        <div id="formContent">
            <div class="fadeIn first">
                <h2>Login</h2>
                <p>Log in to your existing Farm Central account</p>
            </div>
            <asp:TextBox type="text" ID="txtUsername" runat="server" class="fadeIn second" name="login" placeholder="login"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtUsername" runat="server" ErrorMessage="Username is required" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox type="password" ID="txtPassword" runat="server" class="fadeIn third" name="login" placeholder="password"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtPassword" runat="server" ErrorMessage="Password is required" Display="Dynamic" ForeColor="Red"> </asp:RequiredFieldValidator>
            <asp:Button type="submit" runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" class="shadow-lg fadeIn fourth" Text="Log In"></asp:Button>

            <div id="formFooter">
                <a class="underlineHover" href="#">Forgot Password?</a>
            </div>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</asp:Content>
