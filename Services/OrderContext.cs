using Formaggi.Model;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Formaggi.Services
{
    public class OrderContext : DatabaseConnection
    {
        private List<Model.Order> _orders;
        public List<Order> Orders 
        {
            get
            {
                return _orders;
            }
        }
        public OrderContext() : base() 
        {
            _orders = null;
            GetOrder();
        }

        private void GetOrder()
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM CheeseOrder";

                SqlCommand getUsersCommand = new SqlCommand(query, connection);

                using (SqlDataReader reader = getUsersCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new Order
                        {
                            OrderCheeseName = reader["Cheese_Name"].ToString(),
                            OrderDate = Convert.ToDateTime(reader["Order_Date"]),
                            OrderNumber = Convert.ToInt32(reader["Order_Number"]),
                            OrderStatus = Convert.ToBoolean(reader["Order_Status"]),
                            UsersId = Convert.ToInt32(reader["users_id"])
                        });
                    }
                }
            }

            _orders = orders;
        }

        public void ToOrder(Order order)
        {
            
            
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    string addUserQuery = "INSERT INTO CheeseOrder (Cheese_Name, Order_Date, Order_Number, Order_Status, Order_Price, users_id) VALUES (@cheeseName, @orderDate, @orderNumber, @orderStatus, @orderPrice, @userid);";
                    SqlParameter dateParam = new SqlParameter("@date", SqlDbType.DateTime);
                    dateParam.Value = order.OrderDate;
                    SqlCommand addUserCMD = new SqlCommand(addUserQuery, connection);
                    addUserCMD.Parameters.AddWithValue("@cheeseName", order.OrderCheeseName);
                    addUserCMD.Parameters.AddWithValue("@orderDate", order.OrderDate);
                    addUserCMD.Parameters.AddWithValue("@orderNumber", order.OrderNumber);
                    addUserCMD.Parameters.AddWithValue("@orderStatus", order.OrderStatus);
                    addUserCMD.Parameters.AddWithValue("@orderPrice", order.OrderPrice);
                    addUserCMD.Parameters.AddWithValue("@userid", order.UsersId);

                    addUserCMD.ExecuteNonQuery();


                }
                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        ///TODO
        //public Order IsOrderExist(string orderCheeseName, string usersName)
        //{
        //    using (var context = new YourDbContext())
        //    {
        //        var order = context.Orders
        //            .Include(o => o.User)
        //            .FirstOrDefault(o => o.OrderCheeseName == orderCheeseName && o.User.UserName == usersName);

        //        return order;
        //    }
        //}
    }
}
