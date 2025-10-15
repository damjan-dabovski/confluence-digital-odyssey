using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfulenceRulesEngine.Experiments.Selectors
{
    public interface ISelector<T>
    {
        T? Evaluate(GameContext context);
    }
}
