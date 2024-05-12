using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formaggi.Model
{
    public class User
    {
      

        public static int ID { get; private set; }
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
