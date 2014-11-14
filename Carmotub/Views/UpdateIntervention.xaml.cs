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
    public partial class UpdateIntervention : Window
    {
        public Intervention Intervention { get; set; }

        public UpdateIntervention(Intervention intervention)
        {
            InitializeComponent();

            Intervention = intervention;
            this.DataContext = this;
        }

        private async void UpdateIntervention_Click(object sender, RoutedEventArgs e)
        {
            /*double montant;
            bool result = Double.TryParse(Montant.Text.Replace(".", ","), out montant);

            Intervention intervention = new Intervention()
            {
                identifiant = Intervention.identifiant,
                carnet = Carnet.Text,
                date_intervention = Convert.ToDateTime(DateIntervention.Text),
                identifiant_client = Intervention.identifiant_client,
                montant = montant,
                nature = Nature.Text,
                numero_cheque = NumeroCheque.Text,
                type_chaudiere = TypeChaudiere.Text,
                type_paiement = TypePaiement.Text

            };

            if (await InterventionVM.Instance.UpdateIntervention(intervention) == true)
            {
                UpdateCustomer.Instance.RefreshDataGridInterventions();
                this.Close();
            }

            else
            {
                MessageBox.Show("Une erreur est intervenue lors de la modification de l'intervention.");
            }*/
        }

        private async void DeleteInterventionButton_Click(object sender, RoutedEventArgs e)
        {
            if (await InterventionVM.Instance.DeleteIntervention(Intervention) == true)
            {
                //if (await InterventionVM.Instance.GetAllIntervention() == true)
                //{
                UpdateCustomer.Instance.RefreshDataGridInterventions();
                this.Close();
                //}

                //else MessageBox.Show("Une erreur est intervenue lors de la suppression du client.");
            }

            else MessageBox.Show("Une erreur est intervenue lors de la suppression du client.");
        }
    }
}
