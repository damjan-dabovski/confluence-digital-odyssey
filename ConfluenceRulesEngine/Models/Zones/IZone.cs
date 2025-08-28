namespace ConfluenceRulesEngine.Models.Zones
{
    using ConfluenceRulesEngine.Models.Core;

    public interface IZone
    {
        public ZoneType Type { get; }

        public ICollection<Card> Cards { get; }

        public void Add(Card card, int index = 0);

        public Card Remove(int index = 0);
    }
}
