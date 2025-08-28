namespace ConfluenceRulesEngine.Services
{
    using ConfluenceRulesEngine.Models.Core;

    public interface IGameService
    {
        internal string GetNextState(Game game);
    }
}
