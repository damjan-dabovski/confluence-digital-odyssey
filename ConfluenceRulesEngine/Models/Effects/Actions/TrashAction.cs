using ConfluenceRulesEngine.Models.Effects.Selectors;

namespace ConfluenceRulesEngine.Models.Effects.Actions
{
    public class TrashAction
        : Action
    {
        public readonly ISelector<IEnumerable<int>> Targets;

        public TrashAction(ISelector<IEnumerable<int>> targets, Action? continuation = null)
            : base(continuation)
        {
            this.Targets = targets;
        }

    }
}
