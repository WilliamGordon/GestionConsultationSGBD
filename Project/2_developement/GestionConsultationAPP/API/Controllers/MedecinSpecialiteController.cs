using BLL.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class MedecinSpecialiteController : ApiController
    {
        public MedecinService MedecinService { get; set; }
        public MedecinSpecialiteService MSService { get; set; }
        public MedecinSpecialiteController()
        {
            MedecinService = new MedecinService();
            MSService = new MedecinSpecialiteService();
        }
        // GET: api/MedecinSpecialite
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MedecinSpecialite/5
        public IHttpActionResult Get(int id)
        {
            Models.MedecinSpecialite MS = new Models.MedecinSpecialite();
            MS = MSService.GetMedecinSpecialitebyId(id);
            return Ok(MS);
        }

        // GET: api/Medecin/GetAllSpecialiteForMedecin/5
        [HttpGet]
        [Route("api/MedecinSpecialite/GetAllMedecinSpecialiteForMedecin/{medecin_ID}")]
        public IHttpActionResult GetAllMedecinSpecialiteForMedecin(int medecin_ID)
        {
            var medecins = MSService.GetAllMedecinSpecialiteForMedecin(medecin_ID);
            return Ok(medecins);
        }

        // POST: api/MedecinSpecialite
        public IHttpActionResult Post([FromBody]Models.MedecinSpecialite MedecinSpecialite)
        {
            try
            {
                return Ok(MedecinService.AddSpecialiteForMedecin(MedecinSpecialite));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
           
        }

        // PUT: api/MedecinSpecialite/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MedecinSpecialite/5
        public void Delete(int id)
        {
        }
    }
}
