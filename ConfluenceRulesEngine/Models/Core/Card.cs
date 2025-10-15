using ConfluenceRulesEngine.Models.Effects;
using ConfluenceRulesEngine.Models.Zones;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Core
{
    public class Card {
        public readonly int CardId;
        public readonly int ObjectId;
        public readonly string Name;
        public readonly CardType Type;
        public readonly IEnumerable<CardEffect> CardEffects;
        public readonly PlayerId OwnerId;
        public IZone CurrentZone;

        public Card(int cardId, int objectId, string name, CardType type, IEnumerable<CardEffect> cardEffects, PlayerId ownerId, IZone currentZone)
        {
            this.CardId = cardId;
            this.ObjectId = objectId;
            this.Name = name;
            this.Type = type;
            this.CardEffects = cardEffects;
            this.OwnerId = ownerId;
            this.CurrentZone = currentZone;
        }
    }
}
