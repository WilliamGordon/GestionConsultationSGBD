using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MedecinSpecialiteMaisonMedicale
    {
        public int MedecinSpecialiteMaisonMedicale_ID { get; set; }
        public int MedecinSpecialite_ID { get; set; }
        public int MaisonMedicale_ID { get; set; }
        public int MinimalDuration { get; set; }
        public bool IsActif { get; set; }
    }
}
