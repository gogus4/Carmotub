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
    public class BackupDatabaseVM
    {
        private static BackupDatabaseVM _instance = null;
        public static BackupDatabaseVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BackupDatabaseVM();
                return _instance;
            }
        }

        public BackupDatabaseVM()
        {
        }

        public async Task<bool> AddBackupDatabase(DateTime newDatetime)
        {
            try
            {
                string query = "INSERT INTO backup_database(date) VALUES(@date)";
                await SQLDataHelper.Instance.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.Prepare();

                cmd.Parameters.Add("@date", newDatetime);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<DateTime> GetLastBackupDatabase()
        {
            try
            {
                string query = "SELECT * FROM `backup_database` order by date desc LIMIT 1";
                
                await SQLDataHelper.Instance.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    return (DateTime)dataReader["date"];
                }
            }
            catch (Exception E) { }

            return DateTime.Now;
        }
    }
}