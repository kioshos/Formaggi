using Formaggi.Model;
using Formaggi.Services;
using Formaggi.View;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Formaggi.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private UsersContext _usersContext;
        private string _username;
        private string _password;

        public ICommand LoginCommand { get; private set; }
        public ICommand openRegistrationWindowCommand { get; private set; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }

        public LoginViewModel()
        {
            _username = string.Empty;
            _password = string.Empty;
            _usersContext = new UsersContext();
            LoginCommand = new RelayCommand<object>(Login, null);
            openRegistrationWindowCommand = new RelayCommand<object>(OpenRegistrateWindow, null);
            
        }

        private void Login(object parameter)
        {
            User currentUser = _usersContext.IsClientExist(Username, Password);
            Singleton.Initialize(currentUser);
            try
            {
                int role = currentUser.role;
                if (currentUser != null)
                {
                    Window result = null;
                    switch (role)
                    {
                        case 1:
                            result = new AdministrationWindow();
                            break;
                        case 2:
                            result = new ManagerWindow();
                            break;
                        case 3:
                            result = new UsersWindow();
                            break;
                        case 4:

                            result = new StaffWindow();
                            break;

                    }

                    result.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops, something went wrong." + ex.ToString());
            }
        }
        private void OpenRegistrateWindow(object parameter)
        {
            Window reg = new RegistrationWindow();
            reg.Show();
        }
    }

}
/*
 User currentUser = _usersContext.IsClientExist(Username, Password);
            UsersWindow usersWindow = new UsersWindow();
            if (currentUser != null && currentUser.role == 3)
            {
                usersWindow.Show();
            }
            else
            {
                MessageBox.Show("Incorrect data! ");
            }
 */