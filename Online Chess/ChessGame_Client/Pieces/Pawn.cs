using System.Collections.Generic;
using System.Drawing;

namespace ChessGame
{
    class Pawn : ChessPiece
    {
        private bool hasMoved = false;
        public Pawn(Point location, bool pieceColor)
        {
            this.location = location;
            this.pieceColor = pieceColor;
            if (pieceColor == true)
            {
                this.pieceImage = Properties.Resources.GoldenPawn;
            }
            else
            {
                this.pieceImage = Properties.Resources.DarkPawn;
            }
        }

        public override void CalculatePossibleMoves(List<ChessPiece> chessPieces)
        {
            possibleMoves.Clear();
            backupMoves.Clear();

            if (pieceColor == true)
            {
                if (location.X - 1 >= 0 && this.FindSelectedPiece(new Point(location.X - 1, location.Y), chessPieces) == null)
                {
                    possibleMoves.Add(new Point(location.X - 1, location.Y));

                    if (hasMoved == false && location.X - 2 >= 0 && this.FindSelectedPiece(new Point(location.X - 2, location.Y), chessPieces) == null)
                    {
                        possibleMoves.Add(new Point(location.X - 2, location.Y));
                    }
                }

                ChessPiece possibleTarget;

                if (location.X - 1 >= 0 && location.Y + 1 < 8)
                {
                    possibleTarget = this.FindSelectedPiece(new Point(location.X - 1, location.Y + 1), chessPieces);
                    if (possibleTarget != null && possibleTarget.GetColor() != pieceColor && !(possibleTarget is King))
                    {
                        possibleMoves.Add(new Point(location.X - 1, location.Y + 1));
                    }
                    backupMoves.Add(new Point(location.X - 1, location.Y + 1));
                }

                if (location.X - 1 >= 0 && location.Y - 1 >= 0)
                {
                    possibleTarget = this.FindSelectedPiece(new Point(location.X - 1, location.Y - 1), chessPieces);
                    if (possibleTarget != null && possibleTarget.GetColor() != pieceColor && !(possibleTarget is King))
                    {
                        possibleMoves.Add(new Point(location.X - 1, location.Y - 1));
                    }
                    backupMoves.Add(new Point(location.X - 1, location.Y - 1));
                }

            }

            if (pieceColor == false)
            {
                if (location.X + 1 < 8 && this.FindSelectedPiece(new Point(location.X + 1, location.Y), chessPieces) == null)
                {
                    possibleMoves.Add(new Point(location.X + 1, location.Y));

                    if (hasMoved == false && location.X + 2 < 8 && this.FindSelectedPiece(new Point(location.X + 2, location.Y), chessPieces) == null)
                    {
                        possibleMoves.Add(new Point(location.X + 2, location.Y));
                    }
                }

                ChessPiece possibleTarget;
                if (location.X + 1 < 8 && location.Y + 1 < 8)
                {
                    possibleTarget = this.FindSelectedPiece(new Point(location.X + 1, location.Y + 1), chessPieces);
                    if (possibleTarget != null && possibleTarget.GetColor() != pieceColor && !(possibleTarget is King))
                    {
                        possibleMoves.Add(new Point(location.X + 1, location.Y + 1));
                    }
                    backupMoves.Add(new Point(location.X + 1, location.Y + 1));
                }

                if (location.X + 1 < 8 && location.Y - 1 >= 0)
                {
                    possibleTarget = this.FindSelectedPiece(new Point(location.X + 1, location.Y - 1), chessPieces);
                    if (possibleTarget != null && possibleTarget.GetColor() != pieceColor && !(possibleTarget is King))
                    {
                        possibleMoves.Add(new Point(location.X + 1, location.Y - 1));
                    }
                    backupMoves.Add(new Point(location.X + 1, location.Y - 1));
                }
            }
        }

        public override void SetHasMoved()
        {
            this.hasMoved = true;
        }
    }
}
