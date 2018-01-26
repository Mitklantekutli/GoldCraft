using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Model.Players;

namespace Game.Model.Buildings
{
    public class Bank
    {
        public Building Building { get; set; }

        public Bank() 
        {
            Building = BuildingFactory.Doghouse();
        }

        public int SavedGold { get; set; }

        public int MaxGold
        {
            get { return Building.Level * 100; }
        }
    }
}
