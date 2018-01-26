using Game.Model.GameEvents.Infrastructure;

namespace Game.Core
{
    public class GameController
    {
        private readonly GameCore _core;

        public GameController(GameCore core)
        {
            _core = core;
        }
        public void BuildGoldMine(long playerId)
        {
            var p = _core.GetPlayer(playerId);
            var ge = GameEventFactory.BuildMine(p);
            _core.AddEvent(ge);
        }

        public void BuildRogueCamp(long playerId)
        {
            var p = _core.GetPlayer(playerId);
            var ge = GameEventFactory.BuildRogueCamp(p);
            _core.AddEvent(ge);
        }

        public void BuildSpyCamp(long playerId)
        {
            var p = _core.GetPlayer(playerId);
            var ge = GameEventFactory.BuildSpyCamp(p);
            _core.AddEvent(ge);
        }

        public void BuildDoghouse(long playerId)
        {
            var p = _core.GetPlayer(playerId);
            var ge = GameEventFactory.BuildDoghouse(p);
            _core.AddEvent(ge);
        }

        public void BuildBank(long playerId)
        {
            var p = _core.GetPlayer(playerId);
            var ge = GameEventFactory.BuildBank(p);
            _core.AddEvent(ge);
        }
    }
}
