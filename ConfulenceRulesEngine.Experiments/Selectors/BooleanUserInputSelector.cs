namespace ConfulenceRulesEngine.Experiments.Selectors
{
    using ConsoleApp1;

    public class BooleanUserInputSelector
            : ISelector<bool>
    {
        public bool Evaluate(GameContext context)
        {
            Console.WriteLine("Input 'true' or 'false'");

            return Console.ReadLine() switch
            {
                "true" => true,
                "false" => false,
                _ => throw new ArgumentException("I said 'true' or 'false'!")
            };
        }
    }
}
