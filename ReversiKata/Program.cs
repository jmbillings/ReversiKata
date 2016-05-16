using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiKata
{
    class Program
    {
        private static BoardRenderer m_BoardRenderer;
        private static ReversiBoard m_ReversiBoard;

        static void Main(string[] args)
        {
            m_BoardRenderer = new BoardRenderer();
            m_ReversiBoard = new ReversiBoard();
            m_BoardRenderer.RenderBoard(m_ReversiBoard);

            while (true)
            {
                var userInput = Console.ReadLine();
                if (userInput.ToLower() == "x")
                    break;

                TryMove(userInput);
            }
        }

        private static void TryMove(string input)
        {
            var userInput = input.Split(',');
            if (userInput.Length != 3)
            {
                Console.WriteLine("Unable to parse arguments, please try again");
                return;
            }

            var selectedMove = new ReversiGridCoordinate(GetRowIndex(userInput[1]), GetColumnIndex(userInput[2]));
            var selectedColor = GetCellColorForLetter(userInput[0]);
            var validMoves = m_ReversiBoard.GetValidMoves(selectedColor);
            var validMove = validMoves.Select(x => x.RowIndex == selectedMove.RowIndex && x.ColumnIndex == selectedMove.ColumnIndex);

            if (validMove.Contains(true))
            {
                m_ReversiBoard.m_Cells[selectedMove.RowIndex, selectedMove.ColumnIndex] = GetCellStateForColor(selectedColor);
                m_BoardRenderer.RenderBoard(m_ReversiBoard);
            }
            else
            {
                Console.WriteLine("Sorry, that is not a legal move");
            }
        }

        private static ConsoleColor GetCellColorForLetter(string letter)
        {
            switch (letter)
            {
                case "w":
                    return ConsoleColor.White;
                case "b":
                    return ConsoleColor.Black;
            }

            return ConsoleColor.Red;
        }

        private static CellState GetCellStateForColor(ConsoleColor color)
        {
            switch (color)
            {
                case ConsoleColor.White:
                    return CellState.White;
                case ConsoleColor.Black:
                    return CellState.Black;
            }

            return CellState.Empty;
        }

        private static int GetColumnIndex(string column)
        {
            int columnIndex;
            if (!int.TryParse(column, out columnIndex))
            {
                Console.WriteLine("Could not parse the column to a valid number");
                return 99;
            }
            return columnIndex - 1;
        }

        private static int GetRowIndex(string row)
        {
            switch (row.ToLower())
            {
                case "a":
                    return 0;
                case "b":
                    return 1;
                case "c":
                    return 2;
                case "d":
                    return 3;
                case "e":
                    return 4;
                case "f":
                    return 5;
                case "g":
                    return 6;
                case "h":
                    return 7;
                default:
                    return 99;
            }
        }
    }
}
