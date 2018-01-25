using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Game.Model.GameEvents;
using Game.Model.Players;

namespace Game.Api.Controllers
{
    [RoutePrefix("api/room")]
    public class RoomController : ApiController
    {
        [Route("create")]
        public IHttpActionResult Create()
        {
            var id = RoomModule.CreateRoom();
            return Ok(id);
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            var r = RoomModule.Get();
            return Ok(r);
        }

        [Route("{id}")]
        public IHttpActionResult GetById(long id)
        {
            var r = RoomModule.Get(id);
            return Ok(r);
        }

        [Route("join/{roomNumber}/{playerNumber}")]
        public IHttpActionResult JoinRoom(int roomNumber, int playerNumber)
        {
            RoomModule.JoinRoom(roomNumber, playerNumber);
            return Ok();
        }

        [Route("leave/{roomNumber}/{playerNumber}")]
        public IHttpActionResult LeaveRoom(int roomNumber, int playerNumber)
        {
            RoomModule.LeaveRoom(roomNumber, playerNumber);
            return Ok();
        }

        [Route("kick/{roomNumber}/{playerNumber}")]
        public IHttpActionResult KickPlayer(int roomNumber, int playerNumber)
        {
            RoomModule.LeaveRoom(roomNumber, playerNumber);
            return Ok();
        }
    }

    public static class RoomModule
    {
        private static int Index { get; set; }
        public static List<Room> Rooms { get; set; }

        static RoomModule()
        {
            Rooms = new List<Room>();
        }

        public static Dictionary<long, int> Get()
        {
            return Rooms.ToDictionary(x=>x.Id, x=>x.Players.Count);
        }

        public static Room Get(long id)
        {
            return Rooms.SingleOrDefault(x => x.Id == id);
        }

        public static int CreateRoom()
        {
            var id = Index++;
            Rooms.Add(new Room(){Id = id, Players = new List<Player>()});
            return id;
        }

        public static void JoinRoom(int roomNumber, int playerNumber)
        {
            var player = PlayerModule.Players.Single(x => x.Id == playerNumber);
            var room = Rooms.Single(x => x.Id == roomNumber);
            room.Players.Add(player);
        }

        public static void LeaveRoom(int roomNumber, int playerNumber)
        {
            var room = Rooms.Single(x => x.Id == roomNumber);
            var player = PlayerModule.Players.Single(x => x.Id == playerNumber);
            room.Players = room.Players.Except(new List<Player>(){player}).ToList();
        }

        public static void KickPlayer(int roomNumber, int playerNumber)
        {
            var room = Rooms.Single(x => x.Id == roomNumber);
            var player = PlayerModule.Players.Single(x => x.Id == playerNumber);
            room.Players = room.Players.Except(new List<Player>() { player }).ToList();
        }

    }
}
