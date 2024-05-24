using Formaggi.Model;
using Formaggi.Services;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Formaggi.ViewModel
{
    public  class StaffViewModel : ViewModelBase
    {
        private Services.StaffContext _staffContext;
        private ObservableCollection<Staff> _staffs;
        private Staff _selectedStaff;
        private string _staffName;
        private string _staffContact;
        private string _staffAddress;
        private DateTime _staffBirth;
        private decimal _staffSalary;

        public ICommand AddNewStaffCommand { get; private set; }
        public ICommand RemoveStaffCommand { get; private set; }
        public ICommand OpenAddStaffCommand { get; private set; }
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
            StaffBirth = DateTime.Now;
            StaffSalary = 0;
            _staffContext = new Services.StaffContext();
            _staffs = new ObservableCollection<Staff>(_staffContext.GetUsers()) ;
            AddNewStaffCommand = new RelayCommand<object>(AddStaff,null);
            RemoveStaffCommand = new RelayCommand<object>(RemoveStaff,null);
            OpenAddStaffCommand = new RelayCommand<object>(OpenAddStaff,null);
        }

        private void AddStaff(object obj) => _staffContext.AddStaff(StaffName,StaffContact,StaffAddress,StaffBirth,StaffSalary);

        private void OpenAddStaff(object obj)
        {
            Window add = new View.AddNewStaff();
            add.Show();
        }
        public ObservableCollection<Staff> Staffs
        {
            get => _staffs;
            set
            {
                _staffs = value;
                OnPropertyChanged(nameof(Staffs));
            }
        }
        public Staff SelectedStaff
        {
            get => _selectedStaff;
            set
            {
                _selectedStaff = value;
                OnPropertyChanged(nameof(SelectedStaff));
            }
        }

        private void RemoveStaff(object parameter)
        {
            if (SelectedStaff != null)
            {
                bool success = _staffContext.RemoveUser(SelectedStaff.ID);
                if (success)
                {
                    MessageBox.Show("Staff member removed successfully.");
                    _staffContext.GetUsers();
                    OnPropertyChanged(nameof(Staffs)); 
                }
                else
                {
                    MessageBox.Show("Failed to remove staff member.");
                }
            }
            else
            {
                MessageBox.Show("No staff member selected.");
            }
        }

      
       
    }
}
