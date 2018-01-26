using Game.Model.GameEvents.Infrastructure;
using Game.Model.Players;

namespace Game.Model.GameEvents
{
    public class PlayerFieldChanged : GameEvent
    {
        public Player Player { get; set; }
        public int Delta { get; set; }
        public PlayerFieldType Field { get; set; }

        public PlayerFieldChanged(Player player, int delta, PlayerFieldType field)
        {
            Player = player;
            Delta = delta;
            Field = field;
            EvType = GameEventType.PlayerFieldChanged;
        }
    }

    public enum PlayerFieldType
    {
        Gold,
        Dog,
        Rogue,
        Spy,
    }
}