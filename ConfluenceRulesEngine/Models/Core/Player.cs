using ConfluenceRulesEngine.Models.Zones;
using ConfluenceRulesEngine.Services;

namespace ConfluenceRulesEngine.Models.Core
{
    public record Player(string Name, Deck Deck, ICommService CommService)
    {
        public readonly Hand Hand = new();
        public readonly Trash Trash = new();
    }
}
