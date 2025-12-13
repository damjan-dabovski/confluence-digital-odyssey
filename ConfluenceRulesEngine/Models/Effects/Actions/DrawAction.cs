using ConfluenceRulesEngine.Models.Core;

namespace ConfluenceRulesEngine.Models.Effects.Actions
{
    public class DrawAction
        : Action
    {
        public readonly IEnumerable<Card> Targets;

        public DrawAction(IEnumerable<Card> targets, Action? continuation = null)
            : base(continuation)
        {
            this.Targets = targets;
        }
    }
}
