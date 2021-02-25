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
        // GET: api/Medecin
        public IHttpActionResult Get()
        {
            var medecins = MedecinService.GetAllMedecins();
            return Ok(medecins);
        }

        // GET: api/Medecin/5
        public IHttpActionResult Get(int id)
        {
            var medecin = MedecinService.GetMedecinById(id);
            return Ok(medecin);
        }

        // POST: api/Medecin
        public IHttpActionResult Post([FromBody] Models.Medecin medecin)
        {
            return Ok(MedecinService.AddMedecin(medecin));
        }

        // GET: api/Medecin/GetAllSpecialiteForMedecin/5
        [HttpGet]
        [Route("Medecin/GetAllSpecialiteForMedecin/{medecin_ID}")]
        public IHttpActionResult GetAllSpecialiteForMedecin(int medecin_ID)
        {
            var medecins = MedecinService.GetAllSpecialiteForMedecin(medecin_ID);
            return Ok(medecins);
        }

        // POST: api/Medecin/AddSpecialiteForMedecin/Specialite_ID/Medecin_ID
        [HttpPost]
        [Route("Medecin/AddSpecialiteForMedecin/{specialite_ID}/{medecin_ID}")]
        public IHttpActionResult AddSpecialiteForMedecin([FromBody] Models.MedecinSpecialite medspec)
        {
            return Ok(MedecinService.AddSpecialiteForMedecin(medspec));
        }

    }
}
