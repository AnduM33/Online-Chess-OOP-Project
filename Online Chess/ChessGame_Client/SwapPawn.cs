using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class SwapPawn : Form
    {
        ChessGame_Client main;
        
        public SwapPawn(ChessGame_Client main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void SwapPawn_Load(object sender, EventArgs e)
        {

        }

        private void SelectPiece(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Name == "buttonKnight")
            {
                main.pieceCode = 1;
            }
            if (button.Name == "buttonBishop")
            {
                main.pieceCode = 2;
            }
            if (button.Name == "buttonRook")
            {
                main.pieceCode = 3;
            }
            if (button.Name == "buttonQueen")
            {
                main.pieceCode = 4;
            }
            this.Close();
        }
    }
}
