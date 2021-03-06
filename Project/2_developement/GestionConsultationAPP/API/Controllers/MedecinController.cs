﻿using BLL.BusinessServices;
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
            try
            {
                return Ok(MedecinService.AddMedecin(medecin));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
            
        }

        // GET: api/Medecin/GetAllSpecialiteForMedecin/5
        [HttpGet]
        [Route("api/Medecin/GetAllSpecialiteForMedecin/{medecin_ID}")]
        public IHttpActionResult GetAllSpecialiteForMedecin(int medecin_ID)
        {
            var medecins = MedecinService.GetAllSpecialiteForMedecin(medecin_ID);
            return Ok(medecins);
        }

        // GET: api/Medecin/GetAll/5
        [HttpGet]
        [Route("api/Medecin/GetAllMedecinPresentForMaisonMedicaleAndSpecialiteAndDay/{day}/{maisonMedicale_ID}/{specialite_ID}")]
        public IHttpActionResult GetAllMedecinPresentForMaisonMedicaleAndSpecialiteAndDay(DateTime day, int maisonMedicale_ID, int specialite_ID)
        {
            var medecins = MedecinService.GetAllMedecinPresentForMaisonMedicaleAndSpecialiteAndDay(day, maisonMedicale_ID, specialite_ID);
            if (medecins.Count >= 1)
            {
                return Ok(medecins);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "No medecin available for this date");
            }

            
        }

        // GET: api/Medecin/GetAll/5
        [HttpGet]
        [Route("api/Medecin/GetMedecinFromMSMM/{msmm_ID}")]
        public IHttpActionResult GetMedecinFromMSMM(int msmm_ID)
        {
            var medecin = MedecinService.GetMedecinFromMSMM(msmm_ID);
            return Ok(medecin);
        }
    }
}
