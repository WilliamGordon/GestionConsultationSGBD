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
        public IHttpActionResult Get()
        {
            try
            {
                if (Request.Headers.Contains("Origin"))
                {
                    SpecialiteService.HandleRequestOrigin(Request.Headers.GetValues("Origin").ToList()[0]);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Vous n'avez pas les droits pour effectuer cette requète");
                }

                return Ok(SpecialiteService.GetAllSpecialites());
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
                if (Request.Headers.Contains("Origin"))
                {
                    SpecialiteService.HandleRequestOrigin(Request.Headers.GetValues("Origin").ToList()[0]);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Vous n'avez pas les droits pour effectuer cette requète");
                }

                return Ok(SpecialiteService.GetSpecialiteById(id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        [HttpGet]
        [Route("api/Specialite/GetAllSpecialiteForMedecin/{medecin_ID}")]
        public IHttpActionResult GetAllSpecialiteForMedecin(int medecin_ID)
        {
            try
            {
                if (Request.Headers.Contains("Origin"))
                {
                    SpecialiteService.HandleRequestOrigin(Request.Headers.GetValues("Origin").ToList()[0]);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Vous n'avez pas les droits pour effectuer cette requète");
                }

                return Ok(SpecialiteService.GetAllSpecialiteForMedecin(medecin_ID));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        [HttpGet]
        [Route("api/Specialite/GetAllSpecialiteForMaisonMedicale/{maisonMedicale_ID}")]
        public IHttpActionResult GetAllSpecialiteForMaisonMedicale(int maisonMedicale_ID)
        {
            try
            {
                if (Request.Headers.Contains("Origin"))
                {
                    SpecialiteService.HandleRequestOrigin(Request.Headers.GetValues("Origin").ToList()[0]);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Vous n'avez pas les droits pour effectuer cette requète");
                }

                return Ok(SpecialiteService.GetAllSpecialiteForMaisonMedicale(maisonMedicale_ID));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        [HttpGet]
        [Route("api/Specialite/GetSpecialiteFromMSMM/{MSMM_ID}")]
        public IHttpActionResult GetSpecialiteFromMSMM(int MSMM_ID)
        {
            try
            {
                if (Request.Headers.Contains("Origin"))
                {
                    SpecialiteService.HandleRequestOrigin(Request.Headers.GetValues("Origin").ToList()[0]);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Vous n'avez pas les droits pour effectuer cette requète");
                }

                return Ok(SpecialiteService.GetSpecialiteFromMSMM(MSMM_ID));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }
    }
}
