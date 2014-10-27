using System;
using System.Configuration;
using System.Drawing.Printing;
using System.Windows;
using System.Windows.Forms;
using System.Xml;

namespace Carmotub.Views
{
    public partial class Settings : Window
    {
        public string Printer { get; set; }
        public string PathBackupDatabase { get; set; }

        public Settings()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            PrinterName.ItemsSource = PrinterSettings.InstalledPrinters;
            PrinterName.SelectedValue = ConfigurationManager.AppSettings["PrinterName"];

            PathBackupDatabase = ConfigurationManager.AppSettings["PathUsbDatabase"];
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                foreach (XmlElement element in xmlDoc.DocumentElement)
                {
                    if (element.Name.Equals("appSettings"))
                    {
                        foreach (XmlNode node in element.ChildNodes)
                        {
                            if (node.Attributes[0].Value.Equals("PrinterName"))
                            {
                                node.Attributes[1].Value = PrinterName.SelectedValue.ToString();
                            }

                            if (node.Attributes[0].Value.Equals("PathUsbDatabase"))
                            {
                                node.Attributes[1].Value = PathBackupDatabase;
                            }
                        }
                    }
                }

                xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                ConfigurationManager.RefreshSection("appSettings");

            }
            catch (Exception E)
            {
                System.Windows.Forms.MessageBox.Show(E.StackTrace);
            }

            this.Close();
        }

        private void BackupDatabase_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.SelectedPath = "C:\\";

            DialogResult result = folderDialog.ShowDialog();

            if (result.ToString() == "OK")
                PathBackupDatabase = folderDialog.SelectedPath;
        }
    }
}
