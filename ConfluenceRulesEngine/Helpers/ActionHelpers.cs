using ConfluenceRulesEngine.Models.Core;
using ConfluenceRulesEngine.Models.Zones;

namespace ConfluenceRulesEngine.Helpers
{
    public static class ActionHelpers
    {
        public static void Move(Card card, IZone source, IZone destination)
        {
            if (source == destination)
            {
                throw new InvalidOperationException("Can't move into the same zone");
            }

            source.Remove(card);

            destination.Add(card);

            card.CurrentZone = destination;
        }
    }
}
