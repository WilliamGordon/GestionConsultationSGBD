using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientMedecin.ModelView
{
    public class PresenceCreate
    {
        public int Medecin_ID { get; set; }
        public int MaisonMedicale_ID { get; set; }
        public string[] days { get; set; }
        public DateTime Starting { get; set; }
        public DateTime Ending { get; set; }
        public List<Models.MaisonMedicale> ListMMForMedecin { get; set; }
    }
}