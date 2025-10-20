using ConfluenceRulesEngine.Models.Core;

namespace ConfluenceRulesEngine.Models.Zones
{
    public interface IOrderedZone
        : IZone
    {
        public void Add(Card card, int index);
    }
}
