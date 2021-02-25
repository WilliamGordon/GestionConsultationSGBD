using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientMedecin.ModelView
{
    public class MedecinSpecialiteCreate
    {
        public int Medecin_ID { get; set; }
        public int Specialite_ID { get; set; }
        public List<Models.Specialite> listSpecialite { get; set; }
    }
}