<%@ Page Title="Add Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="ProgPOE.AddProduct" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="Styles/AddProduct.css" type="text/css" media="screen" />

    <div id="displayAddedProduct" class="alert alert-success" visible=" false" runat="server" role="alert">
        Successfully Added Product!
    </div>

    <div class="wrapper fadeInDown">
        <div id="formContent">
            <div class="fadeIn first">
                <h2>Add New Product</h2>
                <p>Enter all product information below</p>
                <div class="progress" style="margin-bottom: 30px">
                    <div id="progressBar" class="progress-bar progress-bar-animated progress-bar-striped bg-danger" style="width: 0%" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtProductCode" Class="fadeIn second" placeholder="Product Code" runat="server"></asp:TextBox>
                <br>
                <asp:RequiredFieldValidator ControlToValidate="txtProductCode" Display="Dynamic" ForeColor="Red" ErrorMessage="Product Code is required" ID="rfvProductCode" runat="server"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revProdCode" runat="server"
                    ControlToValidate="txtProductCode"
                    ValidationExpression="^[A-Za-z][A-Za-z0-9]{0,5}$"
                    ErrorMessage="Product Code must start with a letter and be no longer than 6 characters"
                    Display="Dynamic" ForeColor="Red">
                </asp:RegularExpressionValidator>
                <asp:Label ID="lblProdCodeExists" Text="This product code already exists!" Visible="false" runat="server" ForeColor="Red" />
            </div>

            <div class="form-group">
                <asp:TextBox ID="txtProductName" Class="fadeIn third" placeholder="Product Name" runat="server"></asp:TextBox>
                <br>
                <asp:RequiredFieldValidator ControlToValidate="txtProductName" Display="Dynamic" ForeColor="Red" ErrorMessage="Product Name is required" ID="rfvProdName" runat="server"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                    ControlToValidate="txtProductName"
                    ErrorMessage="Product Name must contain only letters"
                    ValidationExpression="^[a-zA-Z\s]+$"
                    Display="Dynamic"
                    ForeColor="Red">
                </asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <asp:TextBox ID="txtProductType" Class="fadeIn third" placeholder="Product Type" runat="server"></asp:TextBox>
                <br>
                <asp:RequiredFieldValidator ControlToValidate="txtProductType" Display="Dynamic" ForeColor="Red" ErrorMessage="Product Type is required" ID="rfvProdType" runat="server"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revProdType" runat="server"
                    ControlToValidate="txtProductType"
                    ErrorMessage="Product Type must contain only letters"
                    ValidationExpression="^[a-zA-Z\s]+$"
                    Display="Dynamic"
                    ForeColor="Red">
                </asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <asp:TextBox ID="txtPrice" Class="fadeIn third" placeholder="Product Price" runat="server"></asp:TextBox>
                <br>
                <asp:RequiredFieldValidator ControlToValidate="txtPrice" Display="Dynamic" ForeColor="Red" ErrorMessage="Price is required" ID="rfvPrice" runat="server"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ControlToValidate="txtPrice" ValidationExpression="^(?=.*[1-9])\d{0,8}(.\d{1,2})?$" Display="Dynamic" ForeColor="Red" ErrorMessage="Invalid price format or value. Enter a valid decimal value between 1.00 and 20000000.00" runat="server"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <asp:TextBox ID="txtProductQuantity" TextMode="Number" placeholder="Quantity" Class="fadeIn third" runat="server"></asp:TextBox>
                <br>
                <asp:RequiredFieldValidator ControlToValidate="txtProductQuantity" Type="Integer" Display="Dynamic" ForeColor="Red" ErrorMessage="Product Quantity is required" ID="rfvQuantity" runat="server"></asp:RequiredFieldValidator>
                <br>
                <asp:RangeValidator ControlToValidate="txtProductQuantity" Type="Integer" MinimumValue="1" Display="Dynamic" MaximumValue="2000" runat="server" ForeColor="Red" ErrorMessage="You can't have less than 1 or more than 2000 products"></asp:RangeValidator>
            </div>
            <div class="form-group">
                <asp:Button type="submit" runat="server" ID="btnAddProduct" OnClick="btnAddProduct_Click" class="fadeIn fourth" Text="Add Product"></asp:Button>
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <script>
        $(document).ready(function () { // (ChatGpt, 2023)
            // Initial progress value
            var progressValue = 0;

            // Function to increment progress by a given percentage
            function incrementProgress(percentage) {
                progressValue += percentage;
                $('#progressBar').css('width', progressValue + '%').attr('aria-valuenow', progressValue);

                if (progressValue < 26) {
                    // Remove the existing class and add a new class
                    $('#progressBar').removeClass('bg-warning').addClass('bg-danger');
                }

                if (progressValue > 25 && progressValue < 100) {
                    // Remove the existing class and add a new class
                    $('#progressBar').removeClass('bg-danger').addClass('bg-warning');
                }


                if (progressValue === 100) {
                    // Remove the existing class and add a new class
                    $('#progressBar').removeClass('bg-warning').addClass('bg-success');
                }
            }

            // Bind the change event to each input field
            $('input[type=text], input[type=password], input[type=date], input[type=number]').on('input', function () {

                // Calculate the current progress based on the number of filled input fields
                var filledFields = $('input[type=text], input[type=password], input[type=date], input[type=number]').filter(function () {
                    return $(this).val().trim().length > 0;
                }).length;

                // Calculate the progress percentage
                var percentage = (filledFields / $('input[type=text], input[type=password], input[type=date], input[type=number]').length) * 100;

                // Update the progress bar
                incrementProgress(percentage - progressValue);
            });
        });
    </script>
</asp:Content>
