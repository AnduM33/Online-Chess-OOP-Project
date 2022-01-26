using System.Collections.Generic;
using System.Drawing;

namespace ChessGame
{
    class Queen : ChessPiece
    {
        public Queen(Point location, bool pieceColor)
        {
            this.location = location;
            this.pieceColor = pieceColor;
            if (pieceColor == true)
            {
                this.pieceImage = Properties.Resources.GoldenQueen;
            }
            else
            {
                this.pieceImage = Properties.Resources.DarkQueen;
            }
        }
        public override void CalculatePossibleMoves(List<ChessPiece> chessPieces)
        {
            possibleMoves.Clear();
            backupMoves.Clear();
            CanMoveHorizontally(chessPieces);
            CanMoveDiagonally(chessPieces);
        }
    }
}
