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

        public IHttpActionResult Get(int id)
        {
            try
            {
                if (Request.Headers.Contains("Origin"))
                {
                    MSMMService.HandleRequestOrigin(Request.Headers.GetValues("Origin").ToList()[0]);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Vous n'avez pas les droits pour effectuer cette requète");
                }

                return Ok(MSMMService.GetMSMMById(id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        public IHttpActionResult Post([FromBody] Models.MedecinSpecialiteMaisonMedicale MSMM)
        {
            try
            {
                if (Request.Headers.Contains("Origin"))
                {
                    MSMMService.HandleRequestOrigin(Request.Headers.GetValues("Origin").ToList()[0]);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Vous n'avez pas les droits pour effectuer cette requète");
                }

                return Ok(MSMMService.AddMedecinSpecialiteMaisonMedicale(MSMM));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        public IHttpActionResult Put([FromBody] Models.MedecinSpecialiteMaisonMedicale MSMM)
        {
            try
            {
                if (Request.Headers.Contains("Origin"))
                {
                    MSMMService.HandleRequestOrigin(Request.Headers.GetValues("Origin").ToList()[0]);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Vous n'avez pas les droits pour effectuer cette requète");
                }

                return Ok(MSMMService.UpdateMedecinSpecialiteMaisonMedicale(MSMM));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        [HttpGet]
        [Route("api/MedecinSpecialiteMaisonMedicale/GetAllMMSForMedecin/{medecin_ID}")]
        public IHttpActionResult GetAllMMSForMedecin(int medecin_ID)
        {
            try
            {
                if (Request.Headers.Contains("Origin"))
                {
                    MSMMService.HandleRequestOrigin(Request.Headers.GetValues("Origin").ToList()[0]);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Vous n'avez pas les droits pour effectuer cette requète");
                }

                return Ok(MSMMService.GetAllMSMMForMedecin(medecin_ID));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }
    }
}
