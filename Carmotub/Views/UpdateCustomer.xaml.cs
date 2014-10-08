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
    public partial class UpdateCustomer : Window
    {
        private static UpdateCustomer _instance = null;
        public static UpdateCustomer Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UpdateCustomer(null);
                return _instance;
            }
        }

        public Customer CustomerToUpdate { get; set; }

        public UpdateCustomer(Customer customer)
        {
            InitializeComponent();

            _instance = this;
            CustomerToUpdate = customer;
            this.DataContext = this;


            RefreshDataGridInterventions();

            Commentaire.Document.Blocks.Clear();
            Commentaire.Document.Blocks.Add(new Paragraph(new Run(CustomerToUpdate.commentaire)));
        }

        public void RefreshDataGridInterventions()
        {
            var list_interventions = InterventionVM.Instance.Interventions.Where(x => x.identifiant_client == CustomerToUpdate.identifiant);
            DataGridInterventions.ItemsSource = list_interventions;
        }

        private async void UpdateCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            string richText = new TextRange(Commentaire.Document.ContentStart, Commentaire.Document.ContentEnd).Text;
            Customer customer = new Customer()
            {
                identifiant = CustomerToUpdate.identifiant,
                adresse = Adresse.Text,
                code = Code.Text,
                code_postal = CodePostal.Text,
                commentaire = richText,
                nom = Name.Text,
                prenom = Firstname.Text,
                ville = Ville.Text,
                etage = Etage.Text,
                escalier = Escalier.Text,
                telephone_1 = TelFixe.Text,
                telephone_2 = TelPortable.Text,
                recommande_par = RecommandePar.Text,
                Rdv = Rdv.Text
            };

            if (await CustomerVM.Instance.UpdateCustomer(customer) == true)
            {
                await ActionsCustomers.Instance.Init();

                this.Close();
            }

            else
            {
                MessageBox.Show("Une erreur est intervenue lors de la modification du client.");
            }
        }

        private void DataGridInterventions_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var intervention = (Intervention)DataGridInterventions.SelectedItem;

            UpdateIntervention updateIntervention = new UpdateIntervention(intervention);
            updateIntervention.Show();
        }
    }
}
