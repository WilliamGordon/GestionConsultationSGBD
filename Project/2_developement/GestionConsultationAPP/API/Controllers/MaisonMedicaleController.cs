using BLL.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class MaisonMedicaleController : ApiController
    {
        public MaisonMedicaleService MaisonMedicaleService { get; set; }

        public MaisonMedicaleController()
        {
            MaisonMedicaleService = new MaisonMedicaleService();
        }

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(MaisonMedicaleService.GetAllMaisonMedicales());
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
                return Ok(MaisonMedicaleService.GetMaisonMedicaleById(id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        [HttpGet]
        [Route("api/MaisonMedicale/GetAllMaisonMedicaleForMedecin/{medecin_ID}")]
        public IHttpActionResult GetAllSpecialiteForMedecin(int medecin_ID)
        {
            try
            {
                return Ok(MaisonMedicaleService.GetAllMaisonMedicaleForMedecin(medecin_ID));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }

        [HttpGet]
        [Route("api/MaisonMedicale/GetMaisonMedicaleFromMSMM/{MSMM_ID}")]
        public IHttpActionResult GetMaisonMedicaleFromMSMM(int MSMM_ID)
        {
            try
            {
                return Ok(MaisonMedicaleService.GetMaisonMedicaleFromMSMM(MSMM_ID));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }
    }
}
