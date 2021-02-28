using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class PresenceController : ApiController
    {
        public BLL.BusinessServices.PresenceService PresenceService { get; set; }
        public PresenceController()
        {
            PresenceService = new BLL.BusinessServices.PresenceService();
        }
        // GET: api/Presence/GetAllPresenceForMedecin/5
        [HttpGet]
        [Route("api/Presence/GetAllPresenceForMedecin/{medecin_ID}")]
        public IHttpActionResult GetAllPresenceForMedecin(int medecin_ID)
        {
            var pres = PresenceService.GetAllPresenceForMedecin(medecin_ID);
            return Ok(pres);
        }

        // POST: api/Presence
        public IHttpActionResult Post([FromBody] List<Models.Presence> presences)
        {
            try
            {
                return Ok(PresenceService.AddPresence(presences));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }

        }
    }
}
