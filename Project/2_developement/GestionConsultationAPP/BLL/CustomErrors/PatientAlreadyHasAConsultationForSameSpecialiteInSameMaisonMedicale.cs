using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CustomErrors
{
    public class PatientAlreadyHasAConsultationForSameSpecialiteInSameMaisonMedicale : Exception
    {
        public PatientAlreadyHasAConsultationForSameSpecialiteInSameMaisonMedicale(string message)
            : base(message) { }
    }
}
