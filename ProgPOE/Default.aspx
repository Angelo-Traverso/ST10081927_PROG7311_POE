<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProgPOE._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <ul class="nav nav-pills nav-fill">
            <li class="nav-item">
                <a runat="server" id="tabLogin" href="#lo   gIn" class="nav-link" aria-current="page" aria-controls="logIn" role="tab" data-toggle="tab">LOG IN</a>
            </li>
            <li class="nav-item">
                <a runat="server" id="tabTest1" class="nav-link" href="#libraries" aria-controls="libraries" role="tab" data-toggle="tab">View Products</a>
            </li>
            <li class="nav-item">
                <a runat="server" id="tabTest2" class="nav-link" href="#hosting" aria-controls="hosting" role="tab" data-toggle="tab">Add Farmer</a>
            </li>
        </ul>

        <div class="tab-content">
            <div role="tabpanel" class="tab-pane active" id="logIn">
                <h2>LOG IN</h2>
                <div class="mb-3">
                    <label for="formGroupExampleInput" class="form-label">Username</label>
                    <asp:TextBox ID="txtUsername" type="text" class="form-control" placeholder="Username" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="formGroupExampleInput2" class="form-label">Password</label>
                    <asp:TextBox ID="txtPassword" type="password" class="form-control" placeholder="Password" runat="server" />
                </div>
                <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click" />
            </div>
            
            <div role="tabpanel" class="tab-pane" id="hosting">
                <h2>Web Hosting</h2>
                <!-- Content for Web Hosting tab -->
            </div>
        </div>
    </main>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {
            $('.nav-link.disabled').on('click', function (e) {
                e.preventDefault();
            });
        });
    </script>
</asp:Content>
