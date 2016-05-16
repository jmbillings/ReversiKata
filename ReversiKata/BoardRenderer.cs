using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiKata
{
    class BoardRenderer
    {
        internal void RenderBoard(ReversiBoard reversiBoard)
        {
            for (int rowIndex = 0; rowIndex < 8; rowIndex++)
            {
                if (rowIndex == 0)
                {
                    Console.Write("  1 2 3 4 5 6 7 8\n");    
                }

                for (int columnIndex = 0; columnIndex < 8; columnIndex++)
                {
                    if (columnIndex == 0)
                    {
                        char rowLabel = (char) (rowIndex+65);
                        Console.Write(rowLabel.ToString() + ' ');    
                    }

                    switch (reversiBoard.m_Cells[rowIndex,columnIndex])
                    {
                        case CellState.Empty:
                            Console.Write('.');
                            break;
                        case CellState.Black:
                            Console.Write('B');
                            break;
                        case CellState.White:
                            Console.Write('W');
                            break;
                    }
                    Console.Write(' '); //horizontal spacing looks nicer
                }
                Console.Write('\n');
            } 
            Console.Write("\nEnter move as color,row,column (e.g. b,c,7) or 'x' to quit"); 
        }
    }
}
