using Game.Model.GameEvents.Infrastructure;
using Game.Model.Players;

namespace Game.Model.GameEvents
{
    public class PlayerConnected : GameEvent
    {
        public Player Player { get; set; }
        public PlayerConnected(Player player)
        {
            Player = player;
            EvType = GameEventType.PlayerConnected;
        }
    }
}