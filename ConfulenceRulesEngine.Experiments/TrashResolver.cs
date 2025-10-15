namespace ConfulenceRulesEngine.Experiments
{
    using ConsoleApp1;

    public class TrashResolver
        : IResolver<TrashAction>
    {
        public void Resolve(TrashAction action, GameContext context)
        {
            var targets = action.Targets.Evaluate(context);

            Console.WriteLine($"Executing trash action with targets: {string.Join(", ", targets ?? [])}");
        }
    }
}
