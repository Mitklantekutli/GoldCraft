using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var core = new GameCore();
            core.Start();
            var t = new Task(() =>
            {
                
            });
            System.Console.ReadLine();
        }
    }
}
