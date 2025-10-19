namespace ConfluenceRulesEngine.Models.Shared
{
    public class Enums
    {
        public enum PlayerId
            : byte
        {
            A,
            B
        }

        public enum Row
            : byte
        {
            P1,
            P2,
            P3,
        }

        public enum Col
            : byte
        {
            S1,
            S2,
            S3,
        }

        public enum CardType
            : byte
        {
            Function,
            Lambda
        }

        public enum SocketType
        {
            NonInterrupt,
            Interrupt,
            Any
        }

        public enum ArithmeticOperator
        {
            Add,
            Subtract,
            Multiply,
            DivideRoundUp,
            DivideRoundDown
        }
    }
}
