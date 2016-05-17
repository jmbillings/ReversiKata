using System;
using System.Linq;

namespace ReversiKata
{
    class Program
    {
        private static BoardRenderer m_BoardRenderer;
        private static ReversiBoard m_ReversiBoard;
        private static UIHelperMethods m_UiHelperMethods;

        static void Main(string[] args)
        {
            m_BoardRenderer = new BoardRenderer();
            m_ReversiBoard = new ReversiBoard();
            m_BoardRenderer.RenderBoard(m_ReversiBoard);
            m_UiHelperMethods = new UIHelperMethods();

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

            var selectedMove = new ReversiGridCoordinate(m_UiHelperMethods.GetRowIndex(userInput[1]), m_UiHelperMethods.GetColumnIndex(userInput[2]));
            var selectedColor = m_UiHelperMethods.GetCellColorForLetter(userInput[0]);
            var validMoves = m_ReversiBoard.GetValidMoves(selectedColor);
            var validMove = validMoves.Where(x => x.RowIndex == selectedMove.RowIndex && x.ColumnIndex == selectedMove.ColumnIndex);
            
            if (validMove.Count() == 1)
            {
                m_ReversiBoard.PlayMove(m_UiHelperMethods.GetCellStateForColor(selectedColor), selectedMove.RowIndex, selectedMove.ColumnIndex);
                m_BoardRenderer.RenderBoard(m_ReversiBoard);
            }
            else
            {
                Console.WriteLine("Sorry, that is not a legal move");
            }
        }
    }
}
