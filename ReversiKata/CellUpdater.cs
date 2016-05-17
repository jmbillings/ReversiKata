using System;

namespace ReversiKata
{
    class CellUpdater
    {
        internal void UpdateCellsForMove(int playedRow, int playedColumn, CellState color, ref CellState[,] reversiBoard)
        {
            ConsoleColor playColor;
            if (color == CellState.Black)
                playColor = ConsoleColor.Black;
            else
                playColor = ConsoleColor.White;
            
            var cellValidator = new CellValidator();
            cellValidator.IsCellValid(playedRow, playedColumn, reversiBoard, playColor, true);

            reversiBoard = cellValidator.m_PlayedGrid;
        }
    }
}
