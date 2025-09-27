using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Models.Zones;

namespace ConfluenceRulesEngine.Models.Shared
{
    public static class Helpers
    {
        public static void Move(Card card, IZone source, IZone destination)
        {
            source.Remove(card);

            destination.Add(card);
        }
    }
}
