using ConfluenceRulesEngine.Models.Effects;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Creation
{
    public record CardInitModel(string Name, CardType Type, IEnumerable<CardEffect> CardEffects);
}
