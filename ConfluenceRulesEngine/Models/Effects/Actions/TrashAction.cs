namespace ConfluenceRulesEngine.Models.Effects.Actions
{
    public class TrashAction
        : Action
    {
        public TrashAction(params int[] targets)
        {
            this.Targets = targets;
        }

        public TrashAction(IEnumerable<int> targets)
        {
            this.Targets = targets;
        }

        public readonly IEnumerable<int> Targets;
    }
}
