using System;
using NUnit.Framework;

namespace ReversiKata.Tests
{
    class WhitePlacementTests
    {
        [Test]
        [TestCaseSource(typeof(ReversiTestCaseGenerator), nameof(ReversiTestCaseGenerator.GetTenRandomGridCoordinates))]
        public void AWhitePieceCanBeplacedToTheRightOfAWhiteBlackPairButNotToTheLeft(ReversiGridCoordinate coordinate)
        {
            //setup
            var reversiBoard = new ReversiBoard(false);
            reversiBoard.m_Cells[coordinate.RowIndex, coordinate.ColumnIndex] = CellState.White;
            reversiBoard.m_Cells[coordinate.RowIndex, coordinate.ColumnIndex + 1] = CellState.Black;

            //act
            var validMoves = reversiBoard.GetValidMoves(ConsoleColor.White);

            //assert
            Assert.That(validMoves.Count == 1, "Expected one valid move to be returned for position {0},{1}, but found {2}",
                coordinate.RowIndex, coordinate.ColumnIndex, validMoves.Count);

            Assert.That(validMoves[0].RowIndex == coordinate.RowIndex && validMoves[0].ColumnIndex == coordinate.ColumnIndex + 2);
        }

        [Test]
        [TestCaseSource(typeof(ReversiTestCaseGenerator), nameof(ReversiTestCaseGenerator.GetTenRandomGridCoordinates))]
        public void AWhitePieceCanBeplacedToTheLeftOfABlackWhitePairButNotToTheRight(ReversiGridCoordinate coordinate)
        {
            //setup
            var reversiBoard = new ReversiBoard(false);
            reversiBoard.m_Cells[coordinate.RowIndex, coordinate.ColumnIndex + 1] = CellState.Black;
            reversiBoard.m_Cells[coordinate.RowIndex, coordinate.ColumnIndex + 2] = CellState.White;

            //act
            var validMoves = reversiBoard.GetValidMoves(ConsoleColor.White);

            //assert
            Assert.That(validMoves.Count == 1, "Expected one valid move to be returned for position {0},{1}, but found {2}",
                coordinate.RowIndex, coordinate.ColumnIndex, validMoves.Count);

            Assert.That(validMoves[0].RowIndex == coordinate.RowIndex && validMoves[0].ColumnIndex == coordinate.ColumnIndex);
        }

        [Test]
        [TestCase(0, 1, 2)]
        [TestCase(2, 1, 6)]
        [TestCase(7, 3, 3)]
        public void AWhitePieceCanBePlacedToTheLeftOfMultipleBlackPiecesWithAWhiteAtTheEnd(int row, int startColumn, int runlength)
        {
            //setup
            var reversiBoard = new ReversiBoard(false);
            for (var column = startColumn; column < startColumn + runlength; column++)
                reversiBoard.m_Cells[row, column] = CellState.Black;
            reversiBoard.m_Cells[row, startColumn + runlength - 1] = CellState.White;

            //act
            var validMoves = reversiBoard.GetValidMoves(ConsoleColor.White);

            //assert
            Assert.That(validMoves.Count == 1, "Expected one valid move to be returned for position {0},{1}, but found {2}",
                row, startColumn - 1, validMoves.Count);

            Assert.That(validMoves[0].RowIndex == row && validMoves[0].ColumnIndex == startColumn - 1);
        }

        [Test]
        [TestCase(0, 1, 2)]
        [TestCase(2, 1, 6)]
        [TestCase(7, 3, 3)]
        public void AWhitePieceCanBePlacedToTheRightOfMultipleBlackPiecesWithAWhiteAtTheBeginning(int row, int startColumn, int runlength)
        {
            //setup
            var reversiBoard = new ReversiBoard(false);
            reversiBoard.m_Cells[row, startColumn] = CellState.White;
            for (var column = startColumn + 1; column < startColumn + runlength; column++)
                reversiBoard.m_Cells[row, column] = CellState.Black;

            //act
            var validMoves = reversiBoard.GetValidMoves(ConsoleColor.White);

            //assert
            Assert.That(validMoves.Count == 1, "Expected one valid move to be returned for position {0},{1}, but found {2}",
                row, startColumn + runlength, validMoves.Count);

            Assert.That(validMoves[0].RowIndex == row && validMoves[0].ColumnIndex == startColumn + runlength);
        }

        [Test]
        [TestCase(0, 1, 2)]
        [TestCase(2, 1, 6)]
        [TestCase(7, 3, 3)]
        public void AWhitePieceCanBePlacedBelowMultipleBlackPiecesWithAWhiteAtTheTop(int column, int startRow, int runlength)
        {
            //setup
            var reversiBoard = new ReversiBoard(false);
            reversiBoard.m_Cells[startRow, column] = CellState.White;
            for (var row = startRow + 1; row < startRow + runlength; row++)
                reversiBoard.m_Cells[row, column] = CellState.Black;

            //act
            var validMoves = reversiBoard.GetValidMoves(ConsoleColor.White);

            //assert
            Assert.That(validMoves.Count == 1, "Expected one valid move to be returned for position {0},{1}, but found {2}",
                startRow + runlength, column, validMoves.Count);

            Assert.That(validMoves[0].ColumnIndex == column && validMoves[0].RowIndex == startRow + runlength);
        }

        [Test]
        [TestCase(0, 1, 2)]
        [TestCase(2, 1, 6)]
        [TestCase(7, 3, 3)]
        public void AWhitePieceCanBePlacedAboveMultipleBlackPiecesWithAWhiteAtTheBottom(int column, int startRow, int runlength)
        {
            //setup
            var reversiBoard = new ReversiBoard(false);
            for (var row = startRow; row < startRow + runlength; row++)
                reversiBoard.m_Cells[row, column] = CellState.Black;
            reversiBoard.m_Cells[startRow + runlength, column] = CellState.White;

            //act
            var validMoves = reversiBoard.GetValidMoves(ConsoleColor.White);

            //assert
            Assert.That(validMoves.Count == 1, "Expected one valid move to be returned for position {0},{1}, but found {2}",
                startRow - 1, column, validMoves.Count);

            Assert.That(validMoves[0].ColumnIndex == column && validMoves[0].RowIndex == startRow - 1);
        }

        [Test]
        [TestCase(1, 1, 2)]
        [TestCase(2, 1, 4)]
        [TestCase(4, 3, 3)]
        public void AWhitePieceCanBePlacedAboveAndToTheLeftOfMultipleBlackPiecesWithAWhiteAtTheEnd(int startColumn, int startRow, int runlength)
        {
            //setup
            var reversiBoard = new ReversiBoard(false);
            for (var counter = 0; counter < runlength; counter++)
                reversiBoard.m_Cells[startRow + counter, startColumn + counter] = CellState.Black;
            reversiBoard.m_Cells[startRow + runlength, startColumn + runlength] = CellState.White;

            //act
            var validMoves = reversiBoard.GetValidMoves(ConsoleColor.White);

            //assert
            Assert.That(validMoves.Count == 1, "Expected one valid move to be returned for position {0},{1}, but found {2}",
                startRow - 1, startColumn - 1, validMoves.Count);

            Assert.That(validMoves[0].ColumnIndex == startColumn - 1 && validMoves[0].RowIndex == startRow - 1);
        }

        [Test]
        [TestCase(6, 1, 2)]
        [TestCase(5, 1, 4)]
        [TestCase(4, 3, 3)]
        public void AWhitePieceCanBePlacedAboveAndToTheRightOfMultipleBlackPiecesWithAWhiteAtTheEnd(int startColumn, int startRow, int runlength)
        {
            //setup
            var reversiBoard = new ReversiBoard(false);
            for (var counter = 0; counter < runlength; counter++)
                reversiBoard.m_Cells[startRow + counter, startColumn - counter] = CellState.Black;
            reversiBoard.m_Cells[startRow + runlength, startColumn - runlength] = CellState.White;

            //act
            var validMoves = reversiBoard.GetValidMoves(ConsoleColor.White);

            //assert
            Assert.That(validMoves.Count == 1, "Expected one valid move to be returned for position {0},{1}, but found {2}",
                startRow - 1, startColumn + 1, validMoves.Count);

            Assert.That(validMoves[0].ColumnIndex == startColumn + 1 && validMoves[0].RowIndex == startRow - 1);
        }

    }
}
