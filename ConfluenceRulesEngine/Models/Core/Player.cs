namespace ConfluenceRulesEngine.Models.Core
{
    using ConfluenceRulesEngine.Models.Zones;

    public record Player(string Name, Deck Deck)
    {
        public readonly Hand Hand = new();
        public readonly Trash Trash = new();
    }
}
