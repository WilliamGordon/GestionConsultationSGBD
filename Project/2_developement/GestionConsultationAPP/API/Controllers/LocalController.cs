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
                if (Request.Headers.Contains("Origin"))
                {
                    LocalService.HandleRequestOrigin(Request.Headers.GetValues("Origin").ToList()[0]);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Vous n'avez pas les droits pour effectuer cette requète");
                }

                return Ok(LocalService.GetLocalById(id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.GetBaseException().Message);
            }
        }
    }
}
