using Formaggi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Formaggi
{
    /// <summary>
    /// Interaction logic for CheeseBatchWindow.xaml
    /// </summary>
    public partial class CheeseBatchWindow : Window
    {
        public CheeseBatchWindow(int cheeseID)
        {
            InitializeComponent();
            DataContext = new ViewModel.BatchWindowViewModel(cheeseID);
        }
    }
}
