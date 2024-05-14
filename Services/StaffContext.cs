using Formaggi.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formaggi.Services
{
    public class StaffContext : DatabaseConnection
    {
        private List<Model.Staff> _staffs;

        public List<Staff> Staffs
        {
            get
            {
                return _staffs;
            }
        }
        public StaffContext() : base()
        {
            _staffs = null;
            GetUsers();

        }


        public void GetUsers()
        {
            List<Staff> staffs = new List<Staff>();


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM CheeseMaker";

                SqlCommand getUsersCommand = new SqlCommand(query, connection);

                using (SqlDataReader reader = getUsersCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        staffs.Add(new Staff
                        {
                            Name = reader["cheesePerson_Name"].ToString(),
                            Contact = reader["cheesePreson_Contact"].ToString(),
                            Address = reader["cheesePreson_Address"].ToString(),
                            Birth = Convert.ToDateTime(reader["cheesePerson_Birth"]),
                            Salary = Convert.ToDecimal(reader["cheesePerson_Salary"]),

                        });
                    }
                }
            }

            _staffs = staffs;
        }

    }
}
