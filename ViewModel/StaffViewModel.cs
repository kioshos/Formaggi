using Formaggi.Model;
using Formaggi.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Formaggi.ViewModel
{
    public  class StaffViewModel : DatabaseConnection
    {
        private List<Model.Staff> _staffs;

        public List<Staff> Staffs
        {
            get
            {
                return _staffs;
            }
        }
        private string _staffName;
        private string _staffContact;
        private string _staffAddress;
        private DateTime _staffBirth;
        private decimal _staffSalary;

        public ICommand AddNewStaffCommand { get; private set; }
        public string StaffName { get => _staffName; set => _staffName = value; }
        public string StaffContact { get => _staffContact; set => _staffContact = value; }
        public string StaffAddress { get => _staffAddress; set => _staffAddress = value; }
        public DateTime StaffBirth { get => _staffBirth; set => _staffBirth = value; }
        public decimal StaffSalary { get => _staffSalary; set => _staffSalary = value; }
        public StaffViewModel() : base()
        {
            StaffName = String.Empty;
            StaffContact = String.Empty;
            StaffAddress = String.Empty;
            StaffBirth = DateTime.MinValue;
            StaffSalary = 0;
            _staffs = null;
            GetUsers();
            //_staffContext = new Services.StaffContext();
            AddNewStaffCommand = new RelayCommand(AddStaff,null);
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
        private void AddStaff()
        {
            throw new NotImplementedException();
        }
    }
}
