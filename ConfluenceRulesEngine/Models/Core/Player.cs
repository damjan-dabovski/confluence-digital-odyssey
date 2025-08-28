using ConfluenceRulesEngine.Models.Zones;

namespace ConfluenceRulesEngine.Models.Core
{
    public record Player(string Name, Deck Deck)
    {
        public readonly Hand Hand = new();
        public readonly Trash Trash = new();
    }
}
