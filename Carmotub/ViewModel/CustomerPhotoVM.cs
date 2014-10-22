using Carmotub.Data;
using Carmotub.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmotub.ViewModel
{
    public class CustomerPhotoVM
    {
        private ObservableCollection<CustomerPhoto> _photos;
        public ObservableCollection<CustomerPhoto> Photos { get { return _photos; } set { _photos = value; } }

        private static CustomerPhotoVM _instance = null;
        public static CustomerPhotoVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CustomerPhotoVM();
                return _instance;
            }
        }

        public CustomerPhotoVM()
        {
        }

        public async Task<bool> DeletePhotoWithCustomer(Customer customer)
        {
            try
            {
                string query = "DELETE FROM photos_client WHERE identifiant_client = @identifiant_client";
                await SQLDataHelper.Instance.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.Prepare();

                cmd.Parameters.Add("@identifiant_client", customer.identifiant);
                cmd.ExecuteNonQuery();

                await GetAllPhoto();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeletePhoto(CustomerPhoto photo)
        {
            try
            {
                string query = "DELETE FROM photos_client WHERE identifiant = @identifiant";
                await SQLDataHelper.Instance.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.Prepare();

                cmd.Parameters.Add("@identifiant", photo.identifiant);
                cmd.ExecuteNonQuery();

                await GetAllPhoto();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> AddPhoto(CustomerPhoto photo)
        {
            try
            {
                string query = "INSERT INTO photos_client(identifiant_client,uri) VALUES(@identifiant_client,@uri)";
                await SQLDataHelper.Instance.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.Prepare();

                cmd.Parameters.Add("@identifiant_client", photo.identifiant_client);
                cmd.Parameters.Add("@uri", photo.uri);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task GetAllPhoto()
        {
            try
            {
                Photos = new ObservableCollection<CustomerPhoto>();
                string query = "SELECT * FROM photos_client";
                await SQLDataHelper.Instance.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Photos.Add(new CustomerPhoto()
                    {
                        identifiant = int.Parse(dataReader["identifiant"].ToString()),
                        identifiant_client = int.Parse(dataReader["identifiant_client"].ToString()),
                        uri = dataReader["uri"].ToString(),
                    });
                }
            }
            catch (Exception E) { }
        }
    }
}