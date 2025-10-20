
using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Zones
{
    internal class Socket(int Id = 0)
        : IZone
    {
        private readonly SingleCardCollection card = new();

        public ZoneType Type => ZoneType.Board;

        public ICollection<Card> Cards => card;

        public int Id = Id;

        public void Add(Card card) => this.card.Add(card);

        public void Remove(Card card)
        {
            if (this.card.Value is Card c)
            {
                _ = this.card.Remove(c);
            }
        }
    }
}
