using System.Collections.Generic;
using System.Drawing;

namespace ChessGame
{
    class King : ChessPiece
    {
        public King(Point location, bool pieceColor)
        {
            this.location = location;
            this.pieceColor = pieceColor;
            if (pieceColor == true)
            {
                this.pieceImage = Properties.Resources.GoldenKing;
            }
            else
            {
                this.pieceImage = Properties.Resources.DarkKing;
            }
        }

        public override void CalculatePossibleMoves(List<ChessPiece> chessPieces)
        {
            possibleMoves.Clear();
            backupMoves.Clear();
            Point temp;
            ChessPiece tempChessPiece;
            List<Point> tempMoves = new List<Point>();

            temp = location;
            temp.X++;
            if (temp.X < 8)
            {
                bool isAvailable = true;
                for (int i = 0; i < chessPieces.Count - 1; i++)
                {
                    if (chessPieces[i].GetColor() != pieceColor)
                    {
                        if (!(chessPieces[i] is Pawn))
                        {
                            tempMoves = chessPieces[i].GetPossibleMoves();

                            foreach (Point possibleMove in tempMoves)
                            {
                                if (possibleMove == temp)
                                {
                                    isAvailable = false;
                                    break;
                                }
                            }
                        }

                        if (isAvailable == false)
                        {
                            break;
                        }

                        tempMoves = chessPieces[i].GetBackupMoves();

                        foreach (Point backupMoves in tempMoves)
                        {
                            if (backupMoves == temp)
                            {
                                isAvailable = false;
                                break;
                            }
                        }

                        if (isAvailable == false)
                        {
                            break;
                        }
                    }
                }
                if (isAvailable == true)
                {
                    tempChessPiece = FindSelectedPiece(temp, chessPieces);

                    if (tempChessPiece == null || tempChessPiece.GetColor() != this.GetColor())
                    {
                        possibleMoves.Add(temp);
                    }
                }
                else
                {
                    backupMoves.Add(temp);
                }
            }

            temp = location;
            temp.X--;
            if (temp.X >= 0)
            {
                bool isAvailable = true;
                for (int i = 0; i < chessPieces.Count - 1; i++)
                {
                    if (chessPieces[i].GetColor() != pieceColor)
                    {
                        if (!(chessPieces[i] is Pawn))
                        {
                            tempMoves = chessPieces[i].GetPossibleMoves();

                            foreach (Point possibleMove in tempMoves)
                            {
                                if (possibleMove == temp)
                                {
                                    isAvailable = false;
                                    break;
                                }
                            }
                        }

                        if (isAvailable == false)
                        {
                            break;
                        }

                        tempMoves = chessPieces[i].GetBackupMoves();

                        foreach (Point backupMoves in tempMoves)
                        {
                            if (backupMoves == temp)
                            {
                                isAvailable = false;
                                break;
                            }
                        }

                        if (isAvailable == false)
                        {
                            break;
                        }
                    }
                }
                if (isAvailable == true)
                {
                    tempChessPiece = FindSelectedPiece(temp, chessPieces);

                    if (tempChessPiece == null || tempChessPiece.GetColor() != this.GetColor())
                    {
                        possibleMoves.Add(temp);
                    }
                }
                else
                {
                    backupMoves.Add(temp);
                }
            }

            temp = location;
            temp.Y++;
            if (temp.Y < 8)
            {

                bool isAvailable = true;
                for (int i = 0; i < chessPieces.Count - 1; i++)
                {
                    if (chessPieces[i].GetColor() != pieceColor)
                    {
                        if (!(chessPieces[i] is Pawn))
                        {
                            tempMoves = chessPieces[i].GetPossibleMoves();

                            foreach (Point possibleMove in tempMoves)
                            {
                                if (possibleMove == temp)
                                {
                                    isAvailable = false;
                                    break;
                                }
                            }
                        }

                        if (isAvailable == false)
                        {
                            break;
                        }

                        tempMoves = chessPieces[i].GetBackupMoves();

                        foreach (Point backupMoves in tempMoves)
                        {
                            if (backupMoves == temp)
                            {
                                isAvailable = false;
                                break;
                            }
                        }

                        if (isAvailable == false)
                        {
                            break;
                        }
                    }
                }
                if (isAvailable == true)
                {
                    tempChessPiece = FindSelectedPiece(temp, chessPieces);

                    if (tempChessPiece == null || tempChessPiece.GetColor() != this.GetColor())
                    {
                        possibleMoves.Add(temp);
                    }
                }
                else
                {
                    backupMoves.Add(temp);
                }
            }

            temp = location;
            temp.Y--;
            if (temp.Y >= 0)
            {

                bool isAvailable = true;
                for (int i = 0; i < chessPieces.Count - 1; i++)
                {
                    if (chessPieces[i].GetColor() != pieceColor)
                    {
                        if (!(chessPieces[i] is Pawn))
                        {
                            tempMoves = chessPieces[i].GetPossibleMoves();

                            foreach (Point possibleMove in tempMoves)
                            {
                                if (possibleMove == temp)
                                {
                                    isAvailable = false;
                                    break;
                                }
                            }
                        }

                        if (isAvailable == false)
                        {
                            break;
                        }

                        tempMoves = chessPieces[i].GetBackupMoves();

                        foreach (Point backupMoves in tempMoves)
                        {
                            if (backupMoves == temp)
                            {
                                isAvailable = false;
                                break;
                            }
                        }

                        if (isAvailable == false)
                        {
                            break;
                        }
                    }
                }
                if (isAvailable == true)
                {
                    tempChessPiece = FindSelectedPiece(temp, chessPieces);

                    if (tempChessPiece == null || tempChessPiece.GetColor() != this.GetColor())
                    {
                        possibleMoves.Add(temp);
                    }
                }
                else
                {
                    backupMoves.Add(temp);
                }
            }

            temp = location;
            temp.X++;
            temp.Y++;
            if (temp.X < 8 && temp.Y < 8)
            {

                bool isAvailable = true;
                for (int i = 0; i < chessPieces.Count - 1; i++)
                {
                    if (chessPieces[i].GetColor() != pieceColor)
                    {
                        if (!(chessPieces[i] is Pawn))
                        {
                            tempMoves = chessPieces[i].GetPossibleMoves();

                            foreach (Point possibleMove in tempMoves)
                            {
                                if (possibleMove == temp)
                                {
                                    isAvailable = false;
                                    break;
                                }
                            }
                        }

                        if (isAvailable == false)
                        {
                            break;
                        }

                        tempMoves = chessPieces[i].GetBackupMoves();

                        foreach (Point backupMoves in tempMoves)
                        {
                            if (backupMoves == temp)
                            {
                                isAvailable = false;
                                break;
                            }
                        }

                        if (isAvailable == false)
                        {
                            break;
                        }
                    }
                }
                if (isAvailable == true)
                {
                    tempChessPiece = FindSelectedPiece(temp, chessPieces);

                    if (tempChessPiece == null || tempChessPiece.GetColor() != this.GetColor())
                    {
                        possibleMoves.Add(temp);
                    }
                }
                else
                {
                    backupMoves.Add(temp);
                }
            }

            temp = location;
            temp.X++;
            temp.Y--;
            if (temp.X < 8 && temp.Y >= 0)
            {

                bool isAvailable = true;
                for (int i = 0; i < chessPieces.Count - 1; i++)
                {
                    if (chessPieces[i].GetColor() != pieceColor)
                    {
                        if (!(chessPieces[i] is Pawn))
                        {
                            tempMoves = chessPieces[i].GetPossibleMoves();

                            foreach (Point possibleMove in tempMoves)
                            {
                                if (possibleMove == temp)
                                {
                                    isAvailable = false;
                                    break;
                                }
                            }
                        }

                        if (isAvailable == false)
                        {
                            break;
                        }

                        tempMoves = chessPieces[i].GetBackupMoves();

                        foreach (Point backupMoves in tempMoves)
                        {
                            if (backupMoves == temp)
                            {
                                isAvailable = false;
                                break;
                            }
                        }

                        if (isAvailable == false)
                        {
                            break;
                        }
                    }
                }
                if (isAvailable == true)
                {
                    tempChessPiece = FindSelectedPiece(temp, chessPieces);

                    if (tempChessPiece == null || tempChessPiece.GetColor() != this.GetColor())
                    {
                        possibleMoves.Add(temp);
                    }
                }
                else
                {
                    backupMoves.Add(temp);
                }
            }

            temp = location;
            temp.X--;
            temp.Y++;
            if (temp.X >= 0 && temp.Y < 8)
            {

                bool isAvailable = true;
                for (int i = 0; i < chessPieces.Count - 1; i++)
                {
                    if (chessPieces[i].GetColor() != pieceColor)
                    {
                        if (!(chessPieces[i] is Pawn))
                        {
                            tempMoves = chessPieces[i].GetPossibleMoves();

                            foreach (Point possibleMove in tempMoves)
                            {
                                if (possibleMove == temp)
                                {
                                    isAvailable = false;
                                    break;
                                }
                            }
                        }

                        if (isAvailable == false)
                        {
                            break;
                        }

                        tempMoves = chessPieces[i].GetBackupMoves();

                        foreach (Point backupMoves in tempMoves)
                        {
                            if (backupMoves == temp)
                            {
                                isAvailable = false;
                                break;
                            }
                        }

                        if (isAvailable == false)
                        {
                            break;
                        }
                    }
                }
                if (isAvailable == true)
                {
                    tempChessPiece = FindSelectedPiece(temp, chessPieces);

                    if (tempChessPiece == null || tempChessPiece.GetColor() != this.GetColor())
                    {
                        possibleMoves.Add(temp);
                    }
                }
                else
                {
                    backupMoves.Add(temp);
                }
            }

            temp = location;
            temp.X--;
            temp.Y--;
            if (temp.X >= 0 && temp.Y >= 0)
            {

                bool isAvailable = true;
                for (int i = 0; i < chessPieces.Count - 1; i++)
                {
                    if (chessPieces[i].GetColor() != pieceColor)
                    {
                        if (!(chessPieces[i] is Pawn))
                        {
                            tempMoves = chessPieces[i].GetPossibleMoves();

                            foreach (Point possibleMove in tempMoves)
                            {
                                if (possibleMove == temp)
                                {
                                    isAvailable = false;
                                    break;
                                }
                            }
                        }

                        if (isAvailable == false)
                        {
                            break;
                        }

                        tempMoves = chessPieces[i].GetBackupMoves();

                        foreach (Point backupMoves in tempMoves)
                        {
                            if (backupMoves == temp)
                            {
                                isAvailable = false;
                                break;
                            }
                        }

                        if (isAvailable == false)
                        {
                            break;
                        }
                    }
                }
                if (isAvailable == true)
                {
                    tempChessPiece = FindSelectedPiece(temp, chessPieces);

                    if (tempChessPiece == null || tempChessPiece.GetColor() != this.GetColor())
                    {
                        possibleMoves.Add(temp);
                    }
                }
                else
                {
                    backupMoves.Add(temp);
                }
            }
        }
    }
}
