using Formaggi.Model;
using Formaggi.ViewModel;
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
using static System.Net.Mime.MediaTypeNames;

namespace Formaggi.View
{
    /// <summary>
    /// Interaction logic for CountOfCheese.xaml
    /// </summary>
    public partial class CountOfCheese : Window
    {
        public int Count { get; set; }

        public CountOfCheese()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Count = Convert.ToInt32(test.Text);
            DialogResult = true;
        }
    }
}
