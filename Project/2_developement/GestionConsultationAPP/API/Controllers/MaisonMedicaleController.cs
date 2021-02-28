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
        public MaisonMedicaleService MMService { get; set; }

        public MaisonMedicaleController()
        {
            MMService = new MaisonMedicaleService();
        }
        // GET: api/MaisonMedicale
        public IHttpActionResult Get()
        {
            var MM = MMService.GetAllMaisonMedicales();
            return Ok(MM);
        }

        // GET: api/MaisonMedicale/GetAllMaisonMedicaleForMedecin/5
        [HttpGet]
        [Route("api/MaisonMedicale/GetAllMaisonMedicaleForMedecin/{medecin_ID}")]
        public IHttpActionResult GetAllSpecialiteForMedecin(int medecin_ID)
        {
            var MMs = MMService.GetAllMaisonMedicaleForMedecin(medecin_ID);
            return Ok(MMs);
        }

        // GET: api/MaisonMedicale/5
        public IHttpActionResult Get(int id)
        {
            var MM = MMService.GetMaisonMedicaleById(id);
            return Ok(MM);
        }
    }
}
