using System;
using System.Collections.Generic;

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
            var eastCells = CellsToCheck(coordinate, Direction.East);
            var westCells = CellsToCheck(coordinate, Direction.West);
            return false;
        }

        private bool IsCellValidVertically(ReversiGridCoordinate coordinate, ConsoleColor color)
        {
            var northCells = CellsToCheck(coordinate, Direction.North);
            var southCells = CellsToCheck(coordinate, Direction.South);
            return false;
        }

        private bool IsCellValidDiagnoally(ReversiGridCoordinate coordinate, ConsoleColor color)
        {
            var northEastCells = CellsToCheck(coordinate, Direction.NorthEast);
            var southEastCells = CellsToCheck(coordinate, Direction.SouthEast);
            var southWestCells = CellsToCheck(coordinate, Direction.SouthWest);
            var northWestCells = CellsToCheck(coordinate, Direction.NorthWest);
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

        private List<ReversiGridCoordinate> CellsToCheck(ReversiGridCoordinate startPoint, int rowDirection, int columnDirection)
        {
            var cellList = new List<ReversiGridCoordinate>();





            return cellList;
        }
    }
}
