using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientMedecin.ModelView
{
    public class MedecinSpecialiteMaisonMedicaleCreate
    {
        public int Medecin_ID { get; set; }
        public int MaisonMedicale_ID { get; set; }
        public int MedecinSpecialite_ID { get; set; }
        public int MinimalDuration { get; set; }
        public Dictionary<Models.Specialite, Models.MedecinSpecialite> DicMS { get; set; }
        public List<Models.Specialite> listSpecialiteOfMedecin { get; set; }
        public List<Models.MaisonMedicale> listMaisonMedicale { get; set; }

        public MedecinSpecialiteMaisonMedicaleCreate()
        {
            DicMS = new Dictionary<Models.Specialite, Models.MedecinSpecialite>();
            listSpecialiteOfMedecin = new List<Models.Specialite>();
            listMaisonMedicale = new List<Models.MaisonMedicale>();
        }
    }
}