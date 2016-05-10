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
            for(var rowIndex = 0; rowIndex < 8; rowIndex++)
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

        [Test]
        [TestCaseSource(typeof(ReversiTestCaseGenerator), "GetTenRandomGridCoordinates")]
        public void AWhitePieceCanBeplacedToTheRightOfAWhiteBlackPairButNotToTheLeft(ReversiGridCoordinate coordinate)
        {
            //setup
            var reversiBoard = new ReversiBoard(false);
            reversiBoard.m_Cells[coordinate.RowIndex, coordinate.ColumnIndex] = CellState.White;
            reversiBoard.m_Cells[coordinate.RowIndex + 1, coordinate.ColumnIndex] = CellState.Black;

            //act
            var validMoves = reversiBoard.GetValidMoves(ConsoleColor.White);
            
            //assert
            Assert.That(validMoves.Count == 1, "Expected one valid move to be returned for position {0},{1}, but found {2}", 
                coordinate.RowIndex, coordinate.ColumnIndex, validMoves.Count);
        }
    }
}
