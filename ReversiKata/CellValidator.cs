using System;

namespace ReversiKata
{
    class CellValidator
    {
        private CellState[,] m_Grid;

        internal bool IsCellValid(int rowIndex, int colIndex, CellState[,] reversiGrid, ConsoleColor color)
        {
            m_Grid = reversiGrid;
            var coordinate = new ReversiGridCoordinate(rowIndex, colIndex);

            if ((IsCellValidHorizontally(coordinate, color)) || (IsCellValidVertically(coordinate, color)) || (IsCellValidDiagnoally(coordinate, color)))
                return true;

            return false;
        }

        private bool IsCellValidHorizontally(ReversiGridCoordinate coordinate, ConsoleColor color)
        {
            return false;
        }

        private bool IsCellValidVertically(ReversiGridCoordinate coordinate, ConsoleColor color)
        {
            return false;
        }

        private bool IsCellValidDiagnoally(ReversiGridCoordinate coordinate, ConsoleColor color)
        {
            return false;
        }

    }
}
