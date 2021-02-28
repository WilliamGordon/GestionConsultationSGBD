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

        // GET: api/Medecin
        public IHttpActionResult Get()
        {
            var patients = PatientService.GetAllPatients();
            return Ok(patients);
        }

        // GET: api/Medecin/5
        public IHttpActionResult Get(int id)
        {
            var patient = PatientService.GetPatientById(id);
            return Ok(patient);
        }

        // POST: api/Medecin
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
