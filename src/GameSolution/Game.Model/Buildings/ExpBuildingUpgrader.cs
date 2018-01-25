namespace Game.Model.Buildings
{
    public class ExpBuildingUpgrader : BuildingUpgrader
    {
        private readonly int _expFactor;

        public ExpBuildingUpgrader(int cost, int expFactor, Building building) :base(cost, building)
        {
            _expFactor = expFactor;
        }

        public override void IncreaseCost()
        {
            Cost *= _expFactor;
        }
    }
}