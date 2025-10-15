using ConfulenceRulesEngine.Experiments.Selectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfulenceRulesEngine.Experiments.Actions
{
    public class TrashAction
        : Action
    {
        public readonly ISelector<IEnumerable<int>> Targets;

        public TrashAction(ISelector<IEnumerable<int>> targets)
        {
            Targets = targets;
        }
    }
}
