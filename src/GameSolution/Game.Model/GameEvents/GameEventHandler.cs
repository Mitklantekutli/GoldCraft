using System;
using System.Collections.Generic;

namespace Game.Model.GameEvents
{
    public class GameEventHandler
    {
        public GameInstance GameInstance { get; set; }

        public GameEventHandler(GameInstance gameInstance)
        {
            GameInstance = gameInstance;
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
            GameInstance.OnTick(delta);
        }
    }
}