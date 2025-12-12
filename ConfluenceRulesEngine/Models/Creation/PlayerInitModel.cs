using ConfluenceRulesEngine.Services;

namespace ConfluenceRulesEngine.Models.Creation
{
    public record PlayerInitModel(string Name, IEnumerable<int> CardIds, ICommService CommService);
}
