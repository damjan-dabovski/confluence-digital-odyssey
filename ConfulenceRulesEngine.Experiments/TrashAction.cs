using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TrashAction
        : Action
    {
        public readonly ISelector<IEnumerable<int>> Targets;

        public TrashAction(ISelector<IEnumerable<int>> targets)
        {
            this.Targets = targets;
        }
    }
}
