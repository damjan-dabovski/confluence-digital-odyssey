namespace ConfluenceRulesEngine.Services
{
    public interface ICommService
    {
        public void SendMessage(string message);

        public int GetInput();
    }
}
