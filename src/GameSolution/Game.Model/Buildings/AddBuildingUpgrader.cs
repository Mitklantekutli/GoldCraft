namespace Game.Model.GameEvents
{
    public class AddBuildingUpgrader : BuildingUpgrader
    {
        private readonly int _addFactor;


        public AddBuildingUpgrader(int cost, int addFactor, Building building) : base(cost, building)
        {
            _addFactor = addFactor;
        }

        public override void IncreaseCost()
        {
            Cost += _addFactor;
        }
    }
}