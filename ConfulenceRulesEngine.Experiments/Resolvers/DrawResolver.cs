namespace ConfulenceRulesEngine.Experiments.Resolvers
{
    using ConfulenceRulesEngine.Experiments.Actions;
    using ConsoleApp1;

    internal class DrawResolver
        : IResolver<DrawAction>
    {
        public void Resolve(DrawAction action, GameContext context)
        {
            Console.WriteLine($"Resolving DrawAction, drawing {action.Amount} cards");
        }
    }
}
