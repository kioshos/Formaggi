using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formaggi.Model
{
  public class Batch
    {
        public int Id { get; set; }
        public int CheeseID { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        public Batch()
        {
            Id = 0;
            CheeseID = 0;
            Quantity = 0;
            Price = 0;
        }
    }
}
