using ConfluenceRulesEngine.Models.Core;

namespace ConfluenceRulesEngine.Models.Zones
{
    public class Hand
        : IZone
    {
        private readonly List<Card> cards = new();

        public ZoneType Type => ZoneType.Hand;

        public ICollection<Card> Cards => cards;

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
