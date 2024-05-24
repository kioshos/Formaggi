using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Formaggi.ViewModel
{
    public class StaffWindowViewModel : ViewModelBase
    {
        private Services.StorageContext _storageContext;
        private Services.CheeseContext _cheeseContext;

        private decimal _quantity;
        private DateTime _productionDate;
        private DateTime _agingComplete;
        private DateTime _expirationDate;
        private decimal _price;
        private List<string> _cheeses;
        private int _cheeseID;
        public ICommand AddCheeseToBatchCommand { get; private set; }
        public decimal Quantity { get => _quantity; set => _quantity = value; }
        public DateTime ProductionDate { get => _productionDate; set => _productionDate = value; }
        public DateTime AgingComplete { get => _agingComplete; set => _agingComplete = value; }
        public DateTime ExpirationDate { get => _expirationDate; set => _expirationDate = value; }
        public decimal Price { get => _price; set => _price = value; }
        public int CheeseID { get => _cheeseID; set => _cheeseID = value; }

        public List<string> Cheeses
        {
            get => _cheeses;
            private set => _cheeses = value;
        }

        public StaffWindowViewModel()
        {
            Quantity = 0;
            ProductionDate = DateTime.Now;
            AgingComplete = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Price = 0;
            _cheeseID = 0;
            _storageContext = new Services.StorageContext();
            _cheeseContext = new Services.CheeseContext();

            _cheeses = _cheeseContext.GetCheesesName();

            AddCheeseToBatchCommand = new RelayCommand<object>(AddCheeseToBatch, null);
        }

        private void AddCheeseToBatch(object obj) => _storageContext.AddCheeseToBatch(CheeseID + 2,Quantity, ProductionDate, AgingComplete, ExpirationDate, Price);


    }
}
