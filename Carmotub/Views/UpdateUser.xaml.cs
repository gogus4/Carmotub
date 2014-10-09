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
    public partial class UpdateUser : Window
    {
        public Customer CustomerToUpdate { get; set; }

        public UpdateUser(Customer customer)
        {
            InitializeComponent();

            CustomerToUpdate = customer;
            this.DataContext = this;

            var list_interventions = InterventionVM.Instance.Interventions.Where(x => x.identifiant_client == CustomerToUpdate.identifiant);
            DataGridInterventions.ItemsSource = list_interventions;

            Commentaire.Document.Blocks.Clear();
            Commentaire.Document.Blocks.Add(new Paragraph(new Run(CustomerToUpdate.commentaire)));
        }

        private async void UpdateCustomer_Click(object sender, RoutedEventArgs e)
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
    }
}
