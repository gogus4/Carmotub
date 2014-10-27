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
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace Carmotub
{
    public partial class MainWindow : Window
    {
        StreamWriter OutputStream;

        public MainWindow()
        {
            InitializeComponent();

            GetLastDateTimeBackup();
        }

        private async void GetLastDateTimeBackup()
        {
            var lastDateTime = await BackupDatabaseVM.Instance.GetLastBackupDatabase();
            var date = DateTime.Now.AddDays(-15);

            if (date.CompareTo(lastDateTime) > 0)
            {
                if (MessageBox.Show("Cela fait 15 jours que vous n'avez pas fait de sauvegarde de la base de données." + Environment.NewLine + "Voulez-vous en faire une ?", "Sauvegarde de la base de données", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    StartBackupDatabase();
                }
            }
        }

        private async void DisplayCalendar_Click(object sender, RoutedEventArgs e)
        {
            ListCustomers.Visibility = Visibility.Collapsed;
            Calendar.Visibility = Visibility.Visible;

            await Carmotub.Views.Controls.Calendar.Instance.refreshCalendar();
        }

        private void DisplayListCustomers_Click(object sender, RoutedEventArgs e)
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

        private async void StartBackupDatabase()
        {
            GridTransparentLoading.Visibility = Visibility.Visible;
            ProgressBarLoadingBackupDatabase.Visibility = Visibility.Visible;

            CreateBackup();
        }

        private void BackupDatabase_Click(object sender, RoutedEventArgs e)
        {
            StartBackupDatabase();
        }

        private async void OnDataReceived(object Sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            Dispatcher.Invoke((Action)(() => ProgressBackupDatabase.Value += 1));
            Dispatcher.Invoke((Action)(() => PourcentProgressBar.Text = Math.Round((ProgressBackupDatabase.Value * 100) / 128, 0).ToString() + "%"));

            if (e.Data != null)
            {
                OutputStream.WriteLine(e.Data);
            }

            else
            {
                Dispatcher.Invoke((Action)(() => GridTransparentLoading.Visibility = Visibility.Collapsed));
                Dispatcher.Invoke((Action)(() => ProgressBarLoadingBackupDatabase.Visibility = Visibility.Collapsed));

                await BackupDatabaseVM.Instance.AddBackupDatabase(DateTime.Now);

                OutputStream.Flush();
                OutputStream.Close();
            }
        }

        private void CreateBackup()
        {
            ProgressBackupDatabase.Value = 0;
            string mysqldumpPath = ConfigurationManager.AppSettings["PathMysqlDump"] + "mysqldump.exe";
            string user = "root";
            string dbnm = "carmotub";

            string cmd = String.Format("-u{0} --opt --databases {1}", user, dbnm);

            string filePath = ConfigurationManager.AppSettings["PathUsbDatabase"] + @"\db" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ".sql";
            OutputStream = new StreamWriter(filePath);

            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = mysqldumpPath;
            startInfo.Arguments = cmd;

            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardInput = false;
            startInfo.RedirectStandardOutput = true;

            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.ErrorDialog = false;

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = startInfo;
            proc.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(OnDataReceived);
            proc.Start();

            proc.BeginOutputReadLine();
            proc.Close();
        }

        private void PrintCustomers_Click(object sender, RoutedEventArgs e)
        {
            PrintCustomers printCustomers = new PrintCustomers();
            printCustomers.Show();
        }

        private void Configuration_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }
    }
}