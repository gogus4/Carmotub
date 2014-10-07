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

        public async Task<bool> DeleteInterventionWithCustomer(Customer customer)
        {
            try
            {
                string query = "DELETE FROM interventions WHERE identifiant_client = @identifiant_client";
                await SQLDataHelper.Instance.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.Prepare();

                cmd.Parameters.Add("@identifiant_client", customer.identifiant);
                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> AddIntervention(Intervention intervention)
        {
            try
            {
                string query = "INSERT INTO interventions(identifiant_client,date_intervention,type_chaudiere,carnet,nature,montant,type_paiement,numero_cheque) VALUES(@identifiant_client,@date_intervention,@type_chaudiere,@carnet,@nature,@montant,@type_paiement,@numero_cheque)";
                await SQLDataHelper.Instance.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.Prepare();

                cmd.Parameters.Add("@identifiant_client", intervention.identifiant_client);
                cmd.Parameters.Add("@date_intervention", intervention.date_intervention);
                cmd.Parameters.Add("@type_chaudiere", intervention.type_chaudiere);
                cmd.Parameters.Add("@carnet", intervention.carnet);
                cmd.Parameters.Add("@nature", intervention.nature);
                cmd.Parameters.Add("@montant", intervention.montant);
                cmd.Parameters.Add("@type_paiement", intervention.type_paiement);
                cmd.Parameters.Add("@numero_cheque", intervention.numero_cheque);

                cmd.ExecuteNonQuery();
                _interventions.Add(intervention);
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> GetAllIntervention()
        {
            try
            {
                _interventions = new ObservableCollection<Intervention>();
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
