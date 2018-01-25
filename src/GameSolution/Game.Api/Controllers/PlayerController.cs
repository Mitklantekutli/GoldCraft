using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Game.Model.GameEvents;
using Game.Model.Players;

namespace Game.Api.Controllers
{
    [RoutePrefix("api")]
    public class PlayerController : ApiController
    {
        [Route("player")]
        public IHttpActionResult Get()
        {
            var ps = PlayerModule.Players;
            return Ok(ps.ToArray());
        }
        [Route("player/{id}")]
        public IHttpActionResult Get(int id)
        {
            var p = PlayerModule.Players.SingleOrDefault(x => x.Id == id);
            return Ok(p);
        }

        [Route("player/register")]
        [HttpGet]
        public IHttpActionResult Register(string name)
        {
            var id = PlayerModule.Add(name);
            return Ok(id);
        }
    }

    public static class PlayerModule
    {
        private static int Index { get; set; }
        public static List<Player> Players { get; set; }
        static PlayerModule()
        {
            Players = new List<Player>();
            Index = 1;
        }

        public static long Add(string player)
        {
            var p = new Player() { Id = Index++, Name = player };
            Players.Add(p);
            return p.Id;
        }
    }
}