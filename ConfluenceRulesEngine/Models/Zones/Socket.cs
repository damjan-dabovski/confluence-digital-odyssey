
using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Zones
{
    public class Socket(int Id = 0)
        : IZone
    {
        private readonly SingleCardCollection card = [];

        public ZoneType Type => ZoneType.Socket;

        public ICollection<Card> Cards => card;

        public int Id = Id;

        public bool IsInterrupt => Id % 2 != 0;

        public bool? InterruptLocked = false;

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
