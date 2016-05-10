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
            return new List<ReversiGridCoordinate>();
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
