using System;
using System.Collections.Generic;

namespace ReversiKata
{
    public class ReversiBoard
    {
        public CellState[,] m_Cells;

        public ReversiBoard(bool placeDefaultPieces = true)
        {
            m_Cells = new CellState[8, 8];
            if (placeDefaultPieces)
                PopulateDefaultGame();
        }

        public List<ReversiGridCoordinate> GetValidMoves(ConsoleColor color)
        {
            var lastWhiteColumnIndex = 0;
            var lastBlackColumnIndex = 0;
            var validMoveCoordinates = new List<ReversiGridCoordinate>();
            for (var rowIndex = 0; rowIndex < 8; rowIndex++)
            {
                for (var colIndex = 0; colIndex < 8; colIndex++)
                {
                    if (m_Cells[rowIndex, colIndex] == CellState.Black)
                    {
                        lastBlackColumnIndex = colIndex;
                        if ((lastWhiteColumnIndex == colIndex - 1) && (color == ConsoleColor.White))
                            validMoveCoordinates.Add(new ReversiGridCoordinate(rowIndex, colIndex + 1));
                    }

                    if (m_Cells[rowIndex, colIndex] == CellState.White)
                    {
                        lastWhiteColumnIndex = colIndex;
                        if ((lastBlackColumnIndex == colIndex - 1) && (color == ConsoleColor.Black))
                            validMoveCoordinates.Add(new ReversiGridCoordinate(rowIndex, colIndex + 1));
                    }
                }
            }

            return validMoveCoordinates;
        }

        private void PopulateDefaultGame()
        {
            m_Cells[3, 3] = CellState.Black;
            m_Cells[3, 4] = CellState.White;
            m_Cells[4, 3] = CellState.White;
            m_Cells[4, 4] = CellState.Black;
        }
    }
}
