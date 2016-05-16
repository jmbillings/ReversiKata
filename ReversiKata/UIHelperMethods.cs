using System;

namespace ReversiKata
{
    class UIHelperMethods
    {
        internal ConsoleColor GetCellColorForLetter(string letter)
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

        internal CellState GetCellStateForColor(ConsoleColor color)
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

        internal int GetColumnIndex(string column)
        {
            int columnIndex;
            if (!int.TryParse(column, out columnIndex))
            {
                Console.WriteLine("Could not parse the column to a valid number");
                return 99;
            }
            return columnIndex - 1;
        }

        internal int GetRowIndex(string row)
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
