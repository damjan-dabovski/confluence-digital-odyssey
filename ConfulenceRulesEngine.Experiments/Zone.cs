using static ConsoleApp1.Enums;

namespace ConsoleApp1
{
    public record Zone(ISelector<PlayerId> Owner, ZoneType Type);
}
