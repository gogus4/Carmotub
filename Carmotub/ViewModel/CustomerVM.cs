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
    public class CustomerVM
    {
        private static CustomerVM _instance = null;
        public static CustomerVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CustomerVM();
                return _instance;
            }
        }

        public CustomerVM()
        {
        }

        public async Task<bool> AddCustomer(Customer customer)
        {
            /*try
            {
                string query = "INSERT INTO clients(adresse_siege,code_postal,ville,nom,indice_contact,numero_telephone_1,numero_telephone_2,numero_telephone_3,adresse_email,numero_fax,indice_assurance) VALUES(@adresse_siege,@code_postal,@ville,@nom,@indice_contact,@numero_telephone_1,@numero_telephone_2,@numero_telephone_3,@adresse_email,@numero_fax,@indice_assurance)";
                await SQLDataHelper.Instance.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.Prepare();

                cmd.Parameters.Add("@adresse_siege", _client.adresse_siege);
                cmd.Parameters.Add("@code_postal", _client.code_postal);
                cmd.Parameters.Add("@ville", _client.ville);
                cmd.Parameters.Add("@nom", _client.nom);
                cmd.Parameters.Add("@indice_contact", _client.indice_contact);
                cmd.Parameters.Add("@numero_telephone_1", _client.numero_telephone_1);
                cmd.Parameters.Add("@numero_telephone_2", _client.numero_telephone_2);
                cmd.Parameters.Add("@numero_telephone_3", _client.numero_telephone_3);
                cmd.Parameters.Add("@adresse_email", _client.adresse_email);
                cmd.Parameters.Add("@numero_fax", _client.numero_fax);
                cmd.Parameters.Add("@indice_assurance", _client.indice_assurance);
                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }*/

            return true;
        }

        public async Task<List<Customer>> GetAllCustomer()
        {
            try
            {
                List<Customer> Customers = new List<Customer>();
                string query = "SELECT * FROM clients";
                await SQLDataHelper.Instance.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Customers.Add(new Customer()
                    {
                        adresse = dataReader["adresse"].ToString(),
                        code = dataReader["code"].ToString(),
                        code_postal = dataReader["code_postal"].ToString(),
                        commentaire = dataReader["commentaire"].ToString(),
                        escalier = dataReader["escalier"].ToString(),
                        etage = dataReader["etage"].ToString(),
                        identifiant = int.Parse(dataReader["identifiant"].ToString()),
                        nom = dataReader["nom"].ToString(),
                        prenom = dataReader["prenom"].ToString(),
                        Rdv = dataReader["rdv"].ToString(),
                        recommande_par = dataReader["recommande_par"].ToString(),
                        telephone_1 = dataReader["telephone_1"].ToString(),
                        telephone_2 = dataReader["telephone_2"].ToString(),
                        ville = dataReader["ville"].ToString()
                    });
                }

                return Customers;
            }
            catch (Exception E)
            {
                return null;
            }
        }
    }
}
