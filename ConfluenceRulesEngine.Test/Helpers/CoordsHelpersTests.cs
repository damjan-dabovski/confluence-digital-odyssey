using ConfluenceRulesEngine.Helpers;
using ConfluenceRulesEngine.Models.Zones;

using static ConfluenceRulesEngine.Models.Shared.Enums;

namespace ConfluenceRulesEngine.Test.Helpers
{
    public class CoordsHelpersTests
    {
        /*
         * 18[19]20[21]22[23]
           14[15]16[17]
        B: 12[13]

           6[7]8[9]10[11]
           2[3]4[5]
        A: 0[1]
         */

        [TestClass]
        public class GetPositionFromCoords
        {
            [TestMethod]
            [DataRow(Row.P1, Col.S1, false, PlayerId.A, 0)]
            [DataRow(Row.P2, Col.S1, false, PlayerId.A, 2)]
            [DataRow(Row.P2, Col.S2, false, PlayerId.A, 4)]
            [DataRow(Row.P3, Col.S1, false, PlayerId.A, 6)]
            [DataRow(Row.P3, Col.S2, false, PlayerId.A, 8)]
            [DataRow(Row.P3, Col.S3, false, PlayerId.A, 10)]
            [DataRow(Row.P1, Col.S1, true, PlayerId.A, 1)]
            [DataRow(Row.P2, Col.S1, true, PlayerId.A, 3)]
            [DataRow(Row.P2, Col.S2, true, PlayerId.A, 5)]
            [DataRow(Row.P3, Col.S1, true, PlayerId.A, 7)]
            [DataRow(Row.P3, Col.S2, true, PlayerId.A, 9)]
            [DataRow(Row.P3, Col.S3, true, PlayerId.A, 11)]
            [DataRow(Row.P1, Col.S1, false, PlayerId.B, 12)]
            [DataRow(Row.P2, Col.S1, false, PlayerId.B, 14)]
            [DataRow(Row.P2, Col.S2, false, PlayerId.B, 16)]
            [DataRow(Row.P3, Col.S1, false, PlayerId.B, 18)]
            [DataRow(Row.P3, Col.S2, false, PlayerId.B, 20)]
            [DataRow(Row.P3, Col.S3, false, PlayerId.B, 22)]
            [DataRow(Row.P1, Col.S1, true, PlayerId.B, 13)]
            [DataRow(Row.P2, Col.S1, true, PlayerId.B, 15)]
            [DataRow(Row.P2, Col.S2, true, PlayerId.B, 17)]
            [DataRow(Row.P3, Col.S1, true, PlayerId.B, 19)]
            [DataRow(Row.P3, Col.S2, true, PlayerId.B, 21)]
            [DataRow(Row.P3, Col.S3, true, PlayerId.B, 23)]
            public void CorrectlyGetsPositionFromCoords(Row row, Col col, bool isInterrupt, PlayerId ownerId, int expectedPosition)
            {
                // Arrange
                var coords = new Coords(row, col, isInterrupt, ownerId);

                // Act
                var result = CoordsHelpers.GetPositionFromCoords(coords);

                // Assert
                Assert.AreEqual(expectedPosition, result);
            }
        }

        [TestClass]
        public class GetCoordsFromPosition
        {
            [TestMethod]
            [DataRow(0, Row.P1, Col.S1, false, PlayerId.A)]
            [DataRow(2, Row.P2, Col.S1, false, PlayerId.A)]
            [DataRow(4, Row.P2, Col.S2, false, PlayerId.A)]
            [DataRow(6, Row.P3, Col.S1, false, PlayerId.A)]
            [DataRow(8, Row.P3, Col.S2, false, PlayerId.A)]
            [DataRow(10, Row.P3, Col.S3, false, PlayerId.A)]
            [DataRow(1, Row.P1, Col.S1, true, PlayerId.A)]
            [DataRow(3, Row.P2, Col.S1, true, PlayerId.A)]
            [DataRow(5, Row.P2, Col.S2, true, PlayerId.A)]
            [DataRow(7, Row.P3, Col.S1, true, PlayerId.A)]
            [DataRow(9, Row.P3, Col.S2, true, PlayerId.A)]
            [DataRow(11, Row.P3, Col.S3, true, PlayerId.A)]
            [DataRow(12, Row.P1, Col.S1, false, PlayerId.B)]
            [DataRow(14, Row.P2, Col.S1, false, PlayerId.B)]
            [DataRow(16, Row.P2, Col.S2, false, PlayerId.B)]
            [DataRow(18, Row.P3, Col.S1, false, PlayerId.B)]
            [DataRow(20, Row.P3, Col.S2, false, PlayerId.B)]
            [DataRow(22, Row.P3, Col.S3, false, PlayerId.B)]
            [DataRow(13, Row.P1, Col.S1, true, PlayerId.B)]
            [DataRow(15, Row.P2, Col.S1, true, PlayerId.B)]
            [DataRow(17, Row.P2, Col.S2, true, PlayerId.B)]
            [DataRow(19, Row.P3, Col.S1, true, PlayerId.B)]
            [DataRow(21, Row.P3, Col.S2, true, PlayerId.B)]
            [DataRow(23, Row.P3, Col.S3, true, PlayerId.B)]
            public void CorrectlyGetsCoordsFromPosition(int position, Row expectedRow, Col expectedCol, bool expectedIsInterrupt, PlayerId expectedOwnerId)
            {
                // Arrange & Act
                var result = CoordsHelpers.GetCoordsFromPosition(position);

                // Assert
                Assert.AreEqual(expectedRow, result.Program);
                Assert.AreEqual(expectedCol, result.Slot);
                Assert.AreEqual(expectedIsInterrupt, result.IsInterrupt);
                Assert.AreEqual(expectedOwnerId, result.OwnerId);
            }
        }
    }
}
