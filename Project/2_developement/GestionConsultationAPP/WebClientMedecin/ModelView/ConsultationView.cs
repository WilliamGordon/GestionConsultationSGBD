using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientMedecin.ModelView
{
    public class ConsultationView
    {
        public int Consultation_ID { get; set; }
        public int Patient_ID { get; set; }
        public int MaisonMedicale_ID { get; set; }
        public int MedecinSpecialiteMaisonMedicale_ID { get; set; }
        public int Local_ID { get; set; }
        public System.DateTime Starting { get; set; }
        public System.DateTime Ending { get; set; }
        public Models.MaisonMedicale MaisonMedicale { get; set; }
        public Models.Patient Patient { get; set; }
        public Models.Specialite Specialite { get; set; }

    }
}