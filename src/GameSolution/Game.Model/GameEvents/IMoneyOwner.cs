namespace Game.Model.GameEvents
{
    public interface IMoneyOwner
    {
        bool CanAfford(int amount);
        void DecreaseMoney(int amount);
    }
}