/*
 * Student Name:    Angelo Traverso
 * Student Number:  ST10081927
 * Project:         Programming POE Part 2
 * Project Title:   Farm Central Prototype Website
 */
using System;

namespace ProgPOE
{
    public partial class AddFarmer : System.Web.UI.Page
    {
        /// <summary>
        ///     Creating an instance of DBController class
        /// </summary>
        private DBController dbController = new DBController();
        /// <summary>
        ///     Creating an instance of encryption class in order to encrypt, decrypt and validate user passwords
        /// </summary>
        private Encryption encrypt = new Encryption();

        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Page_Load event to br triggered every page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     A button click event to save all farmer details to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Setting farmer variables with user input
            string username = txtUSername.Text;
            // Hashing user password for DB
            string password = encrypt.HashPassword(txtPassword.Text);
            string fName = txtName.Text;
            string fSurname = txtSurname.Text;
            DateTime DOB = DateTime.Parse(txtDOB.Text);
            string cell = txtCell.Text;
            string email = txtEmail.Text;

            // If username is unique, then add new farmer
            if (dbController.IsUsernameUnique(username))
            {
                lblUsernameExists.Visible = false;

                // New object of type Farmer
                var farmer = new Farmer // (ChatGpt, 2023)
                {
                    farmer_name = fName,
                    farmer_surname = fSurname,
                    farmer_DOB = DOB,
                    farmer_cell = cell,
                    farmer_email = email,
                    user_username = username

                };

                // New object of type Login_Credentials
                var loginCredentials = new Login_Credentials
                {
                    user_username = username,
                    user_password = password
                };

                // Adding Login_Credentails to DB
                dbController.AddLoginCreds(loginCredentials);
                
                // Adding Farmer to DB
                dbController.AddFarmer(farmer);

                // Setting inputs to default state
                txtUSername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtName.Text = string.Empty;
                txtSurname.Text = string.Empty;
                txtCell.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtDOB.Text = string.Empty;

                // Hiding error lables
                lblUsernameExists.Visible = false;

                // Showing success alert for user when successfully added a new product
                displayAlert.Visible = true;
            }
            else
            {
                // Showing error if username exists
                lblUsernameExists.Visible = true;
            }
        }
    }
}
// --------------------------------- .....ooooo00000 END OF FILE 00000ooooo..... --------------------------------- //