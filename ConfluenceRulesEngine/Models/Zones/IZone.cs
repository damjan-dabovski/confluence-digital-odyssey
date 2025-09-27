using ConfluenceRulesEngine.Models.Core;

namespace ConfluenceRulesEngine.Models.Zones
{
    public interface IZone
    {
        public ZoneType Type { get; }

        public ICollection<Card> Cards { get; }

        public void Add(Card card, int index = 0);

        public void Remove(Card card);
    }
}
