using Game.Model.Players;

namespace Game.Model.Buildings
{
    public class GoldMine : TickBuilding
    {
        public const double GoldMineTimer = 5 * 1000;
        private readonly PlayerGame _game;


        public GoldMine(PlayerGame game):base(GoldMineTimer)
        {
            _game = game;
            Building = BuildingFactory.GoldMine();
        }

        public Building Building { get; set; }

        public int Income
        {
            get { return Building.Level * 10; }
        }

        public override void OnEvent()
        {
            _game.Gold += Income;
        }
    }
}