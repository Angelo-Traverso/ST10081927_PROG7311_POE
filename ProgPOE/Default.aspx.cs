#region File Header
// // ----------------------------------------------------------------------------------------------------------- //
// // Student Name:     Angelo Traverso
// // Student Number:   ST10081927
// // Project:          Programming POE Part 2
// // Project Title:    Farm Central Prototype Website
// // ----------------------------------------------------------------------------------------------------------- //
#endregion
using System;
using System.Web.UI;

namespace ProgPOE
{
    public partial class _Default : Page
    {
        /// <summary>
        ///     DbController
        /// </summary>
        private DBController _dbController = new DBController();
        /// <summary>
        ///     Enctyption Class to hash and validate passwords
        /// </summary>
        private Encryption encrypt = new Encryption();
        /// <summary>
        ///     username String
        /// </summary>
        private string username = string.Empty;
        /// <summary>
        ///     password String
        /// </summary>
        private string password = string.Empty;



        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     PageLoad Event for Default (Sign In)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;

                // Removing all Session variables when user logs out
                Session.RemoveAll();
            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Button Click event for user "Login" clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text;
            password = txtPassword.Text;

            // Getting user login credentials
            Login_Credentials userLogin = _dbController.GetUserLoginCreds(username);


            if (userLogin.user_username != null)
            {
                if (LoginValidation(password, userLogin))
                {
                    if (_dbController.GetUserType(userLogin.user_username).Equals("Employee"))
                    {
                        // if user type = employee, then add session variables and redirect user
                        Session["LoggedInType"] = "Employee";
                        Session["Username"] = userLogin.user_username;
                        Response.Redirect("ViewProducts.aspx");

                    }
                    else
                    {
                        // if user type = employee, then add session variables and redirect user
                        Session["LoggedInType"] = "Farmer";
                        Session["Username"] = userLogin.user_username;
                        Farmer farmer = _dbController.GetFarmerByUsername(username);
                        // Setting another session key and value = object farmerobject
                        Session["LoggedInObject"] = farmer;
                        Response.Redirect("AddProduct.aspx");
                    }
                }
            }
            else
            {
                // Clearing input boxes and displaying error if incorrect login details are provided
                txtUsername.Text = "";
                txtPassword.Text = "";
                ClientScript.RegisterStartupScript(this.GetType(), "Invalid", "alert('" + "Incorrect Username or Password" + "');", true);

            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to validate a users' login credentials
        /// </summary>
        /// <param name="password"></param>
        /// <param name="loginCreds"></param>
        /// <returns></returns>
        private bool LoginValidation(string password, Login_Credentials loginCreds)
        {
            bool isFound = false;

            if (encrypt.ValidatePassword(password, loginCreds.user_password))
            {
                isFound = true;
            }

            return isFound;
        }
    }
}
// --------------------------------- .....ooooo00000 END OF FILE 00000ooooo..... --------------------------------- //