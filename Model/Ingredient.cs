using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formaggi.Model
{
    class Ingredient
    {
        public int ID { get; set; }
        public int SupplierID { get; set; }
        public string IngredientName { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Ingredient()
        {
            ID = ID++;
            SupplierID = 0;
            IngredientName = String.Empty;
            Quantity = 0;
            Price = 0;
            PurchaseDate = DateTime.MinValue;
            ExpireDate = DateTime.MinValue;
        }
    }
}
