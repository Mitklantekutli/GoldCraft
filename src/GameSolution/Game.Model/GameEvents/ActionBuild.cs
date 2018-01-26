using Game.Model.GameEvents.Infrastructure;
using Game.Model.Players;

namespace Game.Model.GameEvents
{
    public class ActionBuild : GameEvent
    {
        public Player Player { get; set; }
        public StructureType Structure { get; set; }

        public ActionBuild(Player player, StructureType structure)
        {
            Player = player;
            Structure = structure;
            EvType = GameEventType.ActionBuild;
        }
    }

    
}
