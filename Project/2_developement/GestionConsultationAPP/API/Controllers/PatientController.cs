using BLL.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class PatientController : ApiController
    {
        public PatientService PatientService { get; set; }
        public PatientController()
        {
            PatientService = new PatientService();
        }

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(PatientService.GetAllPatients());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(PatientService.GetPatientById(id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        public IHttpActionResult Post([FromBody] Models.Patient patient)
        {
            try
            {
                return Ok(PatientService.AddPatient(patient));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }
    }
}
