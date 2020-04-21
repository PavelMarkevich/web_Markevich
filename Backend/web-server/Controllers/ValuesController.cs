using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using web_server.Entities;
using web_server.Repositories.Models;

namespace web_server.Controllers
{
   // [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            using (var db = new UnitOfWork())
            {
                return Ok(db.Authors.GetAll());   
            }
           
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            //return Content(HttpStatusCode.Unauthorized, "errrrro 7855");
            return Content(HttpStatusCode.BadRequest, "erroorrr bad request");
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
