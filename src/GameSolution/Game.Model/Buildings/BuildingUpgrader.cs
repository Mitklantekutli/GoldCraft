namespace Game.Model.GameEvents
{
    public abstract class BuildingUpgrader
    {
        private readonly Building _building;
        public int Cost { get; set; }

        public BuildingUpgrader(int cost, Building building)
        {
            _building = building;
            Cost = cost;
        }

        public void Upgrade(IMoneyOwner moneyOwner)
        {
            moneyOwner.DecreaseMoney(Cost);
            IncreaseCost();
            _building.Level++;
        }

        public abstract void IncreaseCost();
    }
}