using Game.Model.Buildings;
using Game.Model.GameEvents;

namespace Game.Model.Players
{
    public class PlayerGame : IMoneyOwner
    {
        public Player Player { get; set; }
        public int Gold { get; set; }

        #region Timers

        #endregion

        public PlayerGame(Player player)
        {
            Player = player;
            GoldMine = new GoldMine(this);
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
            GoldMine.OnTick(delta);
        }
    }
}