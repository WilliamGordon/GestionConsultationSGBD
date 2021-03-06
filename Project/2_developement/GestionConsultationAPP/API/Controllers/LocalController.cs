using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class LocalController : ApiController
    {
        public BLL.BusinessServices.LocaLService LocalService { get; set; }
        public LocalController()
        {
            LocalService = new BLL.BusinessServices.LocaLService();
        }

        // GET: api/Local/5
        public IHttpActionResult Get(int id)
        {
            var patient = LocalService.GetLocalById(id);
            return Ok(patient);
        }
    }
}
