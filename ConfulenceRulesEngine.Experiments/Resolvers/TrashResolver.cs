namespace ConfulenceRulesEngine.Experiments.Resolvers
{
    using ConfulenceRulesEngine.Experiments.Actions;
    using ConsoleApp1;

    public class TrashResolver
        : IResolver<TrashAction>
    {
        public void Resolve(TrashAction action, GameContext context)
        {
            Console.WriteLine($"Executing trash action with targets: {string.Join(", ", action.Targets.Evaluate(context) ?? [])}");
        }
    }
}
