using Formaggi.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Formaggi.Services
{
    public class UsersContext : DatabaseConnection
    {
        private List<Model.User> _users;

        public List<User> Users
        {
            get
            {
                return _users;
            }
        }
        public UsersContext() : base()
        {
            _users = null;
            GetUsers();

        }
       
        public void RegistrateUser(string name, string email, string address, string login, string password)
        {
         

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string addUserQuery = "INSERT INTO Users(Users_Name, Users_Contact, Users_Address ,ULogin, UPassword, role_id) VALUES (@name, @email, @address,  @login, @password, 3)";
                    SqlCommand addUserCMD = new SqlCommand(addUserQuery, connection);
                    addUserCMD.Parameters.AddWithValue("@login", login);
                    addUserCMD.Parameters.AddWithValue("@password", password);
                    addUserCMD.Parameters.AddWithValue("@name", name);
                    addUserCMD.Parameters.AddWithValue("@address", address);
                    addUserCMD.Parameters.AddWithValue("@email", email);

                    addUserCMD.ExecuteNonQuery();


                }
                MessageBox.Show("Success!");
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
            

        }
        private void GetUsers()
        {
            List<User> users = new List<User>();
            

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Users";

                SqlCommand getUsersCommand = new SqlCommand(query, connection);

                using (SqlDataReader reader = getUsersCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Name = reader["Users_Name"].ToString(),
                            Address = reader["Users_Address"].ToString(),
                            Login = reader["ULogin"].ToString().Trim(),
                            Password = reader["UPassword"].ToString().Trim(),
                            Email = reader["Users_Contact"].ToString(),
                            role = Convert.ToInt32(reader["role_id"]),
                           
                        });
                    }
                }
            }

            _users = users;
        }
        public User IsClientExist(string login, string password)
        {
           
            GetUsers();
            return _users.FirstOrDefault(c => (c.Login == login && c.Password == password)); 
        }
    }
}
