using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Game.Model.GameEvents;

namespace Game.Api.Controllers
{
    public class PlayerController : ApiController
    {
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