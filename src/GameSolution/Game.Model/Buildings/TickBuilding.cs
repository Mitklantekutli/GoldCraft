using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model.Buildings
{
    public abstract class TickBuilding
    {
        public double RefreshTime = 5 * 1000;
        public double RefreshTimeLeft = 5 * 1000;

        protected TickBuilding(double time)
        {
            RefreshTime = time;
            RefreshTimeLeft = time;
        }

        public void OnTick(double delta)
        {
            RefreshTimeLeft -= delta;
            if (RefreshTimeLeft <= 0)
            {
                RefreshTimeLeft = RefreshTime;
                OnEvent();
            }
        }

        public abstract void OnEvent();
    }
}
