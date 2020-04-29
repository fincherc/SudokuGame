using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
    public class Sudoku
    {
        public int[][] sudokuBoard = new int[9][];
        //List<int> sudokuNumbers = new List<int>(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9} );
        SudokuGenerator sudokuGenerator = new SudokuGenerator();
        //bool columnPassed = false;

        public Sudoku()
        {
            InitializeGameBoard();
        }

        public void InitializeGameBoard()
        {
            for(int i = 0; i < sudokuBoard.Length; i++)
            {
                sudokuBoard[i] = new int[9];
            }

            sudokuGenerator.FillGameBoard(sudokuBoard);

            //while(!columnPassed)
            //{
            //    if(sudokuGenerator.CheckAllColumns(sudokuBoard))
            //    {

            //    }
            //}
        }

        //To-Do:
        //Creating the board - Enter the column randomly from the squareArea list created above
        //As you continue, enter a different number in the column that is different
        
    }
}
