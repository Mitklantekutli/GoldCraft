using Game.Model.Players;

namespace Game.Model.Buildings
{
    public class Doghouse : TickBuilding
    {
        private readonly PlayerGame _game;
        public const double Timer = 5 * 1000;
        public Doghouse(PlayerGame game) : base(Timer)
        {
            _game = game;
            Building = BuildingFactory.Doghouse();
        }

        public int Income
        {
            get { return Building.Level; }
        }

        public override void OnEvent()
        {
            _game.Dogs += Income;
        }
    }
}
