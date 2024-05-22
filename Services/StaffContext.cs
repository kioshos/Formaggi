using Formaggi.Model;
using Formaggi.View;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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


        public List<Staff> GetUsers()
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
                            ID = Convert.ToInt32(reader["cheesePerson_id"]),
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
            return staffs;
        }
        public bool RemoveUser(int userid)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string deleteUserQuery = "DELETE FROM CheeseMaker WHERE cheesePerson_id = @id";
                    SqlCommand deleteUserCommand = new SqlCommand(deleteUserQuery, connection);
                    deleteUserCommand.Parameters.AddWithValue("@id", userid);

                    int rowsAffected = deleteUserCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public void AddStaff(string StaffName, string StaffContact, string StaffAddress, DateTime StaffBirth, decimal StaffSalary)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string addUserQuery = "INSERT INTO CheeseMaker (cheesePerson_Name, cheesePreson_Contact, cheesePreson_Address, cheesePerson_Birth, cheesePerson_Salary)  VALUES (@name, @contact, @address,  @birth, @salary)";
                    SqlCommand addUserCMD = new SqlCommand(addUserQuery, connection);
                    addUserCMD.Parameters.AddWithValue("@name", StaffName);
                    addUserCMD.Parameters.AddWithValue("@contact", StaffContact);
                    addUserCMD.Parameters.AddWithValue("@address", StaffAddress);
                    addUserCMD.Parameters.AddWithValue("@birth", StaffBirth);
                    addUserCMD.Parameters.AddWithValue("@salary", StaffSalary);

                    addUserCMD.ExecuteNonQuery();


                }
                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
