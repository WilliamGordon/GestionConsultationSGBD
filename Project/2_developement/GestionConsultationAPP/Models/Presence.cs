using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Presence
    {
        public int Presence_ID { get; set; }
        public int Medecin_ID { get; set; }
        public int MaisonMedicale_ID { get; set; }
        public System.DateTime Starting { get; set; }
        public System.DateTime Ending { get; set; }
    }
}
