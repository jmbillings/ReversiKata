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
                    Assert.Fail("Played cell {0},{1}. Unexpected cell state found at column {2} - {3}", playCell.RowIndex, playCell.ColumnIndex , column, cellState);
                }
            }
        }

        [TestCaseSource(typeof(ReversiTestCaseGenerator), nameof(ReversiTestCaseGenerator.GetBoardOfMultipleCellsVertically))]
        public void WhenACellIsPlayedTheCorrectOpponentCellsInAColumnSwitchColor(ReversiBoard reversiBoard)
        {
            ReversiGridCoordinate startCell = null;
            //setup
            for (var rowIndex = 0; rowIndex < 8; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < 8; columnIndex++)
                {
                    if (reversiBoard.m_Cells[rowIndex, columnIndex] == CellState.White)
                    {
                        startCell = new ReversiGridCoordinate(rowIndex, columnIndex);
                        break;
                    }
                }
            }

            ReversiGridCoordinate playCell = null;
            var currentRow = startCell.RowIndex + 1;
            while (playCell == null)
            {
                if (reversiBoard.m_Cells[currentRow, startCell.ColumnIndex] == CellState.Empty)
                {
                    playCell = new ReversiGridCoordinate(currentRow, startCell.ColumnIndex);
                    break;
                }
                currentRow++;
            }

            //act
            reversiBoard.PlayMove(CellState.White, playCell.RowIndex, playCell.ColumnIndex);

            //assert 
            for (var row = startCell.RowIndex + 1; row < playCell.RowIndex; row++)
            {
                var cellState = reversiBoard.m_Cells[row, startCell.ColumnIndex];
                if (cellState != CellState.White)
                {
                    Assert.Fail("Played cell {0},{1}. Unexpected cell state found at row {2} - {3}", playCell.RowIndex, playCell.ColumnIndex, row, cellState);
                }
            }
        }

        [TestCaseSource(typeof (ReversiTestCaseGenerator), nameof(ReversiTestCaseGenerator.GetBoardOfMultipleCellsVerticallyAndHorizontally))]
        public void WhenACellIsPlayedTheCorrectOpponentCellsInTwoDirectionsSwitchColor(ReversiBoardWithStartCellInfo reversiBoardInfo)
        {
            //setup
            var startCell = reversiBoardInfo.StartCell;
            var reversiBoard = reversiBoardInfo.Board;

            //act
            reversiBoard.PlayMove(CellState.White, startCell.RowIndex, startCell.ColumnIndex);

            //assert
            var column = startCell.ColumnIndex + 1;
            while (reversiBoard.m_Cells[startCell.RowIndex, column] != CellState.Empty)
            {
                if (reversiBoard.m_Cells[startCell.RowIndex, column] == CellState.Black)
                    Assert.Fail("Unexpected black cell found while checking horizontal cells at {0},{1}",
                        startCell.RowIndex, column);
                column++;
            }

            var row = startCell.RowIndex + 1;
            while (reversiBoard.m_Cells[row, startCell.ColumnIndex] != CellState.Empty)
            {
                if (reversiBoard.m_Cells[row, startCell.ColumnIndex] == CellState.Black)
                    Assert.Fail("Unexpected black cell found while checking vertical cells at {0},{1}", row,
                        startCell.ColumnIndex);
                row++;
            }
        }

        public void WhenACellIsPlayedTheCorrectOpponentCellsInThreeDirectionsSwitchColor(int startRow, int startColumn, int runLength, ConsoleColor playedColor)
        {

        }
    }
}
