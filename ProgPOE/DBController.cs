/*
 * Student Name:    Angelo Traverso
 * Student Number:  ST10081927
 * Project:         Programming POE Part 2
 * Project Title:   Farm Central Prototype Website
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;

namespace ProgPOE
{
    public class DBController
    {
        /// <summary>
        ///     Connection string to Database
        /// </summary>
        private string connectionString = Properties.Resources.connectionString;
        /// <summary>
        ///     Instance of DB Entities
        /// </summary>
        private farmStallDBEntities Entity;

        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Login_Credentials GetUserLoginCreds(string username) // (ChatGpt, 2023)
        {
            var userLogin = new Login_Credentials();

            try
            {
                using (this.Entity = new farmStallDBEntities())
                {

                    Employee empCheck = Entity.Employees.FirstOrDefault(e => string.Compare(e.user_username, username, true) == 0);

                    if (empCheck != null)
                        // if empCheck has values, find user login credentials where username = username
                        userLogin = this.Entity.Login_Credentials.Find(empCheck.user_username); 

                    Farmer farmerCheck = Entity.Farmers.FirstOrDefault(e => string.Compare(e.user_username, username, true) == 0);

                    if (farmerCheck != null)
                        userLogin = this.Entity.Login_Credentials.Find(farmerCheck.user_username);

                    return userLogin;

                }
            }
            catch (Exception)
            {
                return userLogin;
            }

        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to add a product to DB
        /// </summary>
        /// <param name="productIn"></param>
        public void AddProduct(Product productIn)   // (ChatGpt, 2023)
        {
            using (this.Entity = new farmStallDBEntities())
            {
                var product = new Product
                {
                    product_code = productIn.product_code, // Replace productCode with the desired value
                    product_name = productIn.product_name, // Replace productName with the desired value
                    product_type = productIn.product_type, // Replace productType with the desired value
                    product_price = productIn.product_price, // Replace price with the desired value
                    product_quantity = productIn.product_quantity, // Replace quantity with the desired value
                    product_dateAdded = productIn.product_dateAdded,
                };

                // Add Products to Product table
                Entity.Products.Add(product);

                // Save changes
                Entity.SaveChanges();
            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to validate whether or not a product already exists or not
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public bool IsProductCodeUnique(string productCode)
        {
            using (this.Entity = new farmStallDBEntities())
            {
                // Check if the product code exists in the database
                bool isUnique = !Entity.Products.Any(p => p.product_code == productCode);

                return isUnique;
            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to get farmer details by their username
        ///     Method returns type Farmer
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Farmer GetFarmerByUsername(string username)
        {
            using (this.Entity = new farmStallDBEntities())
            {
                var farmer = Entity.Farmers.FirstOrDefault(f => f.user_username == username);
                return farmer;
            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Methdo to add a FarmerProduct to DB
        /// </summary>
        /// <param name="prodCode"></param>
        /// <param name="cell"></param>
        public void AddFarmerProduct(string prodCode, string cell)
        {

            using (this.Entity = new farmStallDBEntities())
            {
                var fProduct = new FarmerProduct
                {
                    product_code = prodCode,
                    farmer_cell = cell,
                };
                
                Entity.FarmerProducts.Add(fProduct);

                Entity.SaveChanges();
            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to retrive user type: Farmer or Employee
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string GetUserType(string username)
        {
            string userType = string.Empty;

            try
            {
                using (this.Entity = new farmStallDBEntities())
                {

                    Employee empCheck = Entity.Employees.FirstOrDefault(e => string.Compare(e.user_username, username, true) == 0);

                    if (empCheck != null)
                        userType = "Employee";

                    Farmer farmerCheck = Entity.Farmers.FirstOrDefault(e => string.Compare(e.user_username, username, true) == 0);

                    if (farmerCheck != null)
                        userType = "Farmer";

                    return userType;

                }
            }
            catch (Exception)
            {
                return userType;
            }

        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to retrieve and populate farmer names into dropdown list
        /// </summary>
        /// <param name="ddl"></param>
        public void PopulateFarmerDropdown(DropDownList ddl)
        {
            using (this.Entity = new farmStallDBEntities())
            {
                List<string> farmerNames = Entity.Farmers.Select(farmer => farmer.farmer_name).ToList();
                for (int i = 0; i < farmerNames.Count; i++)
                {
                    ddl.Items.Add(farmerNames[i]);
                }
            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to filter gridview by farmer and product type
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="farmerName"></param>
        /// <param name="productType"></param>
        public void FilterGridViewByFarmerAndProductType(GridView gridView, string farmerName, string productType)  // (ChatGpt, 2023)
        {
            using (this.Entity = new farmStallDBEntities())
            {
                var filteredProducts = Entity.FarmerProducts
                    .Where(fp =>
                        (string.IsNullOrEmpty(farmerName) || fp.Farmer.farmer_name.Contains(farmerName)) &&
                        (string.IsNullOrEmpty(productType) || fp.Product.product_type == productType)
                    )
                    .Select(fp => new
                    {
                        FarmerName = fp.Farmer.farmer_name,
                        FarmerSurname = fp.Farmer.farmer_surname,
                        ProductCode = fp.Product.product_code,
                        ProductName = fp.Product.product_name,
                        ProductType = fp.Product.product_type,
                        Price = fp.Product.product_price,
                        Quantity = fp.Product.product_quantity,
                        Date = fp.Product.product_dateAdded
                    })
                    .ToList();

                gridView.DataSource = filteredProducts;
                gridView.DataBind();
            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to retrieve and populate Product Types into dropdown list
        /// </summary>
        /// <param name="dropdown"></param>
        public void PopulateProductTypeDropdown(DropDownList dropdown)
        {
            using (this.Entity = new farmStallDBEntities())
            {
                List<string> productTypes = Entity.FarmerProducts
                    .Select(fp => fp.Product.product_type)
                    .Distinct()
                    .ToList();
                for (int i = 0; i < productTypes.Count; i++)
                {
                    dropdown.Items.Add(productTypes[i]);
                }
            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to populate the gridview with all products
        /// </summary>
        /// <param name="gridView"></param>
            public void PopulateProductGridView(GridView gridView)  // (ChatGpt, 2023)
        {
                using (this.Entity = new farmStallDBEntities())
                {
                    var products = Entity.FarmerProducts
                        .Select(fp => new
                        {
                            FarmerName = fp.Farmer.farmer_name,
                            FarmerSurname = fp.Farmer.farmer_surname,
                            ProductCode = fp.Product.product_code,
                            ProductName = fp.Product.product_name,
                            ProductType = fp.Product.product_type,
                            Price = fp.Product.product_price,
                            Quantity = fp.Product.product_quantity,
                            Date = fp.Product.product_dateAdded
                        })
                        .ToList();

                    gridView.DataSource = products;
                    gridView.DataBind();
                }
            }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to get farmers' cell number
        /// </summary>
        /// <param name="dropDownList"></param>
        /// <returns></returns>
        public string GetFarmerCellNumberBySelectedName(DropDownList dropDownList)
        {
            string selectedFarmerName = dropDownList.SelectedValue;

            using (this.Entity = new farmStallDBEntities())
            {
                var farmer = Entity.Farmers.FirstOrDefault(f => f.farmer_name == selectedFarmerName);

                if (farmer != null)
                {
                    return farmer.farmer_cell;
                }
            }

            return string.Empty; // Return an empty string if the farmer's cell phone number is not found
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to filter grid view by farmer name
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="farmerCell"></param>
        public void FilterProductGridViewByFarmer(GridView gridView, string farmerCell) // (ChatGpt, 2023)
        {
            using (this.Entity = new farmStallDBEntities())
            {
                var products = Entity.FarmerProducts
                    .Where(fp => fp.farmer_cell == farmerCell)
                    .Select(fp => new
                    {
                        FarmerName = fp.Farmer.farmer_name,
                        FarmerSurname = fp.Farmer.farmer_surname,
                        ProductCode = fp.Product.product_code,
                        ProductName = fp.Product.product_name,
                        ProductType = fp.Product.product_type,
                        Price = fp.Product.product_price,
                        Quantity = fp.Product.product_quantity,
                        Date = fp.Product.product_dateAdded
                    })
                    .ToList();

                gridView.DataSource = products;
                gridView.DataBind();
            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to filter the gridview by product type
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="productType"></param>
        public void FilterGridViewByProductType(GridView gridView, string productType)
        {
            using (this.Entity = new farmStallDBEntities())
            {
                var filteredProducts = Entity.FarmerProducts
                    .Where(fp => fp.Product.product_type == productType)
                    .Include(fp => fp.Product)
                    .Include(fp => fp.Farmer)
                    .Select(fp => new
                    {
                        FarmerName = fp.Farmer.farmer_name,
                        FarmerSurname = fp.Farmer.farmer_surname,
                        ProductCode = fp.Product.product_code,
                        ProductName = fp.Product.product_name,
                        ProductType = fp.Product.product_type,
                        Price = fp.Product.product_price,
                        Quantity = fp.Product.product_quantity,
                        Date = fp.Product.product_dateAdded
                    })
                    .ToList();

                gridView.DataSource = filteredProducts;
                gridView.DataBind();
            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to filter the gridview by a start and end date
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public void FilterGridViewByDate(GridView gridView, DateTime startDate, DateTime endDate)
        {
            using (this.Entity = new farmStallDBEntities())
            {
                var filteredProducts = Entity.FarmerProducts
                    .Where(fp => fp.Product.product_dateAdded >= startDate && fp.Product.product_dateAdded <= endDate)
                    .Include(fp => fp.Product)
                    .Include(fp => fp.Farmer)
                    .Select(fp => new
                    {
                        FarmerName = fp.Farmer.farmer_name,
                        FarmerSurname = fp.Farmer.farmer_surname,
                        ProductCode = fp.Product.product_code,
                        ProductName = fp.Product.product_name,
                        ProductType = fp.Product.product_type,
                        Price = fp.Product.product_price,
                        Quantity = fp.Product.product_quantity,
                        Date = fp.Product.product_dateAdded
                    })
                    .ToList();

                gridView.DataSource = filteredProducts;
                gridView.DataBind();
            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to filter gridView
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="farmerName"></param>
        /// <param name="productType"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public void FilterGridView(GridView gridView, string farmerName, string productType, DateTime startDate, DateTime endDate)
        {
            using (this.Entity = new farmStallDBEntities())
            {
                var filteredProducts = Entity.FarmerProducts
                    .Where(fp =>
                        (string.IsNullOrEmpty(farmerName) || fp.Farmer.farmer_name.Contains(farmerName)) &&
                        (string.IsNullOrEmpty(productType) || fp.Product.product_type == productType) &&
                        (fp.Product.product_dateAdded >= startDate && fp.Product.product_dateAdded <= endDate)
                    )
                    .Include(fp => fp.Product)
                    .Include(fp => fp.Farmer)
                    .Select(fp => new
                    {
                        FarmerName = fp.Farmer.farmer_name,
                        FarmerSurname = fp.Farmer.farmer_surname,
                        ProductCode = fp.Product.product_code,
                        ProductName = fp.Product.product_name,
                        ProductType = fp.Product.product_type,
                        Price = fp.Product.product_price,
                        Quantity = fp.Product.product_quantity,
                        Date = fp.Product.product_dateAdded
                    })
                    .ToList();

                gridView.DataSource = filteredProducts;
                gridView.DataBind();
            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to filter gridview by farmer name, and date range
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="farmerName"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public void FilterGridViewByFarmerAndDate(GridView gridView, string farmerName, DateTime startDate, DateTime endDate)
        {
            using (this.Entity = new farmStallDBEntities())
            {
                var filteredProducts = Entity.FarmerProducts
                    .Where(fp => fp.Farmer.farmer_name == farmerName &&
                                  fp.Product.product_dateAdded >= startDate &&
                                  fp.Product.product_dateAdded <= endDate)
                    .Include(fp => fp.Product)
                    .Include(fp => fp.Farmer)
                    .Select(fp => new
                    {
                        FarmerName = fp.Farmer.farmer_name,
                        FarmerSurname = fp.Farmer.farmer_surname,
                        ProductCode = fp.Product.product_code,
                        ProductName = fp.Product.product_name,
                        ProductType = fp.Product.product_type,
                        Price = fp.Product.product_price,
                        Quantity = fp.Product.product_quantity,
                        Date = fp.Product.product_dateAdded
                    })
                    .ToList<object>();

                gridView.DataSource = filteredProducts;
                gridView.DataBind();
            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to Add Login Credentials of new Farmer
        /// </summary>
        /// <param name="lc"></param>
        public void AddLoginCreds(Login_Credentials lc)
        {
            try
            {
                using (this.Entity = new farmStallDBEntities())
                {
                    Entity.Login_Credentials.Add(lc);
                    Entity.SaveChanges();   
                }
            }
            catch (Exception)
            {
                
            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     EF Method to Add a new Farmer to DB
        /// </summary>
        /// <param name="newFarmer"></param>
        public void AddFarmer(Farmer newFarmer)
        {
            try
            {
                using (this.Entity = new farmStallDBEntities())
                {
                    Entity.Farmers.Add(newFarmer);
                    Entity.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }
        // ----------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Method to ensure username is unique
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsUsernameUnique(string username)
        {
            using (this.Entity = new farmStallDBEntities())
            {
                // Check if there is any user with the given username
                bool isUnique = !Entity.Login_Credentials.Any(u => u.user_username == username);

                return isUnique;
            }
        }
    }
}
// --------------------------------- .....ooooo00000 END OF FILE 00000ooooo..... --------------------------------- //