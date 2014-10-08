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

        public async Task<bool> DeleteCustomer(Customer customer)
        {
            try
            {
                string query = "DELETE FROM clients WHERE identifiant = @identifiant";
                await SQLDataHelper.Instance.OpenConnection();

                await InterventionVM.Instance.DeleteInterventionWithCustomer(customer);

                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.Prepare();

                cmd.Parameters.Add("@identifiant", customer.identifiant);
                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            try
            {
                string query = "UPDATE clients SET nom = @nom, prenom = @prenom, adresse = @adresse, code_postal = @code_postal, ville = @ville, etage = @etage, escalier = @escalier, telephone_1=@telephone_1,telephone_2=@telephone_2,commentaire=@commentaire,code=@code,rdv=@rdv,recommande_par=@recommande_par WHERE identifiant = @identifiant";
                await SQLDataHelper.Instance.OpenConnection();


                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.Prepare();

                cmd.Parameters.Add("@nom", customer.nom);
                cmd.Parameters.Add("@prenom", customer.prenom);
                cmd.Parameters.Add("@adresse", customer.adresse);
                cmd.Parameters.Add("@code_postal", customer.code_postal);
                cmd.Parameters.Add("@ville", customer.ville);
                cmd.Parameters.Add("@etage", customer.etage);
                cmd.Parameters.Add("@escalier", customer.escalier);
                cmd.Parameters.Add("@telephone_1", customer.telephone_1);
                cmd.Parameters.Add("@telephone_2", customer.telephone_2);
                cmd.Parameters.Add("@commentaire", customer.commentaire);
                cmd.Parameters.Add("@code", customer.code);
                cmd.Parameters.Add("@rdv", customer.Rdv);
                cmd.Parameters.Add("@recommande_par", customer.recommande_par);
                cmd.Parameters.Add("@identifiant", customer.identifiant);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> AddCustomer(Customer customer)
        {
            try
            {
                string query = "INSERT INTO clients(nom,prenom,adresse,code_postal,ville,etage,escalier,telephone_1,telephone_2,commentaire,recommande_par,code,rdv) VALUES(@nom,@prenom,@adresse,@code_postal,@ville,@etage,@escalier,@telephone_1,@telephone_2,@commentaire,@recommande_par,@code,@rdv)";
                await SQLDataHelper.Instance.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.Prepare();

                cmd.Parameters.Add("@nom", customer.nom);
                cmd.Parameters.Add("@prenom", customer.prenom);
                cmd.Parameters.Add("@adresse", customer.adresse);
                cmd.Parameters.Add("@code_postal", customer.code_postal);
                cmd.Parameters.Add("@ville", customer.ville);
                cmd.Parameters.Add("@etage", customer.etage);
                cmd.Parameters.Add("@escalier", customer.escalier);
                cmd.Parameters.Add("@telephone_1", customer.telephone_1);
                cmd.Parameters.Add("@telephone_2", customer.telephone_2);
                cmd.Parameters.Add("@commentaire", customer.commentaire);
                cmd.Parameters.Add("@recommande_par", customer.recommande_par);
                cmd.Parameters.Add("@code", customer.code);
                cmd.Parameters.Add("@rdv", customer.Rdv);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

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
