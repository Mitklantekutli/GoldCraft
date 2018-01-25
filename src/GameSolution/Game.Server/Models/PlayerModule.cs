using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Game.Model.GameEvents;

namespace Game.Server.Models
{
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
            var p = new Player() {Id = Index++, Name = player};
            Players.Add(p);
            return p.Id;
        }
    }
}