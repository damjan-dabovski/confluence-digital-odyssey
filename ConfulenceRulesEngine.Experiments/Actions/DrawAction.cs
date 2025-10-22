namespace ConfulenceRulesEngine.Experiments.Actions
{
    public class DrawAction
        : Action
    {
        // dumb mock implementation just to have a couple different actions we can resolve
        public readonly int Amount;

        public DrawAction(int amount)
        {
            Amount = amount;
        }
    }
}
