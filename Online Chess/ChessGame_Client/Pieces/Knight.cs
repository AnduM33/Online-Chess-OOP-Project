using System.Collections.Generic;
using System.Drawing;

namespace ChessGame
{
    class Knight : ChessPiece
    {
        public Knight(Point location, bool pieceColor)
        {
            this.location = location;
            this.pieceColor = pieceColor;
            if (pieceColor == true)
            {
                this.pieceImage = Properties.Resources.GoldenKnight;
            }
            else
            {
                this.pieceImage = Properties.Resources.DarkKnight;
            }
        }
        public override void CalculatePossibleMoves(List<ChessPiece> chessPieces)
        {
            possibleMoves.Clear();
            backupMoves.Clear();
            Point temp;
            ChessPiece tempChessPiece;

            temp = location;
            temp.X += 1;
            temp.Y += 2;
            if (temp.X < 8 && temp.Y < 8)
            {

                tempChessPiece = FindSelectedPiece(temp, chessPieces);
                if (tempChessPiece == null || (tempChessPiece.GetColor() != this.GetColor() && !(tempChessPiece is King)))
                {
                    possibleMoves.Add(temp);
                }
                else
                {
                    backupMoves.Add(temp);
                }
            }

            temp = location;
            temp.X += 1;
            temp.Y -= 2;

            if (temp.X < 8 && temp.Y >= 0)
            {

                tempChessPiece = FindSelectedPiece(temp, chessPieces);
                if (tempChessPiece == null || (tempChessPiece.GetColor() != this.GetColor() && !(tempChessPiece is King)))
                {
                    possibleMoves.Add(temp);
                }
                else
                {
                    backupMoves.Add(temp);
                }
            }

            temp = location;
            temp.X -= 1;
            temp.Y += 2;
            if (temp.X >= 0 && temp.Y < 8)
            {

                tempChessPiece = FindSelectedPiece(temp, chessPieces);
                if (tempChessPiece == null || (tempChessPiece.GetColor() != this.GetColor() && !(tempChessPiece is King)))
                {
                    possibleMoves.Add(temp);
                }
                else
                {
                    backupMoves.Add(temp);
                }
            }

            temp = location;
            temp.X -= 1;
            temp.Y -= 2;
            if (temp.X >= 0 && temp.Y >= 0)
            {

                tempChessPiece = FindSelectedPiece(temp, chessPieces);
                if (tempChessPiece == null || (tempChessPiece.GetColor() != this.GetColor() && !(tempChessPiece is King)))
                {
                    possibleMoves.Add(temp);
                }
                else
                {
                    backupMoves.Add(temp);
                }
            }


            temp = location;
            temp.X += 2;
            temp.Y += 1;
            if (temp.X < 8 && temp.Y < 8)
            {

                tempChessPiece = FindSelectedPiece(temp, chessPieces);
                if (tempChessPiece == null || (tempChessPiece.GetColor() != this.GetColor() && !(tempChessPiece is King)))
                {
                    possibleMoves.Add(temp);
                }
                else
                {
                    backupMoves.Add(temp);
                }
            }

            temp = location;
            temp.X += 2;
            temp.Y -= 1;

            if (temp.X < 8 && temp.Y >= 0)
            {

                tempChessPiece = FindSelectedPiece(temp, chessPieces);
                if (tempChessPiece == null || (tempChessPiece.GetColor() != this.GetColor() && !(tempChessPiece is King)))
                {
                    possibleMoves.Add(temp);
                }
                else
                {
                    backupMoves.Add(temp);
                }
            }

            temp = location;
            temp.X -= 2;
            temp.Y += 1;
            if (temp.X >= 0 && temp.Y < 8)
            {

                tempChessPiece = FindSelectedPiece(temp, chessPieces);
                if (tempChessPiece == null || (tempChessPiece.GetColor() != this.GetColor() && !(tempChessPiece is King)))
                {
                    possibleMoves.Add(temp);
                }
                else
                {
                    backupMoves.Add(temp);
                }
            }

            temp = location;
            temp.X -= 2;
            temp.Y -= 1;
            if (temp.X >= 0 && temp.Y >= 0)
            {

                tempChessPiece = FindSelectedPiece(temp, chessPieces);
                if (tempChessPiece == null || (tempChessPiece.GetColor() != this.GetColor() && !(tempChessPiece is King)))
                {
                    possibleMoves.Add(temp);
                }
                else
                {
                    backupMoves.Add(temp);
                }
            }
        }
    }
}
