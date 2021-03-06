﻿using BLL.BusinessServices;
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

        // GET: api/Consultation/5
        public IHttpActionResult Get(int id)
        {
            var medecin = ConsultationService.GetConsultationById(id);
            return Ok(medecin);
        }

        // POST: api/Consultation
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

        // GET: api/Consultation/GetAllConsultationForMedecin/5
        [HttpGet]
        [Route("api/Consultation/GetAllConsultationForMedecin/{medecin_ID}")]
        public IHttpActionResult GetAllConsultationForMedecin(int medecin_ID)
        {
            var cons = ConsultationService.GetAllConsultationForMedecin(medecin_ID);
            return Ok(cons);
        }

        // GET: api/Consultation/GetAllConsultationForPatient/5
        [HttpGet]
        [Route("api/Consultation/GetAllConsultationForPatient/{patient_ID}")]
        public IHttpActionResult GetAllSpecialiteForMedecin(int patient_ID)
        {
            var cons = ConsultationService.GetAllConsultationForPatient(patient_ID);
            return Ok(cons);
        }

        // GET: api/Consultation/GetAllConsultationForPatient/5
        [HttpGet]
        [Route("api/Consultation/GetAllPossibleConsultation/{medecin_ID}/{maisonMedicale_ID}/{day}/{specialite_ID}/{patient_ID}")]
        public IHttpActionResult GetAllSpecialiteForMedecin(int medecin_ID, int maisonMedicale_ID, DateTime day, int specialite_ID, int patient_ID)
        {
            try
            {
                return Ok(ConsultationService.GetAllPossibleConsultation(medecin_ID, maisonMedicale_ID, day, specialite_ID, patient_ID));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        // POST: api/Consultation/ConfirmConsultation/5
        [HttpPost]
        [Route("api/Consultation/ConfirmConsultation")]
        public IHttpActionResult ConfirmConsultation([FromBody] Models.Consultation consultation)
        {
            var cons = ConsultationService.ConfirmConsultation(consultation.Consultation_ID);
            return Ok(cons);
        }

        // POST: api/Consultation/ConfirmConsultation/5
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

    }
}
