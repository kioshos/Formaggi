using Formaggi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Formaggi.ViewModel
{
    public class UsersWindowViewModel : ViewModelBase
    {
        private UsersContext _usersContext;
        private string _cheeseNameToOrder;
        private DateTime _createdDate;
        private bool _orderStatus;
        private int _orderCheeseNumber;

        public ICommand ToOrderCommand { get; private set; }
        public ICommand SetCheeseCommand { get; private set; }
        public string CheeseNameToOrder { get => _cheeseNameToOrder; set => _cheeseNameToOrder = value; }
        public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }
        public bool OrderStatus { get => _orderStatus; set => _orderStatus = value; }
        public int OrderCheeseNumber { get => _orderCheeseNumber; set => _orderCheeseNumber = value; }
        public UsersWindowViewModel()
        {
            CheeseNameToOrder = String.Empty;
            OrderCheeseNumber = 0;
            CreatedDate = DateTime.Now;
            OrderStatus = false;
            OrderCheeseNumber = 0;
            //SetCheeseCommand = new RelayCommand(SetCheeseName(),null);
        }
        private void SetCheeseName(string cheeseName)
        {
            CheeseNameToOrder = cheeseName;
        }

    }
}
