using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Carmotub.Data
{
    public class SQLDataHelper
    {
        public MySqlConnection Connection { get; set; }

        public SQLDataHelper()
        {

        }

        private static SQLDataHelper _instance = null;
        public static SQLDataHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SQLDataHelper();
                return _instance;
            }
        }

        public async Task<bool> OpenConnection()
        {
            try
            {
                string myConnectionString = "Database=carmotub;Data Source=localhost;User Id=root;Password=";
                Connection = new MySqlConnection(myConnectionString);

                Connection.Open();

                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
