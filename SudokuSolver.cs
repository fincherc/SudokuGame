﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
    public class SudokuSolver
    {
        public (int?[][], bool) FillBoard(int?[][] sudokuBoard, int posX, int posY, List<int?> sudokuNumbers, bool goodBoard)
        {
            var remainingNumbers = sudokuNumbers;
            var random = new Random();
            var viableBoard = goodBoard;

            if (posY == 9)
            {
                posY = 0;
                if(posX + 1 == 9)
                {
                    viableBoard = true;
                    return (sudokuBoard, viableBoard);
                }
                else 
                { 
                    return FillBoard(sudokuBoard, posX + 1, posY, remainingNumbers, viableBoard); 
                }
                
            }

            var sudokuRow = sudokuBoard[posX].ToList();
            var sudokuColumn = GetColumnSudoku(sudokuBoard, posY);
            var sudokuGrid = GetGridSudoku(sudokuBoard, posX, posY);

            if (sudokuBoard[posX][posY] != null)
            {
                return FillBoard(sudokuBoard, posX, posY + 1, remainingNumbers, viableBoard);
            }
            else
            {
                //Determine if there is a number we can select to put into the cell.
                var selectionNumbers = sudokuNumbers.Except(sudokuRow).ToList();
                selectionNumbers = selectionNumbers.Except(sudokuColumn).ToList();
                selectionNumbers = selectionNumbers.Except(sudokuGrid).ToList();

                if (selectionNumbers.Count == 0)
                {
                    return (sudokuBoard, viableBoard);
                }
                else
                {
                    while(!viableBoard)
                    {
                        if (selectionNumbers.Count == 0)
                        {
                            return (sudokuBoard, viableBoard);
                        }
                        var index = random.Next(selectionNumbers.Count);
                        sudokuBoard[posX][posY] = selectionNumbers[index];
                        (sudokuBoard, viableBoard) = FillBoard(sudokuBoard, posX, posY + 1, remainingNumbers, viableBoard);

                        if(!viableBoard)
                        {
                            selectionNumbers.Remove(selectionNumbers[index]);
                            sudokuBoard[posX][posY] = null;
                        }
                    }
                }
            }
            return (sudokuBoard, viableBoard);
        }

        public List<int?> GetColumnSudoku(int?[][] sudokuBoard, int posY)
        {
            int row = 0;
            List<int?> columnSudoku = new List<int?>();

            while(row < 9)
            {
                columnSudoku.Add(sudokuBoard[row][posY]);
                row++;
            }

            return columnSudoku;
        }

        public List<int?> GetGridSudoku(int?[][] sudokuBoard, int posX, int posY)
        {
            List<int?> gridSudoku = new List<int?>();

            if(posX < 3 && posY < 3)
            {
                for(int row = 0; row < 3; row++)
                {
                    for(int column = 0; column < 3; column++)
                    {
                        if(sudokuBoard[row][column] != 0)
                        {
                            var entry = sudokuBoard[row][column];
                            gridSudoku.Add(entry);
                        }
                    }
                }

                return gridSudoku;
            }
            else if( posX < 3 && (posY >= 3 && posY < 6) )
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int column = 3; column < 6; column++)
                    {
                        if (sudokuBoard[row][column] != 0)
                        {
                            var entry = sudokuBoard[row][column];
                            gridSudoku.Add(entry);
                        }
                    }
                }

                return gridSudoku;
            }
            else if( posX < 3 && (posY >= 6 && posY < 9) )
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int column = 6; column < 9; column++)
                    {
                        if (sudokuBoard[row][column] != 0)
                        {
                            var entry = sudokuBoard[row][column];
                            gridSudoku.Add(entry);
                        }
                    }
                }

                return gridSudoku;
            }
            else if ( (posX >= 3 && posX < 6) && posY < 3)
            {
                for (int row = 3; row < 6; row++)
                {
                    for (int column = 0; column < 3; column++)
                    {
                        if (sudokuBoard[row][column] != 0)
                        {
                            var entry = sudokuBoard[row][column];
                            gridSudoku.Add(entry);
                        }
                    }
                }

                return gridSudoku;
            }
            else if ( (posX >= 3 && posX < 6) && (posY >= 3 && posY < 6) )
            {
                for (int row = 3; row < 6; row++)
                {
                    for (int column = 3; column < 6; column++)
                    {
                        if (sudokuBoard[row][column] != 0)
                        {
                            var entry = sudokuBoard[row][column];
                            gridSudoku.Add(entry);
                        }
                    }
                }

                return gridSudoku;
            }
            else if ((posX >= 3 && posX < 6) && (posY >= 6 && posY < 9) )
            {
                for (int row = 3; row < 6; row++)
                {
                    for (int column = 6; column < 9; column++)
                    {
                        if (sudokuBoard[row][column] != 0)
                        {
                            var entry = sudokuBoard[row][column];
                            gridSudoku.Add(entry);
                        }
                    }
                }

                return gridSudoku;
            }
            else if ( (posX >= 6 && posX < 9) && posY < 3)
            {
                for (int row = 6; row < 9; row++)
                {
                    for (int column = 0; column < 3; column++)
                    {
                        if (sudokuBoard[row][column] != 0)
                        {
                            var entry = sudokuBoard[row][column];
                            gridSudoku.Add(entry);
                        }
                    }
                }

                return gridSudoku;
            }
            else if ((posX >= 6 && posX < 9) && (posY >= 3 && posY < 6) )
            {
                for (int row = 6; row < 9; row++)
                {
                    for (int column = 3; column < 6; column++)
                    {
                        if (sudokuBoard[row][column] != 0)
                        {
                            var entry = sudokuBoard[row][column];
                            gridSudoku.Add(entry);
                        }
                    }
                }

                return gridSudoku;
            }
            else if ((posX >= 6 && posX < 9) && (posY >= 6 && posY < 9) )
            {
                for (int row = 6; row < 9; row++)
                {
                    for (int column = 6; column < 9; column++)
                    {
                        if (sudokuBoard[row][column] != 0)
                        {
                            var entry = sudokuBoard[row][column];
                            gridSudoku.Add(entry);
                        }
                    }
                }

                return gridSudoku;
            }
            else
            {
                return gridSudoku;
            }
        }

        public bool CheckAnswer(Sudoku sudoku)
        {
            //Check for duplicates in row, column, and square
            var _sudoku = sudoku;
            var _board = _sudoku.sudokuBoard;
            int row = 0, column = 0;

            //Check Rows
            for (int i = 0; i < _board.Length; i++)
            {
                var rowGroups = _board[i].GroupBy(v => v);

                foreach(var number in rowGroups)
                {
                    if (number.Count() > 1)
                        return false;
                }
            }

            //Check columns
            for (int i = 0; i < _board.Length; i++)
            {
                var columnGroup = GetColumnSudoku(_board, i);
                var columnGroups = columnGroup.GroupBy(v => v);

                foreach (var number in columnGroups)
                {
                    if (number.Count() > 1)
                        return false;
                }
            }

            //Check grid
            while(row < 9)
            {
                while(column < 9)
                {
                    var gridGroup = GetGridSudoku(_board, row, column);
                    var gridGroups = gridGroup.GroupBy(v => v);

                    foreach(var number in gridGroups)
                    {
                        if (number.Count() > 1)
                            return false;
                    }

                    column += 3;
                }

                row += 3;
                column = 0;
            }

            return true;
        }

        public (int?[][], bool) SolveBoard(int?[][] sudokuBoard, int posX, int posY, bool finishedBoard)
        {
            var remainingNumbers = new List<int?>(new int?[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            var random = new Random();
            var viableBoard = finishedBoard;

            if (posY == 9)
            {
                posY = 0;
                if (posX + 1 == 9)
                {
                    viableBoard = true;
                    return (sudokuBoard, viableBoard);
                }
                else
                {
                    return SolveBoard(sudokuBoard, posX + 1, posY, viableBoard);
                }

            }

            var sudokuRow = sudokuBoard[posX].ToList();
            var sudokuColumn = GetColumnSudoku(sudokuBoard, posY);
            var sudokuGrid = GetGridSudoku(sudokuBoard, posX, posY);

            if (sudokuBoard[posX][posY] != null)
            {
                return SolveBoard(sudokuBoard, posX, posY + 1, viableBoard);
            }
            else
            {
                //Determine if there is a number we can select to put into the cell.
                var selectionNumbers = remainingNumbers.Except(sudokuRow).ToList();
                selectionNumbers = selectionNumbers.Except(sudokuColumn).ToList();
                selectionNumbers = selectionNumbers.Except(sudokuGrid).ToList();

                if (selectionNumbers.Count == 0)
                {
                    return (sudokuBoard, viableBoard);
                }
                else
                {
                    while (!viableBoard)
                    {
                        if (selectionNumbers.Count == 0)
                        {
                            return (sudokuBoard, viableBoard);
                        }

                        var index = random.Next(selectionNumbers.Count);
                        sudokuBoard[posX][posY] = selectionNumbers[index];
                        (sudokuBoard, viableBoard) = SolveBoard(sudokuBoard, posX, posY + 1, viableBoard);

                        if (!viableBoard)
                        {
                            selectionNumbers.Remove(selectionNumbers[index]);
                            sudokuBoard[posX][posY] = null;
                        }
                    }
                }
            }
            return (sudokuBoard, viableBoard);
        }
    }
}
