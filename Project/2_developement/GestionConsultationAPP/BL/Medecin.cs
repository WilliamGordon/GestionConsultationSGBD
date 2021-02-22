using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Medecin
    {
        public List<object> GetAll()
        {
            DAL.EFMedecin Med = new DAL.EFMedecin();
            Med.GetAll();

        }
    }
}
