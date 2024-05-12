using Formaggi.ViewModel;
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
using System.Windows.Shapes;

namespace Formaggi.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registration = new RegistrationWindow();
            registration.Show();

        }

        //    private void Button_Click(object sender, RoutedEventArgs e)
        //    {
        //        MainWindow window = new MainWindow();


        //        if (textblocktest.Text == "iamadmin")
        //        {
        //            window.Show();
        //            window.test1.IsEnabled = false;
        //        }
        //        if (textblocktest.Text == "user")
        //        {
        //            window.Show();
        //            window.test2.IsEnabled = false;
        //        }
        //        this.Close();
        //    }
    }
}
