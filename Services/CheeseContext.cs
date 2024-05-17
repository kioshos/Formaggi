using Formaggi.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formaggi.Services
{
    public class CheeseContext : DatabaseConnection
    {
        private List<Model.Cheese> _cheeses;
        public List<Model.Cheese> Cheeses
        {
            get { return _cheeses; }
        }
        public CheeseContext()
        {
            _cheeses = null;
            GetCheeses();
        }

        public Cheese GetCheeseById(int id)
        {
            GetCheeses();
            return _cheeses.FirstOrDefault(c => c.ID == id);
        }
      
        private void GetCheeses()
        {
            List<Model.Cheese> cheeses = new List<Model.Cheese>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Cheese";

                SqlCommand getUsersCommand = new SqlCommand(query, connection);

                using (SqlDataReader reader = getUsersCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cheeses.Add(new Cheese
                        {
                            ID = Convert.ToInt32(reader["cheese_id"]),
                            CheeseName = reader["cheese_Name"].ToString(),
                            AgingPeriod = reader["cheese_AgingPeriod"].ToString(),
                            Texture = reader["cheese_Texture"].ToString(),
                            Description =reader["cheese_Description"].ToString(),
                            maker_id = Convert.ToInt32(reader["maker_id"]),

                        });
                    }
                }
            }

            _cheeses = cheeses;
        }
    }
}
