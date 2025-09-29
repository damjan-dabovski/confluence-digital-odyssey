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
        public readonly ISelector Targets;

        public TrashAction(ISelector targets)
        {
            this.Targets = targets;
        }
    }
}
