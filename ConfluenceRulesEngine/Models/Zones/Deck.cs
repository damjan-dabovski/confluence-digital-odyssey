using ConfluenceRulesEngine.Models.Core;

namespace ConfluenceRulesEngine.Models.Zones
{
    public class Deck
        : IZone
    {
        private readonly List<Card> cards;

        public ZoneType Type => ZoneType.Deck;

        public ICollection<Card> Cards => cards;

        public Deck(IEnumerable<Card> cards)
        {
            this.cards = [.. cards];
            foreach (var card in this.cards)
            {
                card.CurrentZone = this;
            }
        }

        public void Add(Card card, int index = 0)
        {
            if (index < 0)
            {
                this.cards.Insert(0, card);
            }
            else if (index >= this.cards.Count)
            {
                this.cards.Add(card);
            }
            else
            {
                this.cards.Insert(index, card);
            }
        }

        public void Remove(Card card) => this.cards.Remove(card);
    }
}
