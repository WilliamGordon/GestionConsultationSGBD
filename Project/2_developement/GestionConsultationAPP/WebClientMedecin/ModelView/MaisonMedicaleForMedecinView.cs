using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientMedecin.ModelView
{
    public class MaisonMedicaleForMedecinView
    {
        public Models.Medecin Medecin { get; set; }
        IDictionary<Models.MaisonMedicale, List<Models.Specialite>> MaisonMedicaleWithSpecialite { get; set; }
    }
}