namespace ConfulenceRulesEngine.Experiments.Resolvers
{
    using Action = Actions.Action;
    using ConsoleApp1;
    using ConfulenceRulesEngine.Experiments.Selectors;

    public interface IResolver<T>
        where T: Action
    {
        public void Resolve(T action, GameContext context);
    }
}
