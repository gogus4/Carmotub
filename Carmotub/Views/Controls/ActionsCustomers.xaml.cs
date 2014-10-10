using Carmotub.Model;
using Carmotub.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Carmotub.Views.Controls
{
    public partial class ActionsCustomers : UserControl
    {
        public List<Customer> Customers { get; set; }

        private static ActionsCustomers _instance = null;
        public static ActionsCustomers Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ActionsCustomers();
                return _instance;
            }
        }

        public ActionsCustomers()
        {
            InitializeComponent();
            _instance = this;
        }

        public void AddValue()
        {
            ActionsCustomers.Instance.ProgressBackupDatabase.Value += 1;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private async void UserControl_Initialized(object sender, EventArgs e)
        {
            await Init();
        }

        public async Task Init()
        {
            Customers = await CustomerVM.Instance.GetAllCustomer();
            await CustomerPhotoVM.Instance.GetAllPhoto();

            DataGridCustomers.ItemsSource = Customers;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchBoxText.Text == "")
            {
                DataGridCustomers.ItemsSource = Customers;
                return;
            }

            List<Customer> list_customers = new List<Customer>();
            switch (SearchBy.SelectedIndex)
            {
                case 0:
                    list_customers = Customers.Where(x => x.nom.ToUpper().Contains(SearchBoxText.Text.ToUpper())).ToList();
                    break;

                case 1:
                    list_customers = Customers.Where(x => x.adresse.ToUpper().Contains(SearchBoxText.Text.ToUpper())).ToList();
                    break;

                case 2:
                    list_customers = Customers.Where(x => x.code_postal.ToUpper().Contains(SearchBoxText.Text.ToUpper())).ToList();
                    break;

                case 3:
                    list_customers = Customers.Where(x => x.telephone_1.ToUpper().Contains(SearchBoxText.Text.ToUpper())).ToList();
                    break;

                case 4:
                    list_customers = Customers.Where(x => x.Rdv.ToUpper().Contains(SearchBoxText.Text.ToUpper())).ToList();
                    break;

                case 5:
                    list_customers = Customers.Where(x => x.telephone_2.ToUpper().Contains(SearchBoxText.Text.ToUpper())).ToList();
                    break;

                // A COMPLETER
                case 6:
                    list_customers = Customers.Where(x => x.telephone_2.ToUpper().Contains(SearchBoxText.Text.ToUpper())).ToList();
                    break;
            }

            DataGridCustomers.ItemsSource = list_customers;
        }

        private void DataGridCustomers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var customer = (Customer)DataGridCustomers.SelectedItem;

                UpdateCustomer UpdateCustomer = new UpdateCustomer(customer);
                UpdateCustomer.Show();
            }
            catch (Exception E)
            {
                MessageBox.Show("Merci de selectionné un client avant de le modifier.", "Aucun client selectionné", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
