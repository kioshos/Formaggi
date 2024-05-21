using Formaggi.Model;
using Microsoft.Data.SqlClient;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Controls;

namespace Formaggi.Services
{
    class StorageContext : DatabaseConnection
    {
        private List<Model.Batch> _batches;

        public List<Model.Batch> Batch
        {
            get
            {
                return _batches;
            }
        }
        public StorageContext() : base()
        {
            _batches = null;
        }

        public void AddCheeseToBatch(decimal cheeseQuantity, DateTime cheeseProduction, DateTime cheeseAging, DateTime cheeseExpiration, decimal cheesePrice)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string addUserQuery = "INSERT INTO CheeseStorage ( cheese_Quantity, cheese_Production, cheese_AgingComplete, cheese_Expiration, cheese_Price) VALUES ( @cheeseQuantity, @cheeseProduction, @cheeseAgingComplete, @cheeseExpiration, @cheesePrice);";
                    SqlParameter dateParam = new SqlParameter("@cheeseProduction", SqlDbType.DateTime);
         
                    SqlCommand addUserCMD = new SqlCommand(addUserQuery, connection);
                    addUserCMD.Parameters.AddWithValue("@cheeseQuantity", cheeseQuantity);
                    addUserCMD.Parameters.AddWithValue("@cheeseProduction", cheeseProduction);
                    addUserCMD.Parameters.AddWithValue("@cheeseAgingComplete", cheeseAging);
                    addUserCMD.Parameters.AddWithValue("@cheeseExpiration", cheeseExpiration);
                    addUserCMD.Parameters.AddWithValue("@cheesePrice", cheesePrice);

                    addUserCMD.ExecuteNonQuery();


                }
                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public List<Batch> GetCheeseBatchById(int cheese_id)
        {
            List<Batch> batchCheeseList = new List<Batch>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM CheeseStorage WHERE cheese_id = @cheeseID";

                    SqlCommand getBatchById = new SqlCommand(query, connection);

                    getBatchById.Parameters.AddWithValue("@cheeseID", cheese_id);

                    using (SqlDataReader reader = getBatchById.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            batchCheeseList.Add(new Batch
                            {
                                Id = Convert.ToInt32(reader["cheeseStorage_ID"]),
                                CheeseID = Convert.ToInt32(reader["cheese_id"]),
                                Quantity = (decimal)reader["cheese_Quantity"],
                                Price = (decimal)reader["cheese_Price"]
                            });
                        }
                    }
                }

                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return batchCheeseList;
        }
    }
}
