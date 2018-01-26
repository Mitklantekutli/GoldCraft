using System;
using System.Collections.Generic;
using System.Linq;
using Game.Model.Players;

namespace Game.Model.GameEvents.Infrastructure
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

        public Player GetPlayer(long id)
        {
            return GameInstance.Players.Single(x => x.Player.Id == id).Player;
        }

        public PlayerGame GetGame(long id)
        {
            return GameInstance.Players.Single(x => x.Player.Id == id);
        }
    }
}