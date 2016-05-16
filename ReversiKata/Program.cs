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

            }
        }
    }
}
