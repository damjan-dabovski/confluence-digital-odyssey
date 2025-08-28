namespace ConfluenceRulesEngine.Models.Core
{
    using ConfluenceRulesEngine.Models.Effects;

    public record Card(int CardId, int ObjectId, string Name, IEnumerable<GameAction> EffectActions);
}
