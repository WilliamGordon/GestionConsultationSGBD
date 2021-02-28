using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientMedecin.ModelView
{
    public class MedecinSpecialiteMaisonMedicaleEdit
    {
        public int MedecinSpecialiteMaisonMedicale_ID { get; set; }
        public int Medecin_ID { get; set; }
        public int MaisonMedicale_ID { get; set; }
        public int MedecinSpecialite_ID { get; set; }
        public int MinimalDuration { get; set; }
    }
}