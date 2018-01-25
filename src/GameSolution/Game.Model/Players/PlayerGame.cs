namespace Game.Model.GameEvents
{
    public class PlayerGame : IMoneyOwner
    {
        public Player Player { get; set; }
        public int Gold { get; set; }

        #region Timers

        public const double GoldMineTimer = 5*1000;
        public double GoldMineCurrentTimer = GoldMineTimer;

        #endregion

        public PlayerGame(Player player)
        {
            Player = player;
            GoldMine = new GoldMine();
        }

        #region Money

        public bool CanAfford(int amount)
        {
            return amount <= Gold;
        }

        public void DecreaseMoney(int amount)
        {
            Gold -= amount;
        }

        #endregion

        public GoldMine GoldMine { get; set; }

        public void OnTick(double delta)
        {
            GoldMineCurrentTimer -= delta;
            if (GoldMineCurrentTimer <= 0)
            {
                GoldMineCurrentTimer = GoldMineTimer;
                Gold += GoldMine.Income;
            }
        }
    }
}