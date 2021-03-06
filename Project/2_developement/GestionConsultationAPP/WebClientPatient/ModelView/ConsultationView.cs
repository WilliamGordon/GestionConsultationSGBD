using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientPatient.ModelView
{
    public class ConsultationView
    {
        public Models.Consultation Consultation { get; set; }
        public Models.MaisonMedicale MaisonMedicale { get; set; }
        public Models.Medecin Medecin { get; set; }
        public Models.Specialite Specialite { get; set; }
        public Models.Local Local { get; set; }
    }
}