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
        public MedecinSpecialiteController()
        {
            MedecinService = new MedecinService();
        }
        // GET: api/MedecinSpecialite
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MedecinSpecialite/5
        public string Get(int id)
        {
            return "value";
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
