using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PairMaisonMedicalSpecialite
    {
        public Models.MaisonMedicale MaisonMedicale { get; set; }
        public List<Specialite> Specialites { get; set; }
    }
}
