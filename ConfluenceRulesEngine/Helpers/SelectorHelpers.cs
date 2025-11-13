using ConfluenceRulesEngine.Models.Effects.Evaluators.Helpers;
using ConfluenceRulesEngine.Models.Shared;
using ConfluenceRulesEngine.Models.Zones;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Helpers
{
    public static class SelectorHelpers
    {
        /*
         * 18[19]20[21]22[23]
           14[15]16[17]
        B: 12[13]

           6[7]8[9]10[11]
           2[3]4[5]
        A: 0[1]
         */

        public static IEnumerable<Socket> FilterSocketsByCoords(IEnumerable<Socket> sockets, CoordsFilter coords)
        {
            var ret = sockets;

            if (coords.OwnerId is PlayerId ownerId)
            {
                ret = ownerId switch
                {
                    PlayerId.A => ret.Take(12),
                    PlayerId.B => ret.Skip(12),
                    _ => throw new InvalidOperationException($"Player ID {ownerId} doesn't exist")
                };
            }

            if (coords.Program is Row row)
            {
                ret = ret.Where(s => s.IsSocketInRow(row));
            }

            if (coords.Slot is Col col)
            {
                ret = ret.Where(s => s.IsSocketInCol(col));
            }

            if (coords.IsInterrupt is bool isInterrupt)
            {
                ret = ret.Where(s => s.IsInterrupt);
            }

            return ret;
        }

        private static bool IsSocketInRow(this Socket socket, Row row)
        {
            return row switch
            {
                Row.P1 => socket.Id is < 2 or (> 11 and < 14),
                Row.P2 => socket.Id is (> 1 and < 6) or (> 13 and < 18),
                Row.P3 => socket.Id is (> 5 and < 12) or (> 17),
                _ => throw new InvalidOperationException($"Invalid row value {row}")
            };
        }

        private static bool IsSocketInCol(this Socket socket, Col col)
        {
            return col switch
            {
                Col.S1 => socket.Id is 0 or 1 or 2 or 3 or 6 or 7 or 12 or 13 or 14 or 15 or 18 or 19,
                Col.S2 => socket.Id is 4 or 5 or 8 or 9 or 16 or 17 or 20 or 21,
                Col.S3 => socket.Id is 10 or 11 or 22 or 23,
                _ => throw new InvalidOperationException($"Invalid col value {col}")
            };
        }
    }
}
