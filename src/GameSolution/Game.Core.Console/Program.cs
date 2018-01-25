using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Model.GameEvents;
using Game.Model.Players;

namespace Game.Core.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var core = new GameCore();
            var p = new Player() {Id = 1, Name = "QWE"};
            var pg = new PlayerGame(p);
            pg.Gold += 250;
            core.GameInstance.Players.Add(pg);
            pg.GoldMine.Building.Upgrader.Upgrade(pg);
            pg.GoldMine.Building.Upgrader.Upgrade(pg);
            core.OnTick += (s, e) =>
            {
                var cp = e.GameInstance.Players.First();
                System.Console.WriteLine(e.Time);
                System.Console.WriteLine(cp.Gold);
                System.Console.WriteLine(cp.GoldMineCurrentTimer/1000);
            };
            core.Start();
            
            System.Console.ReadLine();
        }
    }
}
