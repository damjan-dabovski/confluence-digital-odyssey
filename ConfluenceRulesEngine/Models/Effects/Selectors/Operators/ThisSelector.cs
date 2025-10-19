using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Selectors.Operators
{
    public class ThisSelector
        : ISelector<IEnumerable<int>>
    {
        public IEnumerable<int> Evaluate(GameContext context)
        {
            var thisValue = (int)context.Store["this"];
            return [thisValue];
        }
    }
}
