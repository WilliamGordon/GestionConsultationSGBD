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
        // GET: api/Specialite
        public IHttpActionResult Get()
        {
            var Specialites = SpecialiteService.GetAllSpecialites();
            return Ok(Specialites);
        }

        // GET: api/Specialite/5
        public IHttpActionResult Get(int id)
        {
            var Specialite = SpecialiteService.GetSpecialiteById(id);
            return Ok(Specialite);
        }
    }
}
