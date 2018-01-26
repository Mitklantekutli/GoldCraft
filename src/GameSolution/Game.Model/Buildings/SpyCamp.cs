using Game.Model.Players;

namespace Game.Model.Buildings
{
    public class SpyCamp : TickBuilding
    {
        public const double Timer = 5 * 1000;
        private readonly PlayerGame _game;

        public SpyCamp(PlayerGame game) : base(Timer)
        {
            _game = game;
            Building = BuildingFactory.GoldMine();
        }

        public int Income
        {
            get { return Building.Level; }
        }

        public override void OnEvent()
        {
            _game.Spies += Income;
        }
    }
}
