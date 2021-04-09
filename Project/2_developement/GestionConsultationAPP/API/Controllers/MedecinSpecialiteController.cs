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
        public MedecinSpecialiteService MedecinSpecialiteService { get; set; }
        public MedecinSpecialiteController()
        {
            MedecinSpecialiteService = new MedecinSpecialiteService();
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                if (Request.Headers.Contains("Origin"))
                {
                    MedecinSpecialiteService.HandleRequestOrigin(Request.Headers.GetValues("Origin").ToList()[0]);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Vous n'avez pas les droits pour effectuer cette requète");
                }

                return Ok(MedecinSpecialiteService.GetMedecinSpecialitebyId(id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        public IHttpActionResult Post([FromBody] Models.MedecinSpecialite MedecinSpecialite)
        {
            try
            {
                if (Request.Headers.Contains("Origin"))
                {
                    MedecinSpecialiteService.HandleRequestOrigin(Request.Headers.GetValues("Origin").ToList()[0]);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Vous n'avez pas les droits pour effectuer cette requète");
                }

                return Ok(MedecinSpecialiteService.AddMedecinSpecialite(MedecinSpecialite));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        [HttpGet]
        [Route("api/MedecinSpecialite/GetAllMedecinSpecialiteForMedecin/{medecin_ID}")]
        public IHttpActionResult GetAllMedecinSpecialiteForMedecin(int medecin_ID)
        {
            try
            {
                if (Request.Headers.Contains("Origin"))
                {
                    MedecinSpecialiteService.HandleRequestOrigin(Request.Headers.GetValues("Origin").ToList()[0]);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Vous n'avez pas les droits pour effectuer cette requète");
                }

                return Ok(MedecinSpecialiteService.GetAllMedecinSpecialiteForMedecin(medecin_ID));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

    }
}
