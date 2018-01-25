using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Game.Model.GameEvents;

namespace Game.Core
{
    public class GameCore
    {
        private bool Active { get; set; }

        public Model.GameEvents.GameInstance GameInstance { get; set; }

        public GameEventHandler Handler { get; set; }


        public double Time { get; set; }
        public double Delta { get; set; }

        public GameCore()
        {
            Delta = 100;
            Events = new List<GameEvent>();
            GameInstance = new Model.GameEvents.GameInstance();
            Handler = new GameEventHandler(GameInstance);
            
        }

        public void Tick()
        {
            Time += Delta;
            OnOnTick(this);
            HandleEvents();
            Handler.OnTick(Delta);
        }

        private void HandleEvents()
        {
            
        }

        public void Start()
        {
            Active = true;
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

        public void Stop()
        {
            Active = false;
        }

        public event EventHandler<GameCore> OnTick;

        protected virtual void OnOnTick(GameCore e)
        {
            OnTick?.Invoke(this, e);
        }

        public List<GameEvent> Events { get; set; }

        public void AddEvent(GameEvent ge)
        {
            Events.Add(ge);
        }
    }
}
