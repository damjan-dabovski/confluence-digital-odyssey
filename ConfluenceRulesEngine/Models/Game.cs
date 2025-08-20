namespace ConfluenceRulesEngine.Models
{
    using System.Text.Json;

    public record Game(Guid Id, PlayerInitModel ActivePlayer, PlayerInitModel InactivePlayer) {
        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
    };
}
