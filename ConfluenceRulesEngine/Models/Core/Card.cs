using ConfluenceRulesEngine.Models.Effects;
using ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers;
using ConfluenceRulesEngine.Models.Shared;
using ConfluenceRulesEngine.Models.Zones;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Core
{
    public class Card
        : IHasObjectId
    {
        private readonly int objectId;

        public readonly CardId CardId;
        public readonly string Name;
        public readonly CardType Type;
        public readonly IEnumerable<CardEffect> CardEffects;
        public readonly PlayerId OwnerId;
        public IZone CurrentZone;

        public int ObjectId => objectId;

        public Card(int cardId, int objectId, string name, CardType type, IEnumerable<CardEffect> cardEffects, PlayerId ownerId, IZone currentZone)
        {
            this.CardId = new(cardId);
            this.objectId = objectId;
            this.Name = name;
            this.Type = type;
            this.CardEffects = cardEffects;
            this.OwnerId = ownerId;
            this.CurrentZone = currentZone;
        }
    }
}
