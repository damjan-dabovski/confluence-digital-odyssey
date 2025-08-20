namespace ConfluenceRulesEngine.Services
{
    using ConfluenceRulesEngine.Models;

    public interface IGameService
    {
        internal string GetNextState(Game game);
    }
}
