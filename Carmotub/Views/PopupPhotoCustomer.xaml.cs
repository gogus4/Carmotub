using Carmotub.Model;
using Carmotub.ViewModel;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Logique d'interaction pour PopupPhotoCustomer.xaml
    /// </summary>
    public partial class PopupPhotoCustomer : Window
    {
        public CustomerPhoto Photo { get; set; }

        public PopupPhotoCustomer(CustomerPhoto photo)
        {
            InitializeComponent();

            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(photo.uri); ;
            bitmapImage.EndInit();

            imagePopup.Source = bitmapImage;

            Photo = photo;
        }

        private void ClosePopup_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void DeletePhoto_Click(object sender, RoutedEventArgs e)
        {
            if (await CustomerPhotoVM.Instance.DeletePhoto(Photo) == true)
            {
                UpdateCustomer.Instance.RefreshAndDeleteListBoxPhotoCustomer();
            }

            else
            {
                MessageBox.Show("Une erreur est intervenue lors de la suppression de la photo.");
            }

            this.Close();
        }
    }
}
