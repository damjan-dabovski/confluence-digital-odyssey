using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ConsoleApp1.Enums;

namespace ConsoleApp1
{
    public class CardSelector
        : ISelector<IEnumerable<int>>
    {
        public CardType Type { get; set; }
        public required Zone Zone { get; set; }
        public int Position { get; set; }

        public CardSelector() { }

        public IEnumerable<int> Evaluate(GameContext context) => throw new NotImplementedException();
    }
}
