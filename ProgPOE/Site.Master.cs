/*
 * Student Name:    Angelo Traverso
 * Student Number:  ST10081927
 * Project:         Programming POE Part 2
 * Project Title:   Farm Central Prototype Website
 */
using System;
using System.Web;
using System.Web.UI;

namespace ProgPOE
{
    public partial class SiteMaster : MasterPage
    {
        /// <summary>
        ///     PageLoad Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.DataBind();

            // Getting current page name
            string currentPage = System.IO.Path.GetFileNameWithoutExtension(Request.Url.AbsolutePath);

            // If current page = "Default" then hide certain nav items
            if (currentPage.Equals("Default", StringComparison.OrdinalIgnoreCase))
            {
                // Hide all navigation items on the Default page
                navViewProducts.Visible = false;
                navAddProduct.Visible = false;
                navAddFarmer.Visible = false;
            }
            else
            {
                // Check the session value for the logged-in user
                if (Session["LoggedIntype"] != null)
                {
                    string userType = Session["LoggedIntype"].ToString();

                    if (userType.Equals("Farmer"))
                    {
                        // User is logged in as a Farmer, hide certain navigation items
                        navViewProducts.Visible = false;
                        navAddFarmer.Visible = false;
                    }
                    else if (userType.Equals("Employee"))
                    {
                        // User is logged in as an Employee, hide certain navigation items
                        navAddProduct.Visible = false;
                    }
                }
                else
                {
                    // User is not logged in, show all navigation items
                    navViewProducts.Visible = true;
                    navAddProduct.Visible = true;
                    navAddFarmer.Visible = true;
                }
            }

            // Check if the session exists
            if (HttpContext.Current.Session["Username"] != null)
            {
                string username = HttpContext.Current.Session["Username"].ToString();

                // Display the username in the <span> tag
                spanUsername.Visible = true;
                litUsername.Text = username;
            }
            else
            {
                // Hide the <span> tag if the session doesn't exist
                spanUsername.Visible = false;
            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to validate whether a user is a farmer.
        ///     If user is a farmer, client side code then hides certain nav items depending on logged in user
        /// </summary>
        /// <returns></returns>
        public bool IsNavItemVisibleFarmer()    // (ChatGpt, 2023)
        {
            if (Session["LoggedInType"] != null)
            {
                string userRole = Session["LoggedInType"].ToString();

                // Check if the user role is "Farmer" and hide the navigation item
                if (userRole.Equals("Farmer", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
            // Show the navigation item for all other users or when the role check fails
            return true;
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to validate whether a user is a farmer.
        ///     If user is a farmer, client side code then hides certain nav items depending on logged in user
        /// </summary>
        /// <returns></returns>
        public bool IsNavItemVisibleEmployee()  // (ChatGpt, 2023)
        {
            if (Session["LoggedInType"] != null)
            {
                string userRole = Session["LoggedInType"].ToString();

                // Check if the user role is "Farmer" and hide the navigation item
                if (userRole.Equals("Farmer", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
            // Show the navigation item for all other users or when the role check fails
            return true;
        }
    }
}
// --------------------------------- .....ooooo00000 END OF FILE 00000ooooo..... --------------------------------- //