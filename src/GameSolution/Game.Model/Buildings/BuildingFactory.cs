namespace Game.Model.GameEvents
{
    public class BuildingFactory
    {
        public static Building GoldMine()
        {
            var b = new Building()
            {
                Level = 0,
                Name = "Шахта",
            };
            b.Upgrader = new AddBuildingUpgrader(50, 50, b);
            return b;
        }

        public static Building RogueCamp()
        {
            var b = new Building()
            {
                Level = 0,
                Name = "Лагерь разбойников",
            };
            b.Upgrader = new ExpBuildingUpgrader(100, 2, b);
            return b;
        }

        public static Building Bank()
        {
            var b = new Building()
            {
                Level = 0,
                Name = "Банк",
            };
            b.Upgrader = new ExpBuildingUpgrader(100, 2, b);
            return b;
        }

        public static Building SpyGuild()
        {
            var b = new Building()
            {
                Level = 0,
                Name = "Гильдия шпионов",
            };
            b.Upgrader = new ExpBuildingUpgrader(100, 2, b);
            return b;
        }

        public static Building Doghouse()
        {
            var b = new Building()
            {
                Level = 0,
                Name = "Собачатня",
            };
            b.Upgrader = new ExpBuildingUpgrader(100, 2, b);
            return b;
        }
    }
}