using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Models.Zones
{
    public record struct Coords(Row Program, Col Slot, bool IsInterrupt, PlayerId OwnerId);
}
