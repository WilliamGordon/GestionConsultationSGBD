using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientMedecin.ModelView
{
    public class MaisonMedicaleForMedecinView
    {
        public Models.Medecin Medecin { get; set; }
        public Models.MaisonMedicale MaisonMedicale { get; set; }
        public Models.Specialite Specialite { get; set; }
        public Models.MedecinSpecialiteMaisonMedicale MSMM { get; set; }
        public Models.MedecinSpecialite MS { get; set; }
    }
}