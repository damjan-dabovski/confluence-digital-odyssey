using ConfluenceRulesEngine.Models.Core;

namespace ConfluenceRulesEngine.Models.Zones
{
    public class Deck
        : IOrderedZone
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
            index = int.Clamp(index, 0, this.cards.Count);
            this.cards.Insert(index, card);
        }

        public void Add(Card card) => this.Cards.Add(card);

        public void Remove(Card card) => this.cards.Remove(card);
    }
}
