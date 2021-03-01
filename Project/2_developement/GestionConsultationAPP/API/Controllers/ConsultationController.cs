using BLL.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ConsultationController : ApiController
    {
        public ConsultationService ConsultationService { get; set; }

        public ConsultationController()
        {
            ConsultationService = new ConsultationService();
        }

        // GET: api/Consultation/GetAllConsultationForPatient/5
        [HttpGet]
        [Route("api/Consultation/GetAllConsultationForPatient/{patient_ID}")]
        public IHttpActionResult GetAllSpecialiteForMedecin(int patient_ID)
        {
            var cons = ConsultationService.GetAllConsultationForPatient(patient_ID);
            return Ok(cons);
        }
    }
}
