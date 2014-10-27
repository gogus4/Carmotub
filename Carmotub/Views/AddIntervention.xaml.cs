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
    public partial class AddIntervention : Window
    {
        public Customer Customer { get; set; }

        private static AddIntervention _instance = null;
        public static AddIntervention Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AddIntervention();
                return _instance;
            }
        }

        public AddIntervention()
        {
            InitializeComponent();
        }

        public AddIntervention(Customer customer)
        {
            InitializeComponent();

            _instance = this;
            Customer = customer;

            CustomerSelected.Text = Customer.nom + " " + Customer.prenom;
        }

        private async void AddInterventionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double montant;
                bool result = Double.TryParse(Montant.Text.Replace(".", ","), out montant);

                Intervention intervention = new Intervention()
                {
                    carnet = Carnet.Text,
                    date_intervention = Convert.ToDateTime(DateIntervention.Text),
                    identifiant_client = Customer.identifiant,
                    montant = montant,
                    nature = Nature.Text,
                    numero_cheque = NumeroCheque.Text,
                    type_chaudiere = TypeChaudiere.Text,
                    type_paiement = TypePaiement.Text
                };

                if (await InterventionVM.Instance.AddIntervention(intervention) == true)
                    this.Close();

                else
                {
                    MessageBox.Show("Une erreur est intervenue lors de l'ajout de l'intervention.");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("Une erreur est intervenue lors de l'ajout de l'intervention.");
            }
        }
    }
}
