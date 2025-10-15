using static ConsoleApp1.Enums;

namespace ConfulenceRulesEngine.Experiments
{
    public readonly struct Coords
    {
        public readonly Row Program;
        public readonly Col Slot;
        public readonly bool IsInterrupt;
        public readonly PlayerId Owner;

        public Coords(Row program, Col slot, bool isInterrupt, PlayerId owner)
        {
            Program = program;
            Slot = slot;
            IsInterrupt = isInterrupt;
            Owner = owner;
        }
    }
}
