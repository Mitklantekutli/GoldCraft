using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Game.Model.GameEvents;

namespace Game.Client
{
    class EventsConsumer
    {
        public class GameEventConsumer
        {
            ServerApi api = new ServerApi();
            private GameEventHandler gm;
            public GameEventConsumer(GameInstance game)
            {
                gm = new GameEventHandler(game);
                var t = new Task<List<GameEvent>>(GetAllEventsFromServer);
                t.Start();
                gm.Apply(t);
            }
           
                public List<GameEvent> GetAllEventsFromServer()
                {
                    var elist = new List<GameEvent>();
                    using (var client = new HttpClient())
                    {
                            client.GetAsync("");

                    };
                    return elist;
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
