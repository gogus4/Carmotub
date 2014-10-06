using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmotub.Model
{
    public class Customer
    {
        public int identifiant { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string adresse { get; set; }
        public string code_postal { get; set; }
        public string ville { get; set; }
        public string etage { get; set; }
        public string escalier { get; set; }
        public string telephone_1 { get; set; }
        public string telephone_2 { get; set; }
        public string commentaire { get; set; }
        public string code { get; set; }
        public string ColorRDV { get; set; }

        private string rdv;
        public string Rdv
        {
            get
            {
                return rdv;
            }
            set
            {
                rdv = value;
                /*if (rdv != "")
                {
                    ColorRDV = "LightGray";
                }*/
            }
        }
        public string recommande_par { get; set; }
    }
}
