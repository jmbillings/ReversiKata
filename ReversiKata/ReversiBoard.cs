using System;
using System.Collections.Generic;

namespace ReversiKata
{
    public class ReversiBoard
    {
        public CellState[,] m_Cells;
        private CellValidator m_CellValidator;

        public ReversiBoard(bool placeDefaultPieces = true)
        {
            m_Cells = new CellState[8, 8];
            m_CellValidator = new CellValidator();
            if (placeDefaultPieces)
                PopulateDefaultGame();
        }

        public List<ReversiGridCoordinate> GetValidMoves(ConsoleColor color)
        {
            var validMoveCoordinates = new List<ReversiGridCoordinate>();

            for (var rowIndex = 0; rowIndex < 8; rowIndex++)
            {
                for (var colIndex = 0; colIndex < 8; colIndex++)
                {
                    if (m_CellValidator.IsCellValid(rowIndex, colIndex, m_Cells, color))
                        validMoveCoordinates.Add(new ReversiGridCoordinate(rowIndex, colIndex));
                }
            }

            return validMoveCoordinates;
        }

        public void PlayMove(CellState color, int rowIndex, int columnIndex)
        {
            //set the played cell
            m_Cells[rowIndex, columnIndex] = color;

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
