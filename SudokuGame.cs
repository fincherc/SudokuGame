using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SudokuGame
{
    public partial class SudokuGame : Form
    {
        
        public Sudoku _sudoku = new Sudoku();
        public SudokuGame()
        {
            _sudoku = new Sudoku(showDifficultyDialogBox());
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
            var textBoxEntry = 1;

            for(int row = 0; row < sudoku.sudokuBoard.Length; row++)
            {
                for(int column = 0; column < sudoku.sudokuBoard.Length; column++)
                {
                    TextBox textBox = Controls.Find($"TextBox{textBoxEntry}", true).OfType<TextBox>().FirstOrDefault();
                    textBox.Text = sudoku.sudokuBoard[row][column].ToString();

                    if(textBox.Text != "")
                    {
                        textBox.ReadOnly = true;
                    }
                        
                    else
                    {
                        textBox.BackColor = Color.LightBlue; 
                        textBox.ReadOnly = false;
                    }

                    textBoxEntry++;
                }
            }
        }

        private void FinishSudoku(int?[][] sudoku)
        {
            var textBoxEntry = 1;

            for (int row = 0; row < sudoku.Length; row++)
            {
                for (int column = 0; column < sudoku.Length; column++)
                {
                    TextBox textBox = Controls.Find($"TextBox{textBoxEntry}", true).OfType<TextBox>().FirstOrDefault();

                    if (textBox.Text == "")
                    {
                        textBox.Text = sudoku[row][column].ToString();
                    }

                    textBoxEntry++;
                }
            }
        }

        private string showDifficultyDialogBox()
        {
            GameDifficultyForm difficultyForm = new GameDifficultyForm();
            difficultyForm.ShowDialog();

            return difficultyForm.SelectionMade;
        }

        private void Validate_Text(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                int i;
                if (int.TryParse(tb.Text, out i))
                {
                    if (i >= 1 && i <= 9)
                        return;
                }
                else if(tb.Text == "")
                    return;
            }
            MessageBox.Show("Please select a number and one that's 1 and 9");
            e.Cancel = true;
        }

        private void checkAnswerButton_Click(object sender, EventArgs e)
        {
            SudokuSolver _solver = new SudokuSolver();
            var answer = _solver.CheckAnswer(_sudoku);

            if (answer)
            {
                SudokuCompleteForm completeForm = new SudokuCompleteForm();
                completeForm.ShowDialog();
            }
            else
            {
                SudokuNotCompleteForm notCompleteForm = new SudokuNotCompleteForm();
                notCompleteForm.ShowDialog();
            }
        }

        private void solverButton_Click(object sender, EventArgs e)
        {
            SudokuSolver _solver = new SudokuSolver();
            var (completedBoard, finishedBoard) = _solver.SolveBoard(_sudoku.sudokuBoard, 0, 0, false);

            if(finishedBoard)
            {
                _sudoku.sudokuBoard = completedBoard;
                FinishSudoku(_sudoku.sudokuBoard);
                SudokuCompleteForm completeForm = new SudokuCompleteForm();
                completeForm.ShowDialog();
            }
        }

        private void UpdateSudoku(object sender, EventArgs e)
        {
            int row = 0;
            TextBox tb = sender as TextBox;
            var textBoxNumber = Int32.Parse(new string(tb.Name.ToCharArray().Where(c => char.IsDigit(c)).ToArray())) - 1;

            while (textBoxNumber >= 9)
            {
                textBoxNumber -= 9;
                row++;
            }

            if (tb.Text == "")
                _sudoku.sudokuBoard[row][textBoxNumber] = null;
            else
                _sudoku.sudokuBoard[row][textBoxNumber] = Int32.Parse(tb.Text);
        }
    }
}
