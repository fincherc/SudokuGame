using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SudokuGame
{
    public partial class SudokuGame : Form
    {
        public SudokuGame()
        {
            var _sudoku = new Sudoku(showDifficultyDialogBox());
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
                        textBox.ReadOnly = true;
                    else
                        textBox.ReadOnly = false;

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
    }
}
