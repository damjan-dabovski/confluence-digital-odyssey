using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface ISelector
    {
        IEnumerable<int> Evaluate(GameContext context);
    }
}
