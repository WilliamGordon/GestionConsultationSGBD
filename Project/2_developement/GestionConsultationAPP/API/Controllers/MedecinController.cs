using BLL.BusinessServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace API.Controllers
{
    public class MedecinController : ApiController
    {
        public MedecinService MedecinService { get; set; }

        public MedecinController()
        {
            MedecinService = new MedecinService();
        }
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(MedecinService.GetAllMedecins());
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
                return Ok(MedecinService.GetMedecinById(id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        public IHttpActionResult Post([FromBody] Models.Medecin medecin)
        {
            try
            {
                return Ok(MedecinService.AddMedecin(medecin));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        [HttpGet]
        [Route("api/Medecin/GetMedecinFromMSMM/{msmm_ID}")]
        public IHttpActionResult GetMedecinFromMSMM(int msmm_ID)
        {
            try
            {
                return Ok(MedecinService.GetMedecinFromMSMM(msmm_ID));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        [HttpGet]
        [Route("api/Medecin/GetAllMedecinForMaisonMedicaleAndSpecialite/{maisonMedicale_ID}/{specialite_ID}")]
        public IHttpActionResult GetAllMedecinForMaisonMedicaleAndSpecialite(int maisonMedicale_ID, int specialite_ID)
        {
            try
            {
                var medecins = MedecinService.GetAllMedecinForMaisonMedicaleAndSpecialite(maisonMedicale_ID, specialite_ID);
                if (medecins.Count >= 1)
                {
                    return Ok(medecins);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Aucun médecin ne pratique cette spécialité");
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }
    }
}
