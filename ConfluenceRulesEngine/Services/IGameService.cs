using ConfluenceRulesEngine.Models.Core;

namespace ConfluenceRulesEngine.Services
{
    public interface IGameService
    {
        internal string GetNextState(Game game);
    }
}
