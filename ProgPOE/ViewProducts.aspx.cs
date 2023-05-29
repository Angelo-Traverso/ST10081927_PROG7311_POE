/*
 * Student Name:    Angelo Traverso
 * Student Number:  ST10081927
 * Project:         Programming POE Part 2
 * Project Title:   Farm Central Prototype Website
 */
using System;
using System.Web;

namespace ProgPOE
{
    public partial class ViewProducts : System.Web.UI.Page
    {
        /// <summary>
        ///     DBController
        /// </summary>
        private DBController dbController = new DBController();

        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     OnPageLoad Method for ViewProducts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!IsPostBack)
            {
                if (!IsUserLoggedIn())
                {
                    // User is not logged in, redirect them to the login page
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    //Populate Grid View
                    dbController.PopulateProductGridView(gvProducts);
                    // Populate Dropdown farmer name
                    dbController.PopulateFarmerDropdown(ddlFarmer);
                    // Populate Drop down product Type
                    dbController.PopulateProductTypeDropdown(ddlProductType);
                }
            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to validate whether a user is logged in or not
        /// </summary>
        /// <returns></returns>
        private bool IsUserLoggedIn()
        {
            // Check if the session variable "LoggedInType" exists and its value is "Employee"
            return HttpContext.Current.Session["LoggedInType"]?.ToString() == "Employee";

        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to filter Products for employees based on certain criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            // If farmer and product type selected 
            if (ddlFarmer.SelectedIndex > 0 && ddlProductType.SelectedIndex > 0)
            {
                dbController.FilterGridViewByFarmerAndProductType(gvProducts, ddlFarmer.SelectedItem.Text, ddlProductType.SelectedItem.Text);
            
            }
            // If only farmer selected
            else if (ddlFarmer.SelectedIndex > 0)
            {
                dbController.FilterProductGridViewByFarmer(gvProducts, dbController.GetFarmerCellNumberBySelectedName(ddlFarmer));
                
            }
            // If only product type selected
            else if (ddlProductType.SelectedIndex > 0)
            {
                dbController.FilterGridViewByProductType(gvProducts, ddlProductType.SelectedItem.Text);
               
            }
            else
            {
                dbController.PopulateProductGridView(gvProducts);
            }

            // If min and max dates are selected
            if (DateTime.TryParse(txtStartDate.Text, out DateTime startDate) && DateTime.TryParse(txtEndDate.Text, out DateTime endDate))
            {
               dbController.FilterGridViewByDate(gvProducts, startDate, endDate);
            }

            // If min and max date are selected alongside a farmer
            if (DateTime.TryParse(txtStartDate.Text, out DateTime startDate1) && DateTime.TryParse(txtEndDate.Text, out DateTime endDate2) && ddlFarmer.SelectedIndex > 0)
            {
                dbController.FilterGridViewByFarmerAndDate(gvProducts,ddlFarmer.SelectedItem.Text, startDate1, endDate2);
            }

            // If min and max date are selected alongside a product type
            if (DateTime.TryParse(txtStartDate.Text, out DateTime startDate5) && DateTime.TryParse(txtEndDate.Text, out DateTime endDate5) && ddlProductType.SelectedIndex > 0)
            {
                dbController.FilterGridView(gvProducts, ddlFarmer.SelectedItem.Text, ddlProductType.SelectedItem.Text, startDate5, endDate5);
            }

            // If min and max date are selected alongside a farmer and product type
            if (DateTime.TryParse(txtStartDate.Text, out DateTime startDate2) && DateTime.TryParse(txtEndDate.Text, out DateTime endDate1) && ddlFarmer.SelectedIndex > 0 && ddlProductType.SelectedIndex > 0)
            {
                dbController.FilterGridView(gvProducts, ddlFarmer.SelectedItem.Text, ddlProductType.SelectedItem.Text, startDate2, endDate1);
            }

            // Ff nothing is selected
            if (!(DateTime.TryParse(txtStartDate.Text, out DateTime startDate3)) && !(DateTime.TryParse(txtEndDate.Text, out DateTime endDate3)) && ddlFarmer.SelectedIndex == 0 && ddlProductType.SelectedIndex == 0)
            {
                dbController.PopulateProductGridView(gvProducts);
             
            }
            // If there is nothing to display, show error, else hide error
            if (gvProducts.Rows.Count == 0)
            {
                lblNoProductsFound.Visible = true;
                
                gvProducts.Visible = false;
            }
            else
            {
                lblNoProductsFound.Visible = false;
               
                gvProducts.Visible = true;
            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Button to reset all filter fields to default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            // Reset all dropdown lists
            ddlFarmer.SelectedIndex = 0;
            ddlProductType.SelectedIndex = 0;

            // Clear all textboxes
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            dbController.PopulateProductGridView(gvProducts);
        }
    }
}
// --------------------------------- .....ooooo00000 END OF FILE 00000ooooo..... --------------------------------- //