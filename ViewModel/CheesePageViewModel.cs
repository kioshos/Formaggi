using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Formaggi.ViewModel
{
    class CheesePageViewModel : ViewModelBase
    {
        public ICommand SetCheeseCommand { get; private set; }

        public CheesePageViewModel()
        {
            SetCheeseCommand = new RelayCommand<object>(BatchWindowShow, null);
        }

        private void BatchWindowShow(object parameter)
        {
            int cheese_id = Convert.ToInt32(parameter);

            Window window = new CheeseBatchWindow(cheese_id);

            window.Show();
        }
    }
}
