using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProgPOE
{
    public partial class ViewProducts : System.Web.UI.Page
    {
        private List<ProductFarmerObject> prodList = new List<ProductFarmerObject>();
        private DBController dbController = new DBController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*// Retrieve data from the database (replace this with your own code)
                DataTable dataTable = GetDataFromDatabase();

                // Bind the data to the GridView
                gvProducts.DataSource = dataTable;
                gvProducts.DataBind();*/
                dbController.LoadData(prodList);

                gvProducts.DataSource = prodList;
                gvProducts.DataBind();

            }
        }

        private DataTable GetDataFromDatabase()
        {
            // Replace this method with your own logic to retrieve data from the database
            // Return the data as a DataTable
            DataTable dataTable = new DataTable();
            // Populate the DataTable with data
            // Example:
            dataTable.Columns.Add("ProductCode");
            dataTable.Columns.Add("ProductName");
            dataTable.Columns.Add("ProductType");
            dataTable.Columns.Add("Quantity");
            dataTable.Columns.Add("DateAdded");

            dataTable.Rows.Add("1", "John Doe", "john@example.com","wqd", "d2qwdqw");
            dataTable.Rows.Add("2", "Jane Smith", "jane@example.com","wedwed", "qwdwqd");
            return dataTable;
        }
    }
}