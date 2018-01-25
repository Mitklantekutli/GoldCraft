using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Game.Server.Models;

namespace Game.Server.Controllers
{
    public class ConnectController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var ps = PlayerModule.Players;
            return Ok(ps);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var p = PlayerModule.Players.SingleOrDefault(x => x.Id == id);
            return Ok(p);
        }

        [Route("register")]
        [HttpGet]
        public IHttpActionResult Register(string pname)
        {
            var id = PlayerModule.Add(pname);
            return Ok(id);
        }

    }
}