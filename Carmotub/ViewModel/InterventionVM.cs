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
    public class InterventionVM
    {
        private ObservableCollection<Intervention> _interventions;
        public ObservableCollection<Intervention> Interventions { get { return _interventions; } set { _interventions = value; } }

        private static InterventionVM _instance = null;
        public static InterventionVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new InterventionVM();
                return _instance;
            }
        }

        public InterventionVM()
        {
            _interventions = new ObservableCollection<Intervention>();
        }

        public async Task<bool> GetAllIntervention()
        {
            try
            {
                string query = "SELECT * FROM interventions";
                await SQLDataHelper.Instance.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    double montant;
                    bool result = Double.TryParse(dataReader["montant"].ToString(), out montant);

                    _interventions.Add(new Intervention()
                        {
                            carnet = dataReader["carnet"].ToString(),
                            date_intervention = Convert.ToDateTime(dataReader["date_intervention"].ToString()),
                            identifiant = int.Parse(dataReader["identifiant"].ToString()),
                            identifiant_client = int.Parse(dataReader["identifiant_client"].ToString()),
                            montant = montant,
                            nature = dataReader["nature"].ToString(),
                            numero_cheque = dataReader["numero_cheque"].ToString(),
                            type_chaudiere = dataReader["type_chaudiere"].ToString(),
                            type_paiement = dataReader["type_paiement"].ToString(),
                        });
                }

                return true;
            }
            catch(Exception E)
            {
                return false;
            }
        }
    }
}
