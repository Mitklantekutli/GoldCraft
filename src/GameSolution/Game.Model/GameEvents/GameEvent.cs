using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model.GameEvents
{

    public class GameEvent
    {
        public long Id { get; set; }
        public GameEventType EvType { get; set; }
    }

}
