using Formaggi.Model;
using Formaggi.Services;
using Formaggi.View;
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
        private List<Model.Order> _basket;
        private CheeseContext _cheeseContext;
        private OrderContext _orderContext;
        private Order _order;
    
        public List<Order> Basket { get => _basket; set => _basket = value; }

        public ICommand ToOrderCommand { get; private set; }
        public ICommand SetCheeseCommand { get; private set; }
        public ICommand SetCheeseCountCommand { get; private set; }


        private readonly ISession _session;

        public UsersWindowViewModel()
        {   
            _basket = new List<Model.Order>();
            _cheeseContext = new CheeseContext();
            _orderContext = new OrderContext();
            SetCheeseCommand = new RelayCommand<object>(SetCheese,null);
            ToOrderCommand = new RelayCommand<object>(ToOrder,null);
            _session = Singleton.GetInstance().CurrentSession;
            SetCheeseCountCommand = new RelayCommand<object>(SetCheese, null);
        }

        
        private void SetCheese(object parameter)
        {
            int param = Convert.ToInt32((string)parameter);
            Cheese cheese = _cheeseContext.GetCheeseById(param);
            Order newOrder = new Order();
            newOrder.OrderCheeseName = cheese.CheeseName;
            newOrder.UsersId = _session.User.ID;
            newOrder.OrderDate = DateTime.Now;
           
            var orderForm = new CountOfCheese();
            if (orderForm.ShowDialog() == true)
            {
                newOrder.OrderNumber = orderForm.Count;
            }
             _basket.Add(newOrder);
        }
       /*
            _basket.Add(_cheeseContext.GetCheeseById(param));*/
        private void ToOrder(object parameter)
        {


            foreach (var order in _basket)
            {
                _orderContext.ToOrder(order);
            }

            // Clear the basket after ordering
            _basket.Clear();

            MessageBox.Show("Order placed successfully!");
        }

    }
}
