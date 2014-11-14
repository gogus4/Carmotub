using Carmotub.Model;
using Carmotub.ViewModel;
using Carmotub.Views.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
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
        public static PrintCustomers _instance = null;
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


        private async void Window_Initialized_1(object sender, EventArgs e)
        {
            var Customers = ActionsCustomers.Instance.Customers;
            DataGridCustomers.ItemsSource = Customers;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            DataGridCustomers.ItemsSource = ActionsCustomers.Instance.Customers.Where(x => x.nom.ToUpper().Contains(SearchBoxText.Text.ToUpper())).ToList();
        }

        private void Print(Customer customer)
        {
            /*string fileText = "Carmotub                         " + customer.prenom + " " + customer.nom;

            fileText += Environment.NewLine + "________________________________________________________________________________" + Environment.NewLine + Environment.NewLine;
            fileText += "Nom :  " + customer.prenom + " " + customer.nom + "                     Rendez-vous : " + customer.Rdv + Environment.NewLine + Environment.NewLine;
            fileText += "Adresse :  " + customer.adresse + "    N° " + customer.numero_adresse + "        Voie : " + customer.voie + Environment.NewLine + "           " + customer.code_postal + " " + customer.ville + Environment.NewLine + Environment.NewLine;
            fileText += "Etage :  " + customer.etage + "          Escalier : " + customer.escalier + "               Code : " + customer.code + Environment.NewLine + Environment.NewLine;
            fileText += "Tel fixe :  " + customer.telephone_1;

            if (customer.telephone_2 != "")
                fileText += " Tel port. :  " + customer.telephone_2;

            fileText += "  Recommandé par : " + customer.recommande_par + Environment.NewLine + Environment.NewLine;
            fileText += "Commentaires :  " + customer.commentaire + Environment.NewLine;
            fileText += "________________________________________________________________________________" + Environment.NewLine + Environment.NewLine;

            var interventions = InterventionVM.Instance.Interventions.Where(x => x.identifiant_client == customer.identifiant).OrderByDescending(x => x.date_intervention);

            if (interventions.Count() > 0)
            {
                fileText += "Date          Type                Carnet  Nature                    Montant       " + Environment.NewLine;
                foreach (Intervention intervention in interventions)
                {
                    var type = intervention.type_chaudiere;
                    var carnet = intervention.carnet;
                    var nature = intervention.nature;

                    if (type.Length > 20)
                        type = type.Substring(0, 20);

                    if (carnet.Length > 8)
                        carnet = carnet.Substring(0, 8);

                    if (nature.Length > 26)
                        nature = nature.Substring(0, 26);

                    fileText += intervention.date + "    " + String.Format("{0,-" + ((20 + type.Length) - type.Length).ToString() + "}", type) + String.Format("{0,-" + ((8 + carnet.Length) - carnet.Length).ToString() + "}", carnet) + String.Format("{0,-" + ((26 + nature.Length) - nature.Length).ToString() + "}", nature) + intervention.montant + Environment.NewLine;
                }
            }

            string filename = "printer_" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + "." + DateTime.Now.Minute + "." + DateTime.Now.Second + "." + DateTime.Now.Millisecond + ".txt";

            using (FileStream fs = File.Create(filename))
            {
                Byte[] title = new UTF8Encoding(true).GetBytes(fileText);
                fs.Write(title, 0, title.Length);
            }

            string pathFile = Directory.GetCurrentDirectory() + "\\" + filename;

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = pathFile;
            psi.Verb = "Print";
            Process.Start(psi).WaitForExit();

            File.Delete(pathFile);*/
        }

        private void PrintCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = (Customer)DataGridCustomers.SelectedItem;

            if (customer == null)
            {
                MessageBox.Show("Merci de selectionné un client avant d'imprimer la fiche d'intervention", "Aucun client selectionné", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Print(customer);
        }

        private void PrintPlanning_Click(object sender, RoutedEventArgs e)
        {
            /*List<Customer> list_customers = new List<Customer>();
            var interventions = InterventionVM.Instance.Interventions.Where(x => x.date == SelectedDate.Text);

            foreach (Intervention inter in interventions)
            {
                if (list_customers.Where(x => x.identifiant == inter.identifiant_client).FirstOrDefault() == null)
                {
                    list_customers.Add(ActionsCustomers.Instance.Customers.Where(x => x.identifiant == inter.identifiant_client).FirstOrDefault());
                    Print(ActionsCustomers.Instance.Customers.Where(x => x.identifiant == inter.identifiant_client).FirstOrDefault());
                }
            }*/
        }
    }
}