using System;
using System.Linq;
using System.Windows.Forms;

namespace SudokuGame
{
    public partial class SudokuGame : Form
    {
        public SudokuGame()
        {

            var _sudoku = new Sudoku();
            InitializeComponent();
            AddSudoku(_sudoku);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddSudoku(Sudoku sudoku)
        {
            var labelEntry = 1;

            for(int row = 0; row < sudoku.sudokuBoard.Length; row++)
            {
                for(int column = 0; column < sudoku.sudokuBoard.Length; column++)
                {
                    Label label = Controls.Find($"label{labelEntry}", true).OfType<Label>().FirstOrDefault();
                    label.Text = sudoku.sudokuBoard[row][column].ToString();
                    labelEntry++;
                }
            }
        }

        private void menuClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
