using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
    public class SudokuGenerator
    {
        static Random random = new Random();
        //Sudoku sudoku = new Sudoku();
        SudokuSolver solver = new SudokuSolver();
        public int?[][] FillGameBoard(int?[][] board)
        {
            
            List<int> tempNum = new List<int>();
            var filledArea = board;

            List<int?> sudokuNumbers = new List<int?>(new int?[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            List<int?> gridNum = new List<int?>();
            bool playableBoard = false;

            //Entering the numbers square, row, and column
            //Do the first three squares - top left, middle, bottom right

            var row = 0;
            var column = 0;

            while (row < 3)
            {
                column = 0;
                while (column < 3)
                {
                    var chosenNumber = random.Next(sudokuNumbers.Count);
                    if (!gridNum.Contains(sudokuNumbers[chosenNumber]))
                    {
                        filledArea[row][column] = sudokuNumbers[chosenNumber];
                        gridNum.Add(sudokuNumbers[chosenNumber]);
                        column++;
                    }
                }

                row++;
            }

            gridNum.Clear();

            while (row < 6)
            {
                column = 3;
                while (column < 6)
                {
                    var chosenNumber = random.Next(sudokuNumbers.Count);
                    if (!gridNum.Contains(sudokuNumbers[chosenNumber]))
                    {
                        filledArea[row][column] = sudokuNumbers[chosenNumber];
                        gridNum.Add(sudokuNumbers[chosenNumber]);
                        column++;
                    }
                }

                row++;
            }

            gridNum.Clear();

            while (row < 9)
            {
                column = 6;
                while (column < 9)
                {
                    var chosenNumber = random.Next(sudokuNumbers.Count);
                    if (!gridNum.Contains(sudokuNumbers[chosenNumber]))
                    {
                        filledArea[row][column] = sudokuNumbers[chosenNumber];
                        gridNum.Add(sudokuNumbers[chosenNumber]);
                        column++;
                    }
                }

                row++;
            }

            row = 0;
            column = 0;

            //Run check all squares (grid) for the three generated squares to ensure unique layout, if bool is false, we need to run FillBoard again
            //until squares are fully unique for solution to be found.
            if(CheckSquares(filledArea, row, column))
            {
                solver.FillBoard(filledArea, row, column, sudokuNumbers, playableBoard);
            }
            else
            {
                //Remove all entries in current board, run the board again
                for(int i = 0; i < filledArea.Length; i++)
                {
                    filledArea[i].ToList().Clear();
                    filledArea[i].ToArray();
                }

                FillGameBoard(filledArea);
            }

            return filledArea;
        }

        private bool CheckSquares(int?[][] sudokuBoard, int row, int column)
        {
            while(row < 3)
            {
                while(column < 3)
                {
                    if( sudokuBoard[row][column] == sudokuBoard[row + 3][column + 3] 
                        || sudokuBoard[row][column] == sudokuBoard[row + 6][column + 6] )
                    {
                        //Unique squares wasn't obtained, return false
                        return false;
                    }
                    column++;
                }
                row++;
            }

            return true;
        }

        public int?[][] BlankOutSquares(int?[][] board, string difficulty)
        {
            var boardDifficulty = difficulty;
            var gameBoard = board;

            switch(boardDifficulty.ToLower())
            {
                case "easy":
                    //Blank out 33% of the board (27 squares)
                    //3 per row
                    for(int row = 0; row < gameBoard.Length; row++)
                    {
                        int blanksEntered = 0;
                        for (int column = 0; column < gameBoard.Length; column++)
                        {
                            bool randomBool = random.Next(0, 2) > 0;

                            if(blanksEntered < 1 && column < 3 && randomBool)
                            {
                                gameBoard[row][column] = null;
                                blanksEntered++;
                                continue;
                            }
                            else if(blanksEntered == 0 && column == 2)
                            {
                                gameBoard[row][column] = null;
                                blanksEntered++;
                                continue;
                            }
                            else if (blanksEntered < 2 && (column >= 3 && column < 6) && randomBool)
                            {
                                gameBoard[row][column] = null;
                                blanksEntered++;
                                continue;
                            }
                            else if (blanksEntered == 1 && column == 5 )
                            {
                                gameBoard[row][column] = null;
                                blanksEntered++;
                                continue;
                            }
                            else if (blanksEntered < 3 && (column >= 6 && column < 9) && randomBool)
                            {
                                gameBoard[row][column] = null;
                                blanksEntered++;
                                continue;
                            }
                            else if (blanksEntered == 2 && column == 8 )
                            {
                                gameBoard[row][column] = null;
                                blanksEntered++;
                                continue;
                            }
                        }
                    }
                    break;
                case "medium":
                    //Blank out 50-55% of the board (45 squares)
                    //5 per row
                    for (int row = 0; row < gameBoard.Length; row++)
                    {
                        int blanksEntered = 0;
                        for (int column = 0; column < gameBoard.Length; column++)
                        {
                            if (blanksEntered == 5)
                                break;
                            bool randomBool = random.Next(0, 2) > 0;

                            if (blanksEntered < 5 && randomBool && gameBoard[row][column] != null)
                            {
                                gameBoard[row][column] = null;
                                blanksEntered++;
                            }
                            
                            if(blanksEntered < 5 && column == 8)
                            {
                                column = -1;
                            }
                        }
                    }
                    break;
                case "hard":
                    //Blank out about 75% of the board (63 squares)
                    //7 per row
                    for (int row = 0; row < gameBoard.Length; row++)
                    {
                        int blanksEntered = 0;
                        for (int column = 0; column < gameBoard.Length; column++)
                        {
                            if (blanksEntered == 7)
                                break;
                            bool randomBool = random.Next(0, 2) > 0;

                            if (blanksEntered < 7 && randomBool && gameBoard[row][column] != null)
                            {
                                gameBoard[row][column] = null;
                                blanksEntered++;
                            }
                            
                            if (blanksEntered < 7 && column == 8)
                            {
                                column = -1;
                            }
                        }
                    }
                    break;
            }

            return gameBoard;
        }
    }
}
