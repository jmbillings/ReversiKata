﻿using System;
using NUnit.Framework;

namespace ReversiKata.Tests
{
    [TestFixture]
    public class PlayMoveTests
    {
        [TestCaseSource(typeof(ReversiTestCaseGenerator), nameof(ReversiTestCaseGenerator.GetBoardOfMultipleCellsHorizontally))]
        public void WhenACellIsPlayedTheCorrectOpponentCellsInARowSwitchColor(ReversiBoard reversiBoard)
        {
            ReversiGridCoordinate startCell = null;
            //setup
            for (var rowIndex = 0; rowIndex < 8; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < 8; columnIndex++)
                {
                    if (reversiBoard.m_Cells[rowIndex, columnIndex] == CellState.White)
                    {
                        Console.WriteLine("Found first white cell at {0},{1}", rowIndex, columnIndex);
                        startCell = new ReversiGridCoordinate(rowIndex, columnIndex);
                        break;
                    }
                }
            }

            ReversiGridCoordinate playCell = null;
            var currentColumn = startCell.ColumnIndex + 1;
            while (playCell == null)
            {
                if (reversiBoard.m_Cells[startCell.RowIndex, currentColumn] == CellState.Empty)
                {
                    playCell = new ReversiGridCoordinate(startCell.RowIndex, currentColumn);
                    break;
                }
                currentColumn++;
            }

            //act
            reversiBoard.PlayMove(CellState.White, playCell.RowIndex, playCell.ColumnIndex);

            //assert 
            for(var column=startCell.ColumnIndex+1;column < playCell.ColumnIndex;column++)
            {
                var cellState = reversiBoard.m_Cells[startCell.RowIndex, column];
                if (cellState != CellState.White)
                {
                    Assert.Fail("Unexpected cell state found at column {0} - {1}", column, cellState);
                }
            }
        }

        public void WhenACellIsPlayedTheCorrectOpponentCellsInAColumnSwitchColor(int startRow, int runLength, ConsoleColor playedColor)
        {

        }

        public void WhenACellIsPlayedTheCorrectOpponentCellsInTwoDirectionsSwitchColor(int startRow, int startColumn, int runLength, ConsoleColor playedColor)
        {

        }

        public void WhenACellIsPlayedTheCorrectOpponentCellsInThreeDirectionsSwitchColor(int startRow, int startColumn, int runLength, ConsoleColor playedColor)
        {

        }
    }
}
