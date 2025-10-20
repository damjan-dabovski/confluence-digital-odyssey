using ConfluenceRulesEngine.Models.Core;

namespace ConfluenceRulesEngine.Models.Zones
{
    public class Hand
        : IZone
    {
        private readonly List<Card> cards = new();

        public ZoneType Type => ZoneType.Hand;

        public ICollection<Card> Cards => cards;

        public void Add(Card card) => this.cards.Add(card);

        public void Remove(Card card) => this.cards.Remove(card);
    }
}
