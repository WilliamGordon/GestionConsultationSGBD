using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientPatient.ModelView
{
    public class ConsultationEdit
    {
        public int Consultation_ID { get; set; }
        public int Patient_ID { get; set; }
        public int MaisonMedicale_ID { get; set; }
        public int MedecinSpecialiteMaisonMedicale_ID { get; set; }
        public int Local_ID { get; set; }
        public System.DateTime Starting { get; set; }
        public System.DateTime Ending { get; set; }
    }
}