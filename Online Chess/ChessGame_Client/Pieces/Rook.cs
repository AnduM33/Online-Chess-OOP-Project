using System.Collections.Generic;
using System.Drawing;

namespace ChessGame
{
    class Rook : ChessPiece
    {
        public Rook(Point location, bool pieceColor)
        {
            this.location = location;
            this.pieceColor = pieceColor;
            if (pieceColor == true)
            {
                this.pieceImage = Properties.Resources.GoldenRook;
            }
            else
            {
                this.pieceImage = Properties.Resources.DarkRook;
            }
        }

        public override void CalculatePossibleMoves(List<ChessPiece> chessPieces)
        {
            possibleMoves.Clear();
            backupMoves.Clear();
            CanMoveHorizontally(chessPieces);
        }
    }
}
