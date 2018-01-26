using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Model.Players;

namespace Game.Model.GameEvents.Infrastructure
{
    public static class GameEventFactory
    {
        #region Building

        public static GameEvent BuildMine(Player player)
        {
            var p = new ActionBuild(player, StructureType.Mine);
            return p;
        }
        public static GameEvent BuildRogueCamp(Player player)
        {
            var p = new ActionBuild(player, StructureType.RogueCamp);
            return p;
        }
        public static GameEvent BuildSpyCamp(Player player)
        {
            var p = new ActionBuild(player, StructureType.SpyCamp);
            return p;
        }
        public static GameEvent BuildDoghouse(Player player)
        {
            var p = new ActionBuild(player, StructureType.Doghouse);
            return p;
        }

        public static GameEvent BuildBank(Player player)
        {
            var p = new ActionBuild(player, StructureType.Bank);
            return p;
        }
        #endregion
    }
}
