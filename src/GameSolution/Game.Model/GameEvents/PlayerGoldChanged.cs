namespace Game.Model.GameEvents
{
    public class PlayerGoldChanged : GameEvent
    {
        public Player Player { get; set; }
        public int Delta { get; set; }

        public PlayerGoldChanged(Player player)
        {
            Player = player;
            EvType = GameEventType.PlayerGoldChanged;
        }
    }
}