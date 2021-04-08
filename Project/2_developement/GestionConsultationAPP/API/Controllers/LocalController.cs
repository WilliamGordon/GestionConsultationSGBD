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

        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(LocalService.GetLocalById(id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }
    }
}
