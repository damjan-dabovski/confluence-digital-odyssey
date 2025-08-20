namespace ConfluenceRulesEngine.Models
{
    using System.Text.Json;

    internal record Game(Guid Id) {
        internal string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
    };
}
