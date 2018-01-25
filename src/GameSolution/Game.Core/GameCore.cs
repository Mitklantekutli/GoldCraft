using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game.Core
{
    public class GameCore
    {
        private bool Active { get; set; }

        public Model.GameEvents.Game Game { get; set; }


        public double Time { get; set; }
        public double Delta { get; set; }

        public GameCore()
        {
            var starter = new Task(() =>
            {
                while (Active)
                {
                    Tick();
                    Thread.Sleep((int)Delta);
                }
            });
            starter.Start();
        }

        public void Tick()
        {
            Time += Delta;
        }

        public void Start()
        {
            Active = true;
        }

        public void Stop()
        {
            Active = false;
        }
    }
}
