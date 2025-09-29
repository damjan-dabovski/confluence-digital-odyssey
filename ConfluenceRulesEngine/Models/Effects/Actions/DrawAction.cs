
using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Actions
{
    public class DrawAction
        : Action
    {
        public readonly IEnumerable<int> Targets;

        public DrawAction(IEnumerable<int> targets)
        {
            this.Targets = targets;
        }
    }
}
