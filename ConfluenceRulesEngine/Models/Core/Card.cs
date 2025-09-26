using ConfluenceRulesEngine.Models.Effects;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Core
{
    public record Card(int CardId, int ObjectId, string Name, IEnumerable<CardEffect> CardEffects, PlayerId OwnerId);
}
