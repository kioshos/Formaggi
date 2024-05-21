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
        private decimal _quantity;
        private DateTime _productionDate;
        private DateTime _agingComplete;
        private DateTime _expirationDate;
        private decimal _price;
        public ICommand AddCheeseToBatchCommand { get; private set; }
        public decimal Quantity { get => _quantity; set => _quantity = value; }
        public DateTime ProductionDate { get => _productionDate; set => _productionDate = value; }
        public DateTime AgingComplete { get => _agingComplete; set => _agingComplete = value; }
        public DateTime ExpirationDate { get => _expirationDate; set => _expirationDate = value; }
        public decimal Price { get => _price; set => _price = value; }
        public StaffWindowViewModel()
        {
            Quantity = 0;
            ProductionDate = DateTime.MinValue;
            AgingComplete = DateTime.MinValue;
            ExpirationDate = DateTime.MinValue;
            Price = 0;
            _storageContext = new Services.StorageContext();
            AddCheeseToBatchCommand = new RelayCommand<object>(AddCheeseToBatch,null);
        }

        private void AddCheeseToBatch(object obj) => _storageContext.AddCheeseToBatch(Quantity,ProductionDate,AgingComplete,ExpirationDate,Price);
        
           
    }
}
