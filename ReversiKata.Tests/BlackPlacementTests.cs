using System;
using NUnit.Framework;

namespace ReversiKata.Tests
{
    class BlackPlacementTests
    {
        [Test]
        [TestCaseSource(typeof(ReversiTestCaseGenerator), nameof(ReversiTestCaseGenerator.GetTenRandomGridCoordinates))]
        public void ABlackPieceCanBeplacedToTheRightOfABlackWhitePairButNotToTheLeft(ReversiGridCoordinate coordinate)
        {
            //setup
            var reversiBoard = new ReversiBoard(false);
            reversiBoard.m_Cells[coordinate.RowIndex, coordinate.ColumnIndex] = CellState.Black;
            reversiBoard.m_Cells[coordinate.RowIndex, coordinate.ColumnIndex + 1] = CellState.White;

            //act
            var validMoves = reversiBoard.GetValidMoves(ConsoleColor.Black);

            //assert
            Assert.That(validMoves.Count == 1, "Expected one valid move to be returned for position {0},{1}, but found {2}",
                coordinate.RowIndex, coordinate.ColumnIndex, validMoves.Count);

            Assert.That(validMoves[0].RowIndex == coordinate.RowIndex && validMoves[0].ColumnIndex == coordinate.ColumnIndex + 2);
        }

        [Test]
        [TestCaseSource(typeof(ReversiTestCaseGenerator), nameof(ReversiTestCaseGenerator.GetTenRandomGridCoordinates))]
        public void ABlackPieceCanBeplacedToTheLeftOfAWhiteBlackPairButNotToTheRight(ReversiGridCoordinate coordinate)
        {
            //setup
            var reversiBoard = new ReversiBoard(false);
            reversiBoard.m_Cells[coordinate.RowIndex, coordinate.ColumnIndex + 1] = CellState.White;
            reversiBoard.m_Cells[coordinate.RowIndex, coordinate.ColumnIndex + 2] = CellState.Black;

            //act
            var validMoves = reversiBoard.GetValidMoves(ConsoleColor.Black);

            //assert
            Assert.That(validMoves.Count == 1, "Expected one valid move to be returned for position {0},{1}, but found {2}",
                coordinate.RowIndex, coordinate.ColumnIndex, validMoves.Count);

            Assert.That(validMoves[0].RowIndex == coordinate.RowIndex && validMoves[0].ColumnIndex == coordinate.ColumnIndex);
        }

        [Test]
        [TestCase(0, 1, 2)]
        [TestCase(2, 1, 6)]
        [TestCase(7, 3, 3)]
        public void ABlackPieceCanBePlacedToTheLeftOfMultipleWhitePiecesWithABlackAtTheEnd(int row, int startColumn, int runlength)
        {
            //setup
            var reversiBoard = new ReversiBoard(false);
            for (var column = startColumn; column < startColumn + runlength; column++)
                reversiBoard.m_Cells[row, column] = CellState.White;
            reversiBoard.m_Cells[row, startColumn + runlength - 1] = CellState.Black;

            //act
            var validMoves = reversiBoard.GetValidMoves(ConsoleColor.Black);

            //assert
            Assert.That(validMoves.Count == 1, "Expected one valid move to be returned for position {0},{1}, but found {2}",
                row, startColumn - 1, validMoves.Count);

            Assert.That(validMoves[0].RowIndex == row && validMoves[0].ColumnIndex == startColumn - 1);
        }

        [Test]
        [TestCase(0, 1, 2)]
        [TestCase(2, 1, 6)]
        [TestCase(7, 3, 3)]
        public void ABlackPieceCanBePlacedToTheRightOfMultipleWhitePiecesWithABlackAtTheBeginning(int row, int startColumn, int runlength)
        {
            //setup
            var reversiBoard = new ReversiBoard(false);
            reversiBoard.m_Cells[row, startColumn] = CellState.Black;
            for (var column = startColumn + 1; column < startColumn + runlength; column++)
                reversiBoard.m_Cells[row, column] = CellState.White;

            //act
            var validMoves = reversiBoard.GetValidMoves(ConsoleColor.Black);

            //assert
            Assert.That(validMoves.Count == 1, "Expected one valid move to be returned for position {0},{1}, but found {2}",
                row, startColumn + runlength, validMoves.Count);

            Assert.That(validMoves[0].RowIndex == row && validMoves[0].ColumnIndex == startColumn + runlength);
        }

        [Test]
        [TestCase(0, 1, 2)]
        [TestCase(2, 1, 6)]
        [TestCase(7, 3, 3)]
        public void ABlackPieceCanBePlacedBelowMultipleWhitePiecesWithABlackAtTheTop(int column, int startRow, int runlength)
        {
            //setup
            var reversiBoard = new ReversiBoard(false);
            reversiBoard.m_Cells[startRow, column] = CellState.Black;
            for (var row = startRow + 1; row < startRow + runlength; row++)
                reversiBoard.m_Cells[row, column] = CellState.White;

            //act
            var validMoves = reversiBoard.GetValidMoves(ConsoleColor.Black);

            //assert
            Assert.That(validMoves.Count == 1, "Expected one valid move to be returned for position {0},{1}, but found {2}",
                startRow + runlength, column, validMoves.Count);

            Assert.That(validMoves[0].ColumnIndex == column && validMoves[0].RowIndex == startRow + runlength);
        }

        [Test]
        [TestCase(0, 1, 2)]
        [TestCase(2, 1, 6)]
        [TestCase(7, 3, 3)]
        public void ABlackPieceCanBePlacedAboveMultipleWhitePiecesWithABlackAtTheBottom(int column, int startRow, int runlength)
        {
            //setup
            var reversiBoard = new ReversiBoard(false);
            for (var row = startRow; row < startRow + runlength; row++)
                reversiBoard.m_Cells[row, column] = CellState.White;
            reversiBoard.m_Cells[startRow + runlength, column] = CellState.Black;

            //act
            var validMoves = reversiBoard.GetValidMoves(ConsoleColor.Black);

            //assert
            Assert.That(validMoves.Count == 1, "Expected one valid move to be returned for position {0},{1}, but found {2}",
                startRow - 1, column, validMoves.Count);

            Assert.That(validMoves[0].ColumnIndex == column && validMoves[0].RowIndex == startRow - 1);
        }

        [Test]
        [TestCase(1, 1, 2)]
        [TestCase(2, 1, 4)]
        [TestCase(4, 3, 3)]
        public void ABlackPieceCanBePlacedAboveAndToTheLeftOfMultipleWhitePiecesWithABlackAtTheEnd(int startColumn, int startRow, int runlength)
        {
            //setup
            var reversiBoard = new ReversiBoard(false);
            for (var counter = 0; counter < runlength; counter++)
                reversiBoard.m_Cells[startRow + counter, startColumn + counter] = CellState.White;
            reversiBoard.m_Cells[startRow + runlength, startColumn + runlength] = CellState.Black;

            //act
            var validMoves = reversiBoard.GetValidMoves(ConsoleColor.Black);

            //assert
            Assert.That(validMoves.Count == 1, "Expected one valid move to be returned for position {0},{1}, but found {2}",
                startRow - 1, startColumn - 1, validMoves.Count);

            Assert.That(validMoves[0].ColumnIndex == startColumn - 1 && validMoves[0].RowIndex == startRow - 1);
        }

        [Test]
        [TestCase(6, 1, 2)]
        [TestCase(5, 1, 4)]
        [TestCase(4, 3, 3)]
        public void ABlackPieceCanBePlacedAboveAndToTheRightOfMultipleWhitePiecesWithABlackAtTheEnd(int startColumn, int startRow, int runlength)
        {
            //setup
            var reversiBoard = new ReversiBoard(false);
            for (var counter = 0; counter < runlength; counter++)
                reversiBoard.m_Cells[startRow + counter, startColumn - counter] = CellState.White;
            reversiBoard.m_Cells[startRow + runlength, startColumn - runlength] = CellState.Black;

            //act
            var validMoves = reversiBoard.GetValidMoves(ConsoleColor.Black);

            //assert
            Assert.That(validMoves.Count == 1, "Expected one valid move to be returned for position {0},{1}, but found {2}",
                startRow - 1, startColumn + 1, validMoves.Count);

            Assert.That(validMoves[0].ColumnIndex == startColumn + 1 && validMoves[0].RowIndex == startRow - 1);
        }

    }
}
