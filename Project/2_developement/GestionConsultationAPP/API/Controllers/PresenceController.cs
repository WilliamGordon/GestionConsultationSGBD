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

        public IHttpActionResult Post([FromBody] List<Models.Presence> presences)
        {
            try
            {
                if (Request.Headers.Contains("Origin"))
                {
                    PresenceService.HandleRequestOrigin(Request.Headers.GetValues("Origin").ToList()[0]);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Vous n'avez pas les droits pour effectuer cette requète");
                }

                return Ok(PresenceService.AddPresence(presences));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        [HttpGet]
        [Route("api/Presence/GetAllPresenceForMedecin/{medecin_ID}")]
        public IHttpActionResult GetAllPresenceForMedecin(int medecin_ID)
        {
            try
            {
                if (Request.Headers.Contains("Origin"))
                {
                    PresenceService.HandleRequestOrigin(Request.Headers.GetValues("Origin").ToList()[0]);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Vous n'avez pas les droits pour effectuer cette requète");
                }

                return Ok(PresenceService.GetAllPresenceForMedecin(medecin_ID));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }
    }
}
