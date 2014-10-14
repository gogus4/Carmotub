using Carmotub.Model;
using Carmotub.ViewModel;
using Carmotub.Views.Controls;
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

namespace Carmotub.Views
{
    public partial class PrintCustomers : Window
    {
        private static PrintCustomers _instance = null;
        public static PrintCustomers Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PrintCustomers();
                return _instance;
            }
        }

        public PrintCustomers()
        {
            InitializeComponent();
            _instance = this;
        }

        private async void ListCustomers_Initialized(object sender, EventArgs e)
        {
            var Customers = await CustomerVM.Instance.GetAllCustomer();
            DataGridCustomers.ItemsSource = Customers;
        }
    }
}