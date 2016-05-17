using System;
using System.Collections.Generic;

namespace ReversiKata
{
    class CellValidator
    {
        private CellState[,] m_Grid;
        private bool m_PlayMove;
        internal CellState[,] m_PlayedGrid;

        internal bool IsCellValid(int rowIndex, int colIndex, CellState[,] reversiGrid, ConsoleColor color, bool playMove = false)
        {
            m_Grid = reversiGrid;
            m_PlayMove = playMove;
            m_PlayedGrid = (CellState[,])m_Grid.Clone();

            var coordinate = new ReversiGridCoordinate(rowIndex, colIndex);

            //is cell empty?
            if (m_Grid[rowIndex, colIndex] != CellState.Empty)
                return false;

            //is there a valid sequence of cells from this position?
            if ((IsCellValidHorizontally(coordinate, color)) || (IsCellValidVertically(coordinate, color)) || (IsCellValidDiagonally(coordinate, color)))
                return true;

            return false;
        }

        private bool IsCellValidHorizontally(ReversiGridCoordinate coordinate, ConsoleColor color)
        {
            var eastCells = CellsToCheck(coordinate, Direction.East);
            var westCells = CellsToCheck(coordinate, Direction.West);

            if (colourSequenceIsValid(eastCells, color) || colourSequenceIsValid(westCells, color))
                return true;

            return false;
        }

        private bool IsCellValidVertically(ReversiGridCoordinate coordinate, ConsoleColor color)
        {
            var northCells = CellsToCheck(coordinate, Direction.North);
            var southCells = CellsToCheck(coordinate, Direction.South);

            if (colourSequenceIsValid(northCells, color) || colourSequenceIsValid(southCells, color))
                return true;

            return false;
        }

        private bool IsCellValidDiagonally(ReversiGridCoordinate coordinate, ConsoleColor color)
        {
            var northEastCells = CellsToCheck(coordinate, Direction.NorthEast);
            var southEastCells = CellsToCheck(coordinate, Direction.SouthEast);
            var southWestCells = CellsToCheck(coordinate, Direction.SouthWest);
            var northWestCells = CellsToCheck(coordinate, Direction.NorthWest);

            if (colourSequenceIsValid(northEastCells, color) || colourSequenceIsValid(northWestCells, color) || colourSequenceIsValid(southEastCells, color) || colourSequenceIsValid(southWestCells, color))
                return true;

            return false;
        }

        /// <summary>
        /// Gets all the cells on the board from the candidate placement until the edge of the board is reached
        /// </summary>
        /// <param name="startPoint">Candidate cell we're checking validity for</param>
        /// <param name="direction">Compass direction to move on the board for cell retrieval</param>
        /// <returns></returns>
        private List<ReversiGridCoordinate> CellsToCheck(ReversiGridCoordinate startPoint, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return CellsToCheck(startPoint, -1, 0);
                case Direction.NorthEast:
                    return CellsToCheck(startPoint, -1, 1);
                case Direction.East:
                    return CellsToCheck(startPoint, 0, 1);
                case Direction.SouthEast:
                    return CellsToCheck(startPoint, 1, 1);
                case Direction.South:
                    return CellsToCheck(startPoint, 1, 0);
                case Direction.SouthWest:
                    return CellsToCheck(startPoint, 1, -1);
                case Direction.West:
                    return CellsToCheck(startPoint, 0, -1);
                case Direction.NorthWest:
                    return CellsToCheck(startPoint, -1, -1);
                default:
                    return new List<ReversiGridCoordinate>();
            }
        }

        /// <summary>
        /// Move in a straight line for the given direction until the edge of the board is reached, returning a list of cells passed through.
        /// </summary>
        /// <param name="startPoint">starting cell</param>
        /// <param name="rowDirection">direction along rows</param>
        /// <param name="columnDirection">direction along columns</param>
        /// <returns></returns>
        private List<ReversiGridCoordinate> CellsToCheck(ReversiGridCoordinate startPoint, int rowDirection, int columnDirection)
        {
            var cellList = new List<ReversiGridCoordinate>();
            ReversiGridCoordinate workingCell = startPoint;
            
            while(true)
            {
                workingCell = new ReversiGridCoordinate(workingCell.RowIndex + rowDirection, workingCell.ColumnIndex + columnDirection);

                if (nextCellValid(workingCell.RowIndex, workingCell.ColumnIndex))
                    cellList.Add(workingCell);
                else
                    break;
            }

            return cellList;
        }

        /// <summary>
        /// Returns false if the position is off the board edge
        /// </summary>
        /// <param name="nextRow">row to check</param>
        /// <param name="nextColumn">column to check</param>
        /// <returns></returns>
        private bool nextCellValid(int nextRow, int nextColumn)
        {
            if (nextRow == -1 || nextRow == 8 || nextColumn == -1 || nextColumn == 8)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Returns true if there are a valid set of colours from the given cell position. For example:
        /// Given cell WHITE. Return true if cells are BLACK - BLACK - WHITE
        /// Return false if cells are WHITE - BLACK - WHITE
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        private bool colourSequenceIsValid(List<ReversiGridCoordinate> cells, ConsoleColor color)
        {
            if (cells.Count == 0)
                return false;

            var cellsToFlip = new List<ReversiGridCoordinate>();

            if (color == ConsoleColor.Black)
            {
                //next cell must be white
                if (m_Grid[cells[0].RowIndex, cells[0].ColumnIndex] == CellState.White)
                {
                    cellsToFlip.Add(cells[0]);

                    //loop until we find another black
                    for (var cell = 1; cell < cells.Count; cell++)
                    {
                        cellsToFlip.Add(cells[cell]);
                        if (m_Grid[cells[cell].RowIndex, cells[cell].ColumnIndex] == CellState.Black)
                        {
                            if (m_PlayMove)
                                FlipCells(cellsToFlip, CellState.Black);
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                //next cell must be black
                if (m_Grid[cells[0].RowIndex, cells[0].ColumnIndex] == CellState.Black)
                {
                    cellsToFlip.Add(cells[0]);

                    //loop until we find another white
                    for (var cell = 1; cell < cells.Count; cell++)
                    {
                        cellsToFlip.Add(cells[cell]);

                        if (m_Grid[cells[cell].RowIndex, cells[cell].ColumnIndex] == CellState.White)
                        {
                            if (m_PlayMove)
                                FlipCells(cellsToFlip, CellState.White);
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        private void FlipCells(List<ReversiGridCoordinate> cells, CellState newState)
        {
            foreach (var cell in cells)
            {
                m_PlayedGrid[cell.RowIndex, cell.ColumnIndex] = newState;
            }   
        }
    }
}
