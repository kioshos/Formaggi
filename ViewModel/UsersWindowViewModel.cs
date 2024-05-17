using Formaggi.Model;
using Formaggi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Formaggi.ViewModel
{
    public class UsersWindowViewModel : ViewModelBase
    {
        private List<Model.Cheese> _basket;
        private CheeseContext _cheeseContext;
        private OrderContext _orderContext;
        private Order _order;
        private int _orderNumber;
        public List<Cheese> Basket { get => _basket; set => _basket = value; }

        public ICommand ToOrderCommand { get; private set; }
        public ICommand SetCheeseCommand { get; private set; }
        public ICommand SetCheeseCountCommand { get; private set; }
        public int OrderNumber { get => _orderNumber; set => _orderNumber = value; }

        private readonly ISession _session;

        public UsersWindowViewModel()
        {   
            _basket = new List<Model.Cheese>();
            _cheeseContext = new CheeseContext();
            _orderContext = new OrderContext();
            SetCheeseCommand = new RelayCommand<object>(SetCheese,null);
            ToOrderCommand = new RelayCommand<object>(ToOrder,null);
            _session = Singleton.GetInstance().CurrentSession;
            SetCheeseCountCommand = new RelayCommand<object>(SetCount, null);
        }

        
        private void SetCheese(object parameter)
        {
            int param = Convert.ToInt32((string)parameter);
            _basket.Add(_cheeseContext.GetCheeseById(param));
            Window numCheese = new View.CountOfCheese();
            numCheese.Show();
            
        }
        private void SetCount(object parameter)
        {
           

        }
        private void ToOrder(object parameter)
        {
            int userId = _session.User.ID;         
            DateTime orderDate = DateTime.Now;
            bool orderStatus = false; 
            int orderNumber = OrderNumber;

            foreach (var cheese in _basket)
            {
                _orderContext.ToOrder(cheese.CheeseName, orderDate,orderNumber, orderStatus, userId);
            }

            // Clear the basket after ordering
            _basket.Clear();

            MessageBox.Show("Order placed successfully!");
        }

    }
}
