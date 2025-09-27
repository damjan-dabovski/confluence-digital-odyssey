using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Resolvers
{
    public interface IActionResolver<T>
        where T : Actions.Action
    {
        public void Resolve(T action, ResolutionContext resolutionContext, GameContext gameContext);
    }
}
