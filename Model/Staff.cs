using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formaggi.Model
{
    public class Staff
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Contact {  get; set; }
        public string Address {  get; set; }
        public DateTime Birth {  get; set; }
        public decimal Salary {  get; set; }

        public Staff()
        {
            ID = ID++;
            Name = String.Empty;
            Contact = String.Empty;
            Address = String.Empty;
            Birth = new DateTime();
            Salary = new decimal();

        }
    }
}
