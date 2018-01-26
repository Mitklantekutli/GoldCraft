using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Game.Model.GameEvents;
using Game.Model.GameEvents.Infrastructure;

namespace Game.Client
{
    class EventsConsumer
    {
        public class GameEventConsumer : IDisposable
        {
            ServerApi api = new ServerApi();

            private GameEventHandler gm;
            public bool Active { get; set; }

            public GameEventConsumer(GameInstance game)
            {
                gm = new GameEventHandler(game);
            }

            public long LastEventId { get; set; }

            public void StartListen()
            {
                Active = true;
                var t = new Task(() =>
                {
                    while (Active)
                    {
                        var events = GetAllEventsFromServer();
                        if (events.Any())
                            ApplyEvents(events);
                        Thread.Sleep(100);
                    }

                });
                t.Start();

            }



            private void ApplyEvents(List<GameEvent> events)
            {
                gm.Apply(events);
                LastEventId = events.Select(x => x.Id).Max();
            }

            public List<GameEvent> GetAllEventsFromServer()
            {
                var elist = new List<GameEvent>();
                using (var client = new HttpClient())
                {
                    client.GetAsync("" + LastEventId);

                }
                ;
                return elist;
            }

            public void Dispose()
            {
                Active = false;
            }
        }

    }

    class ServerApi
    {
        private static int kek { get; set; }
        public ServerApi()
        {

        }
      
    }
}
