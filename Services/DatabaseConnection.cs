using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Formaggi.Services
{
    public abstract class DatabaseConnection
    {
        protected readonly string _connectionString = "Data Source=CALIFORNIA;Initial Catalog=Formaggi;" +
            "Integrated Security=True;Persist Security Info=False;Pooling=False;" +
            "Multiple Active Result Sets=False;Encrypt=True;" +
            "Trust Server Certificate=True;Command Timeout=0;";
        protected DatabaseConnection()
        {
            
        }
    }
}
