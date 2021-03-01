using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientPatient.ModelView
{
    public class ConsultationCreate
    {
        public int Patient_ID { get; set; }
        public int MaisonMedicale_ID { get; set; }
        public int MedecinSpecialiteMaisonMedicale_ID { get; set; }
        public int Local_ID { get; set; }
        public System.DateTime Starting { get; set; }
        public System.DateTime Ending { get; set; }
        public List<Models.MaisonMedicale> listMaisonMedicales { get; set; }
        public List<Models.Local> listlocaux { get; set; }
        public List<Models.Specialite> listSpecialites { get; set; }
        public List<Models.Medecin> listMedecin { get; set; }
    }
}