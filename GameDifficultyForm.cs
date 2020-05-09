using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuGame
{
    public partial class GameDifficultyForm : Form
    {
        private string selectionMade;

        public string SelectionMade 
        { 
            get { return selectionMade; }
            set { selectionMade = value; } 
        }

        public GameDifficultyForm()
        {
            InitializeComponent();
        }

        private void easyButton_Click(object sender, EventArgs e)
        {
            selectionMade = "easy";
            this.Close();
        }

        private void mediumButton_Click(object sender, EventArgs e)
        {
            selectionMade = "medium";
            this.Close();
        }

        private void hardButton_Click(object sender, EventArgs e)
        {
            selectionMade = "hard";
            this.Close();
        }
    }
}
