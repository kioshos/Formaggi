using Formaggi.Model;
using Microsoft.Data.SqlClient;
using System.Windows;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Formaggi.Services
{
    public class IngredientContext : DatabaseConnection
    {
        private List<Model.Ingredient> _ingredients;
        public List<Model.Ingredient> Ingredients
        {
            get
            {
                return _ingredients;
            }
        }
        public IngredientContext()
        {
            _ingredients = null;
            GetIngredients();
        }

        private void GetIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Ingredient";

                SqlCommand getUsersCommand = new SqlCommand(query, connection);

                using (SqlDataReader reader = getUsersCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ingredients.Add(new Ingredient
                        {
                            IngredientName = reader["ingredient_Name"].ToString(),
                            Quantity = Convert.ToInt32(reader["ingredient_Quantity"]),
                            ExpireDate = Convert.ToDateTime(reader["ingredient_Quantity"]),
                            PurchaseDate = Convert.ToDateTime(reader["ingredient_Purchare"]),
                            Price = Convert.ToDecimal(reader["ingredient_Price"]),

                        });
                    }
                }
            }

            _ingredients = ingredients;
        }
        public void UpdateIngredientQuantity(int quantity, string name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string updateIngredientQuery = "UPDATE Ingredient " +
                                                   "SET ingredient_Quantity = @quantity " +
                                                   "WHERE ingredient_Name = @name";
                    SqlCommand updateCommand = new SqlCommand(updateIngredientQuery, connection);
                    updateCommand.Parameters.AddWithValue("@quantity", quantity);
                    updateCommand.Parameters.AddWithValue("@name", name);

                    updateCommand.ExecuteNonQuery();


                }
                MessageBox.Show("Success!");
            }
            catch
            (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
