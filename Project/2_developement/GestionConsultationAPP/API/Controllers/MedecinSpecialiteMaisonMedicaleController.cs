using BLL.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class MedecinSpecialiteMaisonMedicaleController : ApiController
    {
        public MedecinSpecialiteMaisonMedicaleService MSMMService { get; set; }
        public MedecinSpecialiteMaisonMedicaleController()
        {
            MSMMService = new MedecinSpecialiteMaisonMedicaleService();
        }

        // GET: api/MedecinSpecialiteMaisonMedicale/5
        public IHttpActionResult Get(int id)
        {
            var medecin = MSMMService.GetMSMMById(id);
            return Ok(medecin);
        }
        // GET: api/Medecin/GetAllSpecialiteForMedecin/5
        [HttpGet]
        [Route("api/MedecinSpecialiteMaisonMedicale/GetAllMMSForMedecin/{medecin_ID}")]
        public IHttpActionResult GetAllMMSForMedecin(int medecin_ID)
        {
            var MSMM = MSMMService.GetAllMSMMForMedecin(medecin_ID);
            return Ok(MSMM);
        }

        // POST: api/MedecinSpecialiteMaisonMedicale
        public IHttpActionResult Post([FromBody] Models.MedecinSpecialiteMaisonMedicale MSMM)
        {
            try
            {
                return Ok(MSMMService.AddMSMM(MSMM));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        // PUT: api/MedecinSpecialiteMaisonMedicale/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MedecinSpecialiteMaisonMedicale/5
        public void Delete(int id)
        {
        }
    }
}
