using Game.Model.Buildings;
using Game.Model.GameEvents;

namespace Game.Model.Players
{
    public class PlayerGame : IMoneyOwner
    {
        public Player Player { get; set; }
        public int Gold { get; set; }
        public int Dogs { get; set; }
        public int Rogues { get; set; }
        public int Spies { get; set; }


        public PlayerGame(Player player)
        {
            Player = player;
            GoldMine = new GoldMine(this);
            RogueCamp = new RogueCamp(this);
            SpyCamp = new SpyCamp(this);
            Doghouse = new Doghouse(this);
            Bank = new Bank();
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
        public RogueCamp RogueCamp { get; set; }
        public SpyCamp SpyCamp { get; set; }
        public Doghouse Doghouse { get; set; }
        public Bank Bank { get; set; }


        public void OnTick(double delta)
        {
            GoldMine.OnTick(delta);
            RogueCamp.OnTick(delta);
            SpyCamp.OnTick(delta);
            Doghouse.OnTick(delta);
        }
    }
}