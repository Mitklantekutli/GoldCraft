namespace Game.Model.Buildings
{
    public class GoldMine
    {
        public GoldMine()
        {
            Building = BuildingFactory.GoldMine();
        }

        public Building Building { get; set; }

        public int Income
        {
            get { return Building.Level * 10; }
        }
    }
}