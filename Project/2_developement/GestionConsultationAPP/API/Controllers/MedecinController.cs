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
        public IHttpActionResult Post([FromBody]Models.Medecin medecin)
        {
            return Ok(MedecinService.AddMedecin(medecin));
        }
    }
}
