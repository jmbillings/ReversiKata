using System;

namespace ReversiKata
{
    public class UIHelperMethods
    {
        public ConsoleColor GetCellColorForLetter(string letter)
        {
            switch (letter.ToLower())
            {
                case "w":
                    return ConsoleColor.White;
                case "b":
                    return ConsoleColor.Black;
            }

            return ConsoleColor.Red;
        }

        public CellState GetCellStateForColor(ConsoleColor color)
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

        public int GetColumnIndex(string column)
        {
            int columnIndex;
            if (!int.TryParse(column, out columnIndex))
            {
                Console.WriteLine("Could not parse the column to a valid number");
                return -1;
            }
            columnIndex = columnIndex - 1;

            if (columnIndex >= 0 && columnIndex <= 7)
                return columnIndex;
            else
                return -1;
        }

        public int GetRowIndex(string row)
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
                    return -1;
            }
        }
    }
}
