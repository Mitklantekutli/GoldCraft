using System.Collections.Generic;
using Game.Model.GameEvents;

namespace Game.Core
{
    public class GameCore
    {
        public GameInstance GameInstance { get; set; }

        public GameEventHandler Handler { get; set; }

        public Timer Timer { get; set; }
        
        public List<GameEvent> Events { get; set; }

        public GameCore()
        {
            Events = new List<GameEvent>();
            GameInstance = new Model.GameEvents.GameInstance();
            Handler = new GameEventHandler(GameInstance);
            Timer = new Timer();
            Timer.TimeTick += (o, s) =>
            {
                OnTick(Timer.Delta);
            };
        }


        public void Start()
        {
            Timer.Start();
        }
        
        public void AddEvent(GameEvent ge)
        {
            Events.Add(ge);
            Handler.Apply(ge);
        }

        private void OnTick(double delta)
        {
            GameInstance.OnTick(delta);
        }
    }
}
