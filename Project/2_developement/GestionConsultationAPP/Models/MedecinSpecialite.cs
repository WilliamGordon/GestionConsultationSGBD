using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MedecinSpecialite
    {
        public int MedecinSpecialite_ID { get; set; }
        public int Medecin_ID { get; set; }
        public int Specialite_ID { get; set; }
    }
}
