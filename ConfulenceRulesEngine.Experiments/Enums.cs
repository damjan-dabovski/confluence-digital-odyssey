using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Enums
    {
        public enum PlayerId
        {
            A,
            B
        }

        public enum CardType
        {
            Function = 1,
            Lambda = 2
        }

        public enum ZoneType
        {
            Hand,
            Deck,
            Trash,
            Board
        }
    }
}
