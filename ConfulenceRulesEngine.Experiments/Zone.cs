using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ConsoleApp1.Enums;

namespace ConsoleApp1
{
    public record Zone(ISelector Owner, ZoneType Type);
}
