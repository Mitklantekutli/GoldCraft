using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Model.GameEvents;

namespace Game.Client.Model
{
    class RoomModel
    {
        public List<PlayerModel> players { get; set; }
        public long Id { get; set; }

        public RoomModel(List<PlayerModel> players, long id)
        {
            players = new List<PlayerModel>();
            this.players = players;

        }

    }
}
