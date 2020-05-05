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
        //List<int> sudokuNumbers = new List<int>(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9} );
        SudokuGenerator sudokuGenerator = new SudokuGenerator();
        //bool columnPassed = false;

        public Sudoku()
        {
            InitializeGameBoard("hard");
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
            

            //Next steps:
            //Blank entries on playing board based on difficulty (easy, medium, hard)
            //Add ability to adjust entries for blanked spaces
            //Add functionality to solve the board
            //Add functionality to see the moves played in the side window
        }

        //To-Do:
        //Creating the board - Enter the column randomly from the squareArea list created above
        //As you continue, enter a different number in the column that is different
        
    }
}
