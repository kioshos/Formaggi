using Formaggi.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace Formaggi.Model
{
    public class User
    {
      

        public int ID { get; set; }
        public string Name { get; set; }
        public int role { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public User()
        {
            ID = ID++;
            Login = String.Empty;
            role = 0;
            Password = String.Empty;
            Name = String.Empty;
            Email = String.Empty;
            Address = String.Empty;
        }
       
    }
}
