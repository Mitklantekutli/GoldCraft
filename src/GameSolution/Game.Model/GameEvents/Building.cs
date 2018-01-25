namespace Game.Model.GameEvents
{
    public class Building
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public BuildingUpgrader Upgrader { get; set; }
    }
}