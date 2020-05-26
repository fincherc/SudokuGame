using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
    public class Sudoku
    {
        public int?[][] sudokuBoard = new int?[9][];
        SudokuGenerator sudokuGenerator = new SudokuGenerator();

        public Sudoku(string difficulty)
        {
            var _difficulty = difficulty;
            InitializeGameBoard(_difficulty);
        }

        public Sudoku()
        {

        }

        public void InitializeGameBoard(string difficulty)
        {
            var gameDifficulty = difficulty;
            for(int i = 0; i < sudokuBoard.Length; i++)
            {
                sudokuBoard[i] = new int?[9];
            }

            sudokuGenerator.FillGameBoard(sudokuBoard);
            sudokuGenerator.BlankOutSquares(sudokuBoard, gameDifficulty);

            //Optional: Add functionality to see the moves played in the side window
        }
    }
}
