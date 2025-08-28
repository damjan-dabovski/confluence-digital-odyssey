using ConfluenceRulesEngine.Models.Effects;

namespace ConfluenceRulesEngine.Models.Creation
{
    public record CardInitModel(string Name, IEnumerable<GameAction> EffectActions);
}
