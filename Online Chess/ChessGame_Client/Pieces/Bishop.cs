using System.Collections.Generic;
using System.Drawing;

namespace ChessGame
{
    class Bishop : ChessPiece
    {
        public Bishop(Point location, bool pieceColor)
        {
            this.location = location;
            this.pieceColor = pieceColor;
            if (pieceColor == true)
            {
                this.pieceImage = Properties.Resources.GoldenBishop;
            }
            else
            {
                this.pieceImage = Properties.Resources.DarkBishop;
            }
        }

        public override void CalculatePossibleMoves(List<ChessPiece> chessPieces)
        {
            possibleMoves.Clear();
            backupMoves.Clear();
            CanMoveDiagonally(chessPieces);
        }
    }
}
