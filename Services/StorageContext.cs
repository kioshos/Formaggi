using Formaggi.Model;
using Microsoft.Data.SqlClient;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formaggi.Services
{
    class StorageContext : DatabaseConnection
    {
        public StorageContext() : base()
        {

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
                                Weight = (decimal)reader["cheese_WeightKG"],
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
