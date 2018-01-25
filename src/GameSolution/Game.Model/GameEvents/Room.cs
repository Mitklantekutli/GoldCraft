using System.Collections.Generic;

namespace Game.Model.GameEvents
{
    public class Room
    {
        public long Id { get; set; }
        public List<Player> Players { get; set; }

        public Room()
        {
            Players = new List<Player>();
        }
    }
}