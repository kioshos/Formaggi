using Formaggi.Model;
using Formaggi.Services;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Formaggi.ViewModel
{
    public  class StaffViewModel : DatabaseConnection
    {
        private Services.StaffContext _staffContext;
        private string _staffName;
        private string _staffContact;
        private string _staffAddress;
        private DateTime _staffBirth;
        private decimal _staffSalary;

        public ICommand AddNewStaffCommand { get; private set; }
        public ICommand RemoveStaffCommand { get; private set; }
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
            _staffContext = new Services.StaffContext();
            AddNewStaffCommand = new RelayCommand(AddStaff,null);
            RemoveStaffCommand = new RelayCommand(RemoveStaff,null);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void RemoveStaff()
        {
            throw new NotImplementedException();
        }

        private void AddStaff()
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
