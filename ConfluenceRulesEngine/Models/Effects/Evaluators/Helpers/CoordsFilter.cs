using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers
{
    public record struct CoordsFilter(Row? Program, Col? Slot, bool? IsInterrupt, PlayerId? OwnerId);
}
