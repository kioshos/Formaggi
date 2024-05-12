using Formaggi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Formaggi.ViewModel
{
    class RegistrationViewModel : ViewModelBase
    {
        #region Private Fields
        private Services.UsersContext _usersContext;
        private string _name;
        private string _login;
        private string _password;
        private int _role_id;
        private string _role_name;
        private string _email;
        private string _address;
        #endregion

        public ICommand RegistrateCommand { get; private set; }

        #region Public Fields
        public string Name { get => _name; set => _name = value; }
        public string Login { get => _login; set => _login = value; }
        public string Password { get => _password; set => _password = value; }
        public int Role_id { get => _role_id; set => _role_id = value; }
        public string Role_name { get => _role_name; set => _role_name = value; }
        public string Email { get => _email; set => _email = value; }
        public string Address { get => _address; set => _address = value; }
        #endregion
        public RegistrationViewModel()
        {
            Name = string.Empty;
            Login = string.Empty;
            Password = string.Empty;
            Role_id = 0;
            Role_name = "Customer";
            Email = string.Empty;
            Address = string.Empty;
            _usersContext= new Services.UsersContext();
            RegistrateCommand = new RelayCommand(Registration,null);
            
        }
  
         private void Registration() => _usersContext.RegistrateUser(Name, Email, Address, Login, Password);
    }
}
