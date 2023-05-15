using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProgPOE
{
    public partial class _Default : Page
    {
        private DBController _dbController = new DBController();
        private string username = string.Empty;
        private string password = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {   
            // Simulate a user being signed in
            bool isSignedIn = true;

            // Update the authentication status and enable/disable tabs accordingly
            /*if (isSignedIn)
            {
                tabLogin.Attributes["class"] = "nav-link";
                tabTest1.Attributes["class"] = "nav-link";
                tabTest2.Attributes["class"] = "nav-link";
            }
            else
            {*/
            //{
                tabLogin.Attributes["class"] = "nav-link disabled";
                tabTest1.Attributes["class"] = "nav-link disabled";
                tabTest2.Attributes["class"] = "nav-link disabled";
           // }
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text;

            List<string> farmUsernames = new List<string>();
            List<string> empUsernames = new List<string>();

            _dbController.GetEmployeeUsername(empUsernames);
            _dbController.GetFarmerUsername(farmUsernames);



            if (farmUsernames.Contains(username))
            {
                Response.Redirect("AddProduct.aspx");
            }
            else if (empUsernames.Contains(username))
            {
                Response.Redirect("ViewProducts.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Invalid", "alert('" + "Incorrect Username or Password" + "');", true);
            }
        }
    }
}