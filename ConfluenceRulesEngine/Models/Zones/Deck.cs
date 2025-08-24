namespace ConfluenceRulesEngine.Models.Zones
{
    public class Deck(IEnumerable<Card> Cards)
        : IZone
    {
        public ZoneType Type => ZoneType.Deck;
    }
}
