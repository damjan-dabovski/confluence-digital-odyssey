namespace ConfluenceRulesEngine.Models.Effects
{
    public record CardEffect((int From, int To) EffectSlots, IEnumerable<GameAction> Actions);
}
