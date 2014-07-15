using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FVTest.Models;

namespace FVTest.Controllers
{
    public class MyObjectController : ApiController
    {
        // POST: api/MyObject
        public IHttpActionResult Post(MyObject _MyObject)
        {
            return Ok();
        }
    }
}
