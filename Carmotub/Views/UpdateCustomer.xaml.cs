using Carmotub.Model;
using Carmotub.ViewModel;
using Carmotub.Views.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

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

            ImageListbox.ItemsSource = CustomerPhotoVM.Instance.Photos.Where(x => x.identifiant_client == customer.identifiant);
        }

        public void RefreshDataGridInterventions()
        {
            var list_interventions = InterventionVM.Instance.Interventions.Where(x => x.identifiant_client == CustomerToUpdate.identifiant);
            DataGridInterventions.ItemsSource = list_interventions;
        }

        public void RefreshAndDeleteListBoxPhotoCustomer()
        {
            ImageListbox.ItemsSource = CustomerPhotoVM.Instance.Photos.Where(x => x.identifiant_client == CustomerToUpdate.identifiant);
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
                Rdv = Rdv.Text,
                voie = Voie.Text,
                numero_adresse = NumAdresse.Text
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

        private async void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.DefaultExt = "*.jpg";
                openfile.Filter = "Image Files|*.jpg";
                Nullable<bool> result = openfile.ShowDialog();
                if (result == true)
                {
                    string path = @"C:\Users\" + Environment.UserName + @"\Documents\Carmotub\Photos\" + openfile.SafeFileName;
                    File.Copy(openfile.FileName, path);

                    if (await CustomerPhotoVM.Instance.AddPhoto(new CustomerPhoto() { identifiant_client = CustomerToUpdate.identifiant, uri = path }))
                    {
                        await CustomerPhotoVM.Instance.GetAllPhoto();
                        ImageListbox.ItemsSource = CustomerPhotoVM.Instance.Photos.Where(x => x.identifiant_client == CustomerToUpdate.identifiant);
                    }

                    else
                    {
                        MessageBox.Show("Une erreur est intervenue lors de l'ajout de la photo.");
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.StackTrace);
            }
        }

        private void ImageListbox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CustomerPhoto photo = (CustomerPhoto)ImageListbox.SelectedItem;

            PopupPhotoCustomer popup = new PopupPhotoCustomer(photo);
            popup.Show();
        }
    }
}
