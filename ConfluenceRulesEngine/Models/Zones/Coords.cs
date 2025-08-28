namespace ConfluenceRulesEngine.Models.Zones
{
    using static ConfluenceRulesEngine.Models.Shared.Enums;

    public record struct Coords(Row Program, Col Slot, PlayerId OwnerId);
}
