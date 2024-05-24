using Formaggi.Model;
using Formaggi.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Formaggi.ViewModel
{
    public class OrderPageViewModel : ViewModelBase
    {
        private OrderContext _orderContext;

        private ObservableCollection<Order> _orders;
        private Order _selectedOrder;

        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }

        public ICommand CloseOrderCommand { get; private set; }

        public OrderPageViewModel()
        {
            _orderContext = new OrderContext();

            _orders = new ObservableCollection<Order>(_orderContext.Orders);

            CloseOrderCommand = new RelayCommand<object>(CloseOrder, null);
        }

        private void CloseOrder(object parameter)
        {
            if (SelectedOrder != null)
            {
                SelectedOrder.OrderStatus = true;
                _orderContext.UpdateOrderStatus(SelectedOrder.OrderID, true);
                RefreshOrders();
            }
        }

        private void RefreshOrders()
        {
            Orders = new ObservableCollection<Order>(_orderContext.Orders);
        }
    }
}
