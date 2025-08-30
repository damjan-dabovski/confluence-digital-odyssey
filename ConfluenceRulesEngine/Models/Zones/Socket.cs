
using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Zones
{
    internal class Socket
        : IZone
    {
        private readonly SingleCardCollection card = new();

        public ZoneType Type => ZoneType.Socket;

        public ICollection<Card> Cards => card;

        public void Add(Card card, int index = 0) => this.card.Add(card);

        public Card? Remove(int index = 0)
        {
            if (this.card.Value is Card c)
            {
                _ = this.card.Remove(c);

                return c;
            }
            else
            {
                return null;
            }
        }
    }
}
