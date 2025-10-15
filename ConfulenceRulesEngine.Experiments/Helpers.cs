using static ConsoleApp1.Enums;

namespace ConfulenceRulesEngine.Experiments
{
    public static class Helpers
    {
        /*
         * 18[19]20[21]22[23]
           14[15]16[17]
        B: 12[13]

           6[7]8[9]10[11]
           2[3]4[5]
        A: 0[1]
         */

        public static int GetPositionFromCoords(Coords coords)
        {
            var interruptOffset = coords.IsInterrupt ? 1 : 0;
            var playerOffset = (int)coords.Owner * 12;

            return playerOffset + interruptOffset + (3 * (int)coords.Program + 2 * (int)coords.Slot);
        }

        public static Coords GetCoordsFromPosition(int position)
        {
            var isInterrupt = position % 2 != 0;
            var hasPlayerOffset = position > 11;

            if (hasPlayerOffset)
            {
                position -= 12;
            }

            if (isInterrupt)
            {
                position -= 1;
            }

            var row = position switch
            {
                > 4 => Row.P3,
                > 0 => Row.P2,
                _ => Row.P1
            };

            var col = position switch
            {
                > 8 => Col.S3,
                > 6 => Col.S2,
                > 4 => Col.S1,
                > 2 => Col.S2,
                > 1 => Col.S1,
                _ => Col.S1
            };

            return new(row, col, isInterrupt, hasPlayerOffset ? PlayerId.B : PlayerId.A);
        }
    }
}
