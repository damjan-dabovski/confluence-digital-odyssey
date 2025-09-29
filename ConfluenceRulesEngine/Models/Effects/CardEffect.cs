namespace ConfluenceRulesEngine.Models.Effects
{
    public record CardEffect(
        (uint From, uint To) EffectSlots,
        IEnumerable<GameAction> Actions);
}
