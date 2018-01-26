using Game.Model.GameEvents.Infrastructure;
using Game.Model.Players;

namespace Game.Model.GameEvents
{
    public class PlayerBuildingUpgraded : GameEvent
    {
        public Player Player { get; set; }
        public StructureType Structure { get; set; }

        public PlayerBuildingUpgraded(Player player, StructureType structure)
        {
            Player = player;
            Structure = structure;
            EvType = GameEventType.PlayerFieldChanged;
        }
    }

    public enum StructureType
    {
        Mine,
        RogueCamp,
        SpyCamp,
        Doghouse,
        Bank
    }
}
