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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Carmotub.Views;

namespace Carmotub
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void DisplayCalendar_Click(object sender, RoutedEventArgs e)
        {
            ListCustomers.Visibility = Visibility.Collapsed;
            Calendar.Visibility = Visibility.Visible;

            await Carmotub.Views.Controls.Calendar.Instance.refreshCalendar();
        }

        private async void DisplayListCustomers_Click(object sender, RoutedEventArgs e)
        {
            ListCustomers.Visibility = Visibility.Visible;
            Calendar.Visibility = Visibility.Collapsed;
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Show();
        }

        private async void RemoveCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = (Customer)ActionsCustomers.Instance.DataGridCustomers.SelectedItem;

            if (customer != null)
            {
                if (MessageBox.Show("Etes-vous sur de vouloir supprimer le client " + customer.nom + " " + customer.prenom, "Supprimer le client", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (await CustomerVM.Instance.DeleteCustomer(customer) == true)
                    {
                        ActionsCustomers.Instance.Customers.Add(customer);
                        await ActionsCustomers.Instance.Init();
                    }

                    else
                        MessageBox.Show("Une erreur est intervenue lors de la suppression du client.");

                }
            }

            else
                MessageBox.Show("Merci de selectionné un client avant de le supprimer.", "Aucun client selectionné", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void AddIntervention_Click(object sender, RoutedEventArgs e)
        {
            var customer = (Customer)ActionsCustomers.Instance.DataGridCustomers.SelectedItem;
            if (customer != null)
            {
                AddIntervention addIntervention = new AddIntervention(customer);
                addIntervention.Show();
            }

            else
                MessageBox.Show("Merci de selectionné un client pour pouvoir affecté l'intervention à un client.", "Aucun client selectionné", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}