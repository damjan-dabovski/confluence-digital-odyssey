using ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers;

namespace ConfluenceRulesEngine.Models.Effects.Actions
{
    public class DrawAction
        : Action
    {
        public readonly IEnumerable<CardId> Targets;

        public DrawAction(IEnumerable<CardId> targets, Action? continuation = null)
            : base(continuation)
        {
            this.Targets = targets;
        }
    }
}
