using System;

namespace ReversiKata.Tests
{
    class ReversiTestCaseGenerator
    {
        /// <summary>
        /// Gets 10 random coordinates on the board
        /// </summary>
        /// <returns></returns>
        internal static ReversiGridCoordinate[] GetTenRandomGridCoordinates()
        {
            var random = new Random();
            var pairCount = 0;
            var generatedCoordinates = new ReversiGridCoordinate[10]; 
            while (pairCount < 10)
            {
                generatedCoordinates[pairCount] = new ReversiGridCoordinate(random.Next(5), random.Next(5));
                pairCount++;
            }
            return generatedCoordinates;
        }

        /// <summary>
        /// Gets 5 randomly placed horizontal sets of white + n black cells
        /// </summary>
        /// <returns></returns>
        internal static ReversiBoard[] GetBoardOfMultipleCellsHorizontally()
        {
            var boards = new ReversiBoard[5];
            var boardCount = 0;
            var random = new Random();

            while (boardCount < 5)
            {
                var startColumn = random.Next(4);
                var runlength = random.Next(2, 7 - startColumn - 1); //make sure run length doesn't go off the board
                var row = random.Next(7);
                ReversiBoard reversiBoard = new ReversiBoard(false);

                reversiBoard.m_Cells[row, startColumn] = CellState.White;
                for (var column = startColumn + 1; column < startColumn + runlength; column++)
                {
                    reversiBoard.m_Cells[row, column] = CellState.Black;
                }

                boards[boardCount] = reversiBoard;
                boardCount++;
            }

            return boards;
        }

        /// <summary>
        /// Gets 5 randomly placed vertical sets of white + n black cells
        /// </summary>
        /// <returns></returns>
        internal static ReversiBoard[] GetBoardOfMultipleCellsVertically()
        {
            var boards = new ReversiBoard[5];
            var boardCount = 0;
            var random = new Random();

            while (boardCount < 5)
            {
                var startRow = random.Next(4);
                var runlength = random.Next(2, 7 - startRow - 1); //make sure run length doesn't go off the board
                var column = random.Next(7);
                ReversiBoard reversiBoard = new ReversiBoard(false);

                reversiBoard.m_Cells[startRow, column] = CellState.White;
                for (var row = startRow + 1; row < startRow + runlength; row++)
                {
                    reversiBoard.m_Cells[row, column] = CellState.Black;
                }
                
                boards[boardCount] = reversiBoard;
                boardCount++;
            }

            return boards;
        }


    }
}
