using Carmotub.Model;
using Carmotub.ViewModel;
using Carmotub.Views.Controls;
using System.Windows;
using System.Windows.Documents;

namespace Carmotub.Views
{
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private async void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            string richText = new TextRange(Commentaire.Document.ContentStart, Commentaire.Document.ContentEnd).Text;
            Customer customer = new Customer()
            {
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
                Rdv = Rdv.Text,
                voie = Voie.Text,
                numero_adresse = NumAdresse.Text
            };

            if (await CustomerVM.Instance.AddCustomer(customer) == true)
            {
                ActionsCustomers.Instance.Customers.Add(customer);
                await ActionsCustomers.Instance.Init();

                this.Close();
            }

            else
            {
                MessageBox.Show("Une erreur est intervenue lors de l'ajout du client.");
            }
        }
    }
}