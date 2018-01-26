using System;
using System.Threading;
using System.Threading.Tasks;

namespace Game.Core
{
    public class Timer
    {
        private bool Active { get; set; }
        public double Time { get; set; }
        public double Delta { get; set; }
        public double Speed { get; set; }

        public Timer()
        {
            Speed = 2;
            Delta = 100;
        }
        public void Tick()
        {
            Time += Delta;
            OnTimeTick();
        }

        public void Start()
        {
            Active = true;
            var starter = new Task(() =>
            {
                while (Active)
                {
                    Tick();
                    Thread.Sleep((int)(Delta/Speed));
                }
            });
            starter.Start();
        }

        public void Stop()
        {
            Active = false;
        }

        public event EventHandler TimeTick;

        protected virtual void OnTimeTick()
        {
            TimeTick?.Invoke(this, EventArgs.Empty);
        }
    }
}
