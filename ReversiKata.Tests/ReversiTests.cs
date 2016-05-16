using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NUnit.Framework;

namespace ReversiKata.Tests
{
    [TestFixture]
    public class ReversiTests
    {

        [Test]
        public void NewGameBoardHasDefaultPieces()
        {
            var reversiBoard = new ReversiBoard();
            for (var rowIndex = 0; rowIndex < 8; rowIndex++)
            {
                for (var colIndex = 0; colIndex < 8; colIndex++)
                {
                    if ((rowIndex == 3 && colIndex == 3) || (rowIndex == 4 && colIndex == 4))
                        Assert.AreEqual(CellState.Black, reversiBoard.m_Cells[rowIndex, colIndex]);
                    else if ((rowIndex == 3 && colIndex == 4) || (rowIndex == 4 && colIndex == 3))
                        Assert.AreEqual(CellState.White, reversiBoard.m_Cells[rowIndex, colIndex]);
                    else
                        Assert.AreEqual(CellState.Empty, reversiBoard.m_Cells[rowIndex, colIndex]);
                }
            }
        }
    }
}
