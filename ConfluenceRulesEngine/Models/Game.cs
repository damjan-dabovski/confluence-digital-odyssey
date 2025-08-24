namespace ConfluenceRulesEngine.Models
{
    using ConfluenceRulesEngine.Models.Creation;
    using ConfluenceRulesEngine.Models.Zones;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public record Game
    {
        [JsonInclude]
        public readonly Guid Id;

        [JsonInclude]
        public readonly Player[] Players;

        public Game(Guid Id, Dictionary<int, CardInitModel> CardPool, PlayerInitModel ActivePlayer, PlayerInitModel InactivePlayer)
        {
            this.Id = Id;
            this.Players =
            [
                new(ActivePlayer.Name, MapDeckFromCardIds(ActivePlayer.CardIds, CardPool)),
                new(InactivePlayer.Name, MapDeckFromCardIds(ActivePlayer.CardIds, CardPool))
            ];
        }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }

        private static Deck MapDeckFromCardIds(IEnumerable<int> cardIds, Dictionary<int, CardInitModel> CardPool)
        {
            var mappedCards = cardIds.Select(id => new Card(CardPool[id].Id, CardPool[id].Name));

            return new(mappedCards);
        }
    };
}
