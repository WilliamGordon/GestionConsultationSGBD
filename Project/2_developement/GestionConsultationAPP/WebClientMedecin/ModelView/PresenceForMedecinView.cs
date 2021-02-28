using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientMedecin.ModelView
{
    public class PresenceForMedecinView
    {
        public Models.Medecin Medecin { get; set; }
        public Models.MaisonMedicale MaisonMedicale { get; set; }
        public DateTime Starting { get; set; }
        public DateTime Ending { get; set; }
    }
}