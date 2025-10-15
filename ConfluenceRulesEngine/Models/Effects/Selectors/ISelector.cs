using ConfluenceRulesEngine.Models.Shared;

namespace ConfluenceRulesEngine.Models.Effects.Selectors
{
    public interface ISelector<T>
    {
        public T? Evaluate(GameContext context);
    }
}
