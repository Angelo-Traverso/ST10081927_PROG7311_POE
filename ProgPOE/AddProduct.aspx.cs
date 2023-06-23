/*
 * Student Name:    Angelo Traverso
 * Student Number:  ST10081927
 * Project:         Programming POE Part 2
 * Project Title:   Farm Central Prototype Website
 */
using System;

namespace ProgPOE
{
    public partial class AddProduct : System.Web.UI.Page
    {
        /// <summary>
        ///     DBController
        /// </summary>
        private DBController dbController = new DBController();

        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Page_Load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     button Add Product OnClick Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Setting values for object
            string prodCode = txtProductCode.Text.ToUpper();
            string prodName = txtProductName.Text;
            string prodType = txtProductType.Text;
            double prodPrice = double.Parse(txtPrice.Text);
            int quant = int.Parse(txtProductQuantity.Text);
            DateTime dateAdded = DateTime.Now.Date;

            // creating session of type farmer
            Farmer farmer = (Farmer)Session["LoggedInObject"];

            // Setting new Object of type Product
            Product prod = new Product  // (ChatGpt, 2023)
            {
                product_code = prodCode,
                product_name = prodName,
                product_type = prodType,
                product_price = prodPrice,
                product_quantity = quant,
                product_dateAdded = dateAdded

            };

            if (dbController.IsProductCodeUnique(prodCode))
            {
                // if product code is unique, add product
                dbController.AddProduct(prod);

                // Add to farmerproduct after, to fill weak entity
                dbController.AddFarmerProduct(prod.product_code, farmer.farmer_cell);

                // Hide error lable
                lblProdCodeExists.Visible = false;

                // Clear input fields
                ClearFields();

                // Display alert to user for newly added product
                displayAddedProduct.Visible = true;
            }
            else
            {
                // show error that product code exists
                lblProdCodeExists.Visible = true;
            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        #region Clear Fields
        /// <summary>
        ///     Method to clear all input fields
        /// </summary>
        private void ClearFields()
        {
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductType.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtProductQuantity.Text = string.Empty;
        }
        #endregion
    }
}
// --------------------------------- .....ooooo00000 END OF FILE 00000ooooo..... --------------------------------- //