using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CustomErrors
{
    public class NoAvailabilityForMedecin : Exception
    {
        public NoAvailabilityForMedecin(string message) : base(message)
        {

        }
    }
}
