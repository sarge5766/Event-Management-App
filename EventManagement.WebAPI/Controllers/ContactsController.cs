using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventManagement.WebAPI.Controllers
{
    public class ContactsController : ApiController
    {
        public IHttpActionResult Get() {
            return Ok("CONTACTS");
        }
    }
}
