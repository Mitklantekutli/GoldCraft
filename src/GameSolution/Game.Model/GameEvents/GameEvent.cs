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

        public GameEventHandler(Game game)
        {
            Game = game;
        }

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
                    
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void OnTick(double delta)
        {
            Game.OnTick(delta);
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
        public List<PlayerGame> Players { get; set; }
        public bool Active { get; set; }

        public Game()
        {
            Players = new List<PlayerGame>();
        }

        public void OnTick(double delta)
        {
            Players.ForEach(x=>x.OnTick(delta));
        }
    }

    public class Player
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

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

    public class Building
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public BuildingUpgrader Upgrader { get; set; }
    }

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

    public class ExpBuildingUpgrader : BuildingUpgrader
    {
        private readonly int _expFactor;

        public ExpBuildingUpgrader(int cost, int expFactor, Building building) :base(cost, building)
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


        public AddBuildingUpgrader(int cost, int addFactor, Building building) : base(cost, building)
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

    public class GoldMine
    {
        public GoldMine()
        {
            Building = BuildingFactory.GoldMine();
        }

        public Building Building { get; set; }

        public int Income
        {
            get { return Building.Level * 10; }
        }
    }
}
