using Formaggi.Model;
using Formaggi.Services;
using Formaggi.ViewModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Formaggi.View
{
    /// <summary>
    /// Interaction logic for StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {

        public StaffPage()
        {
            InitializeComponent();
            DataContext = new StaffViewModel();

        }

        private void AddStaff_Click(object sender, RoutedEventArgs e)
        {
            Window addStaff = new AddNewStaff();
            addStaff.Show();
        }

       




        ////private void AddStaff_Click(object sender, RoutedEventArgs e)
        ////{
        ////    AddNewStaff registration = new AddNewStaff();
        ////    registration.Show();
        ////}
    }
}
