using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class GameContext
    {
        public Dictionary<int, Card> Cards;
        public Dictionary<string, object> Store;

        public GameContext(Dictionary<int, Card> cards)
        {
            this.Cards = cards;
            this.Store = new();
        }
    }
}
