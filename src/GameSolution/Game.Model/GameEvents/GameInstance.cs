using System.Collections.Generic;

namespace Game.Model.GameEvents
{
    public class GameInstance
    {
        public long Id { get; set; }
        public List<PlayerGame> Players { get; set; }
        public bool Active { get; set; }

        public GameInstance()
        {
            Players = new List<PlayerGame>();
        }

        public void OnTick(double delta)
        {
            Players.ForEach(x=>x.OnTick(delta));
        }
    }
}