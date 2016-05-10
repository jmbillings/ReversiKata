using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiKata
{
    public class ReversiBoard
    {
        public CellState[,] m_Cells;

        public ReversiBoard()
        {
            m_Cells = new CellState[8, 8];
            PopulateDefaultGame();
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
