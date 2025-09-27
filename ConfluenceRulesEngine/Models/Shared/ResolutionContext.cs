using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Shared
{
    public record ResolutionContext(PlayerId OwnerId, Row Program, Col Slot);
}
