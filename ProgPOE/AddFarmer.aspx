<%@ Page Title="Add Farmer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddFarmer.aspx.cs" Inherits="ProgPOE.AddFarmer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="Styles/AddFarmer.css" type="text/css" media="screen" />

    <h1 style="text-align: center; margin-bottom: 30px; font-family: 'Poppins', sans-serif; font-weight: bold">New Farmer</h1>

    <div class="alert alert-success" runat="server" id="displayAlert" visible="false" role="alert">
        Successfully added new farmer!
    </div>

    <div class="progress" style="margin-bottom: 30px">
        <div id="progressBar" class="progress-bar progress-bar-animated progress-bar-striped bg-danger" style="width: 0%" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
    </div>

    <div class="wrapper fadeInDown">
        <div class="formContent" style="margin-right: 30px">
            <div class="fadeIn first">
                <h2>Login Credendtials</h2>
                <p>Enter all of the new farmers' login credentials to gain access to the site</p>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtUSername" Class="fadeIn second" placeholder="Username" runat="server"></asp:TextBox>
                <br>
                <asp:RequiredFieldValidator ControlToValidate="txtUSername" Display="Dynamic" ForeColor="Red" ErrorMessage="Username is required" ID="rfvUsername" runat="server"></asp:RequiredFieldValidator>

                <asp:Label ID="lblUsernameExists" runat="server" Visible="false" ForeColor="Red">This username already exists</asp:Label>
            </div>

            <div class="form-group">
                <asp:TextBox ID="txtPassword" TextMode="Password" Class="fadeIn third" placeholder="Password" runat="server"></asp:TextBox>
                <br>
                <asp:RequiredFieldValidator ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red" ErrorMessage="Password is required" ID="rfvPassword" runat="server"></asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator ID="regexPassword" runat="server" ControlToValidate="txtPassword"
                    ValidationExpression="^(?=.*[A-Z])(?=.*\d|.*[\p{P}\p{S}])(?!.*\s).{6,}$"
                    ErrorMessage="Password must contain at least 1 uppercase letter, 1 number or symbol, and be at least 6 characters long."
                    Display="Dynamic"
                    Font-Size="Small"
                    ForeColor="Red">
                </asp:RegularExpressionValidator>
            </div>
            <div class="form-group" style="margin-bottom: 30px">
                <asp:TextBox ID="txtConfirmPassword" TextMode="Password" Class="fadeIn third" placeholder="Confirm Password" runat="server"></asp:TextBox>
                <br>
                <asp:RequiredFieldValidator ControlToValidate="txtConfirmPassword" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Confirm Password is required" ID="rfvConfirmPassword"></asp:RequiredFieldValidator>

                <asp:CompareValidator ControlToValidate="txtConfirmPassword" runat="server" ControlToCompare="txtPassword" ID="cvPassword" Operator="Equal" Display="Dynamic" ErrorMessage="Passwords Don't match!" ForeColor="Red" Type="String"></asp:CompareValidator>
            </div>

        </div>
        <div class="wrapper fadeInDown">
            <div class="formContent">
                <div class="fadeIn first">
                    <h2>Personal Information</h2>
                    <p>Enter new farmer information</p>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtName" Class="fadeIn third" placeholder="Name" runat="server"></asp:TextBox>
                    <br>
                    <asp:RequiredFieldValidator ControlToValidate="txtName" Display="Dynamic" ForeColor="Red" ErrorMessage="Name is required" ID="rfvName" runat="server"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revName" runat="server"
                        ControlToValidate="txtName"
                        Display="Dynamic"
                        ForeColor="Red"
                        ErrorMessage="Please enter only letters (no numbers or special characters)"
                        ValidationExpression="^[a-zA-Z]+$"
                        ValidationGroup="ValidationGroup1"></asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtSurname" placeholder="Surname" CssClass="fadeIn third" runat="server"></asp:TextBox>
                    <br>
                    <asp:RegularExpressionValidator ID="revSurname" runat="server"
                        ControlToValidate="txtSurname"
                        ErrorMessage="Please enter only letters (no numbers or special characters)"
                        ValidationExpression="^[a-zA-Z]+$"
                        Display="Dynamic"
                        ForeColor="Red"
                        ValidationGroup="ValidationGroup1"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ControlToValidate="txtSurname" Display="Dynamic" ForeColor="Red" ErrorMessage="Surname is required" ID="rfvSurname" runat="server"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtDOB" TextMode="Date" plaveholder="Date of birth" ToolTip="Date of birth" CssClass="fadeIn third" runat="server"></asp:TextBox>
                    <br>
                    <asp:RequiredFieldValidator ControlToValidate="txtDOB" Display="Dynamic" ForeColor="Red" ErrorMessage="Date of Birth is required" ID="rfvDOB" runat="server"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtCell" CssClass="fadeIn third" placeholder="Cell Number" runat="server"></asp:TextBox>
                    <br>
                    <asp:RequiredFieldValidator ControlToValidate="txtCell" Display="Dynamic" ForeColor="Red" ErrorMessage="Cell is required" ID="rfvCell" runat="server"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revCell" runat="server"
                        ControlToValidate="txtCell"
                        ValidationExpression="^(0[0-9]{9})$"
                        ErrorMessage="Input must start with zero, be 10 digits long, and contain only numbers."
                        Display="Dynamic"
                        ForeColor="Red"></asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtEmail" CssClass="fadeIn third" placeholder="Email Address" runat="server"></asp:TextBox>
                    <br>
                    <asp:RequiredFieldValidator ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ErrorMessage="Email is required" ID="rfvEmail" runat="server"></asp:RequiredFieldValidator>
                    <br>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server"
                        ControlToValidate="txtEmail"
                        ValidationExpression="^[A-Za-z][^@]*@[^@]*$"
                        ErrorMessage="Please enter a valid Email"
                        Display="Dynamic"
                        ForeColor="Red"></asp:RegularExpressionValidator>
                </div>

                <asp:Button type="submit" runat="server" ID="btnSave" OnClick="btnSave_Click" class="fadeIn fourth" Text="Save"></asp:Button>

                <div id="formFooter">
                    <a class="btn btn-outline-info" data-bs-toggle="offcanvas" href="#offcanvasExample" role="button" aria-controls="offcanvasExample">Help
                    </a>
                    <div class="offcanvas offcanvas-start" tabindex="-1" id="offcanvasExample" aria-labelledby="offcanvasExampleLabel">
                        <div class="offcanvas-header">
                            <h5 class="offcanvas-title" id="offcanvasExampleLabel">Help</h5>
                            <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                        </div>
                        <div class="offcanvas-body">
                            <div>
                                Name: Enter the name of the farmer. (eg. Angelo)<br>
                                Surname: Enter the surname of the farmer. (eg. Pompie)<br>
                                Date of birth: Enter the date of birth of the farmer. (eg. 2000/01/25)<br>
                                Cell Number: Enter the cell number of the farmer. (eg. 012 345 6789)<br>
                                Email Address: Enter the email address of the farmer. (eg. pietPompies@gmail.com)<br>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <script>
        $(document).ready(function () { // (ChatGpt, 2023)
            console.log("Ready");
            // Initial progress value
            var progressValue = 0;


            // Function to increment progress by a given percentage
            function incrementProgress(percentage) {
                progressValue += percentage;
                $('#progressBar').css('width', progressValue + '%').attr('aria-valuenow', progressValue);

                if (progressValue < 26) {
                    $('#progressBar').removeClass('bg-warning').addClass('bg-danger');
                }

                if (progressValue > 25 && progressValue < 100) {
                    $('#progressBar').removeClass('bg-danger').addClass('bg-warning');
                }


                if (progressValue === 100) {
                    // Remove the existing class and add a new class
                    $('#progressBar').removeClass('bg-warning').addClass('bg-success');
                }
            }

            // Bind the change event to each input field
            $('input[type=text], input[type=password], input[type=date]').on('input', function () {
                // Calculate the current progress based on the number of filled input fields
                var filledFields = $('input[type=text], input[type=password], input[type=date]').filter(function () {
                    return $(this).val().trim().length > 0;
                }).length;

                // Calculate the progress percentage
                var percentage = (filledFields / $('input[type=text], input[type=password], input[type=date]').length) * 100;

                // Update the progress bar
                incrementProgress(percentage - progressValue);
            });
        });

    </script>
</asp:Content>
