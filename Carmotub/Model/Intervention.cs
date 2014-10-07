﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmotub.Model
{
    public class Intervention
    {
        public int identifiant { get; set; }
        public int identifiant_client { get; set; }
        public DateTime date_intervention { get; set; }
        public string type_chaudiere { get; set; }
        public string carnet { get; set; }
        public string nature { get; set; }
        public double montant { get; set; }
        public string type_paiement { get; set; }
        public string numero_cheque { get; set; }
    }
}