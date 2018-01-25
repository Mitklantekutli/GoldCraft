using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model.GameEvents
{
    #region Events


    public class GameEvent
    {
        public long Id { get; set; }
        public GameEventType EvType { get; set; }
    }

    public class PlayerConnected : GameEvent
    {
        public Player Player { get; set; }
        public PlayerConnected()
        {
            EvType = GameEventType.PlayerConnected;
        }
    }

    public enum GameEventType
    {
        PlayerConnected,

    }

    #endregion

    public class GameEventHandler
    {
        public Game Game { get; set; }

        public void Apply(List<GameEvent> events)
        {
            events.ForEach(Apply);
        }

        public void Apply(GameEvent gevent)
        {
            switch (gevent.EvType)
            {
                case GameEventType.PlayerConnected:
                {
                    var pc = gevent as PlayerConnected;
                    Game.Players.Add(pc.Player);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public class Room
    {
        public long Id { get; set; }
        public List<Player> Players { get; set; }

        public Room()
        {
            Players = new List<Player>();
        }
    }

    public class Game
    {
        public long Id { get; set; }
        public List<Player> Players { get; set; }
        public bool Active { get; set; }

        public Game()
        {
            Players = new List<Player>();
        }
    }

    public class Player
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class PlayerGame : IMoneyOwner
    {
        public int Gold { get; set; }

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


    }

    public class Building
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public BuildingUpgrader Upgrader { get; set; }
    }

    public abstract class BuildingUpgrader
    {
        public int Cost { get; set; }

        public BuildingUpgrader(int cost)
        {
            Cost = cost;
        }

        public void Upgrade(IMoneyOwner moneyOwner)
        {
            moneyOwner.DecreaseMoney(Cost);
            IncreaseCost();
        }

        public abstract void IncreaseCost();
    }

    public class ExpBuildingUpgrader : BuildingUpgrader
    {
        private readonly int _expFactor;

        public ExpBuildingUpgrader(int cost, int expFactor):base(cost)
        {
            _expFactor = expFactor;
        }

        public override void IncreaseCost()
        {
            Cost *= _expFactor;
        }
    }

    public class AddBuildingUpgrader : BuildingUpgrader
    {
        private readonly int _addFactor;


        public AddBuildingUpgrader(int cost, int addFactor) : base(cost)
        {
            _addFactor = addFactor;
        }

        public override void IncreaseCost()
        {
            Cost += _addFactor;
        }
    }

    public interface IMoneyOwner
    {
        bool CanAfford(int amount);
        void DecreaseMoney(int amount);
    }

    public class BuildingFactory
    {
        public static Building GoldMine()
        {
            return new Building()
            {
                Level = 0,
                Name = "Шахта",
                Upgrader = new AddBuildingUpgrader(50, 50)
            };
        }

        public static Building RogueCamp()
        {
            return new Building()
            {
                Level = 0,
                Name = "Лагерь разбойников",
                Upgrader = new ExpBuildingUpgrader(100, 2)
            };
        }

        public static Building Bank()
        {
            return new Building()
            {
                Level = 0,
                Name = "Банк",
                Upgrader = new ExpBuildingUpgrader(100, 2)
            };
        }

        public static Building SpyGuild()
        {
            return new Building()
            {
                Level = 0,
                Name = "Гильдия шпионов",
                Upgrader = new ExpBuildingUpgrader(100, 2)
            };
        }

        public static Building Doghouse()
        {
            return new Building()
            {
                Level = 0,
                Name = "Собачатня",
                Upgrader = new ExpBuildingUpgrader(100, 2)
            };
        }
    }

    public class GoldMine
    {
        private readonly PlayerGame _player;

        public GoldMine(PlayerGame player)
        {
            _player = player;
        }

        public Building Building { get; set; }

        public int Income
        {
            get { return Building.Level * 10; }
        }
    }
}
