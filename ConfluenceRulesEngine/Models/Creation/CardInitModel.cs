namespace ConfluenceRulesEngine.Models.Creation
{
    using ConfluenceRulesEngine.Models.Effects;

    public record CardInitModel(string Name, IEnumerable<GameAction> EffectActions);
}
