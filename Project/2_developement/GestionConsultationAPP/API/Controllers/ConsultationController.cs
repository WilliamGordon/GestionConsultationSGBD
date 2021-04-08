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

        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(ConsultationService.GetConsultationById(id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        public IHttpActionResult Post([FromBody] Models.Consultation consultation)
        {
            try
            {
                return Ok(ConsultationService.AddConsultation(consultation));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }

        }
        [HttpGet]
        [Route("api/Consultation/GetAllConsultationForMedecin/{medecin_ID}")]
        public IHttpActionResult GetAllConsultationForMedecin(int medecin_ID)
        {
            try
            {
                return Ok(ConsultationService.GetAllConsultationForMedecin(medecin_ID));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        [HttpGet]
        [Route("api/Consultation/GetAllConsultationForPatient/{patient_ID}")]
        public IHttpActionResult GetAllConsultationForPatient(int patient_ID)
        {
            try
            {
                return Ok(ConsultationService.GetAllConsultationForPatient(patient_ID));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        [HttpPost]
        [Route("api/Consultation/ConfirmConsultation")]
        public IHttpActionResult ConfirmConsultation([FromBody] Models.Consultation consultation)
        {
            try
            {
                return Ok(ConsultationService.ConfirmConsultation(consultation.Consultation_ID));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        [HttpPost]
        [Route("api/Consultation/UpdateConsultation")]
        public IHttpActionResult UpdateConsultation([FromBody] Models.Consultation consultation)
        {
            try
            {
                return Ok(ConsultationService.UpdateConsultation(consultation));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        [HttpPost]
        [Route("api/Consultation/DeleteConsultation")]
        public IHttpActionResult DeleteConsultation([FromBody] Models.Consultation consultation)
        {
            try
            {
                ConsultationService.DeleteConsultation(consultation);
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        [HttpGet]
        [Route("api/Consultation/GetAllPossibleConsultation/{medecin_ID}/{maisonMedicale_ID}/{day}/{specialite_ID}/{patient_ID}/{consultation_ID}")]
        public IHttpActionResult GetAllPossibleConsultation(int medecin_ID, int maisonMedicale_ID, DateTime day, int specialite_ID, int patient_ID, int consultation_ID)
        {
            try
            {
                return Ok(ConsultationService.GetAllPossibleConsultation(medecin_ID, maisonMedicale_ID, day, specialite_ID, patient_ID, consultation_ID));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }
    }
}
