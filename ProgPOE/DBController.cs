using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProgPOE
{
    public class DBController
    {
        private string connectionString = Properties.Resources.connectionString;
        public void LoadData(List<ProductFarmerObject> empList)
        {

            // dataGridView1.Rows.Clear(); -- Do this when calling this method

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT F.farmer_name, F.farmer_surname, P.product_code, P.product_name, " +
                    "P.product_price, P.product_quantity, P.product_dateAdded FROM FarmerProduct FP, Product P, Farmer F WHERE FP.farmer_cell = F.farmer_cell AND FP.product_code = P.product_code", connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductFarmerObject myObj = new ProductFarmerObject(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), 
                            reader.GetValue(3).ToString(), double.Parse(reader.GetValue(4).ToString()), int.Parse(reader.GetValue(5).ToString()), 
                            DateTime.Parse(reader.GetValue(6).ToString()));
                        // dataGridView1.Rows.Add(reader["Id"], reader["Name"], reader["Age
                        empList.Add(myObj);
                    }
                }
            }
        }

        // ----------------------------------------------------------------------------------------------------------- //



        public void GetEmployeeUsername(List<string> empUsernames)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT user_username FROM Employee", connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       empUsernames.Add( reader.GetValue(0).ToString());
                    }
                }
            }
        }

        public void GetFarmerUsername(List<string> farmerUsernames)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT user_username FROM Farmer", connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        farmerUsernames.Add(reader.GetValue(0).ToString());
                    }
                }
            }
        }
    }
}