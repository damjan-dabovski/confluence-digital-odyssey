using ConfluenceRulesEngine.Models.Core;

namespace ConfluenceRulesEngine.Models.Zones
{
    public class Trash
        : IOrderedZone
    {
        private readonly List<Card> cards = [];

        public ZoneType Type => ZoneType.Trash;

        public ICollection<Card> Cards => throw new NotImplementedException();

        public void Add(Card card, int index = 0)
        {
            index = int.Clamp(index, 0, this.cards.Count);
            this.cards.Insert(index, card);
        }

        public void Add(Card card) => this.cards.Add(card);

        public void Remove(Card card) => this.cards.Remove(card);
    }
}
