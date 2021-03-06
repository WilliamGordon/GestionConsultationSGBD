using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CustomErrors
{
    public class PatientAlreadyHasAConsultationInAnotherMaisonMedicaleException: Exception
    {
        public PatientAlreadyHasAConsultationInAnotherMaisonMedicaleException(string message) 
            : base(message) { }
    }
}
