using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.BusinessServices;

namespace API.Controllers
{
    public class SpecialiteController : ApiController
    {
        public SpecialiteService SpecialiteService { get; set; }

        public SpecialiteController()
        {
            SpecialiteService = new SpecialiteService();
        }
        // GET: api/Specialite
        public IHttpActionResult Get()
        {
            var Specialites = SpecialiteService.GetAllSpecialites();
            return Ok(Specialites);
        }

        // GET: api/Specialite/5
        public IHttpActionResult Get(int id)
        {
            var Specialite = SpecialiteService.GetSpecialiteById(id);
            return Ok(Specialite);
        }

        // GET: api/Specialite/GetAllSpecialiteForMaisonMedicale/5
        [HttpGet]
        [Route("api/Specialite/GetAllSpecialiteForMaisonMedicale/{maisonMedicale_ID}")]
        public IHttpActionResult GetAllSpecialiteForMaisonMedicale(int maisonMedicale_ID)
        {
            var Specialites = SpecialiteService.GetAllSpecialiteForMaisonMedicale(maisonMedicale_ID);
            return Ok(Specialites);
        }

        // GET: api/Specialite/GetAllSpecialiteForMaisonMedicale/5
        [HttpGet]
        [Route("api/Specialite/GetSpecialiteFromMSMM/{MSMM_ID}")]
        public IHttpActionResult GetSpecialiteFromMSMM(int MSMM_ID)
        {
            var Specialites = SpecialiteService.GetSpecialiteFromMSMM(MSMM_ID);
            return Ok(Specialites);
        }
    }
}
