using System.Collections.Generic;
using System.Drawing;

namespace ChessGame
{
    class ChessPiece
    {
        protected Point location;
        protected bool pieceColor;
        protected Image pieceImage;
        protected List<Point> possibleMoves = new List<Point>();
        protected List<Point> backupMoves = new List<Point>();

        public Point GetLocation()
        {
            return location;
        }
        public void SetLocation(Point newLocation)
        {
            this.location = newLocation;
        }
        public Image GetImage()
        {
            return pieceImage;
        }
        public bool GetColor()
        {
            return pieceColor;
        }
        public virtual void CalculatePossibleMoves(List<ChessPiece> chessPieces)
        {
            return;
        }

        public List<Point> GetPossibleMoves()
        {
            return possibleMoves;
        }

        public List<Point> GetBackupMoves()
        {
            return backupMoves;
        }
        public void AddMove(Point move)
        {
            this.possibleMoves.Add(move);
        }
        public void AddBackupMove(Point move)
        {
            this.backupMoves.Add(move);
        }
        protected ChessPiece FindSelectedPiece(Point location, List<ChessPiece> chessPieces)
        {
            foreach (ChessPiece chessPiece in chessPieces)
            {
                if (chessPiece.GetLocation() == location)
                    return chessPiece;
            }
            return null;
        }
        public virtual void SetHasMoved()
        {
            return;
        }

        public virtual void SetCheck()
        {
            return;
        }

        protected void CanMoveHorizontally(List<ChessPiece> chessPieces)
        {
            Point temp;
            ChessPiece tempChessPiece;

            temp = location;
            temp.X++;
            while (temp.X < 8 && FindSelectedPiece(temp, chessPieces) == null)
            {
                possibleMoves.Add(temp);
                temp.X++;
            }
            tempChessPiece = FindSelectedPiece(temp, chessPieces);
            if (tempChessPiece != null)
            {
                if (tempChessPiece.GetColor() == this.GetColor())
                {
                    backupMoves.Add(temp);
                }
                if (tempChessPiece.GetColor() != this.GetColor())
                {
                    if (!(tempChessPiece is King))
                    {
                        possibleMoves.Add(temp);
                    }
                    else
                    {
                        backupMoves.Add(temp);
                        temp.X++;
                        if (temp.X < 8 && (FindSelectedPiece(temp, chessPieces) == null || FindSelectedPiece(temp, chessPieces).GetColor() == this.GetColor()))
                        {
                            backupMoves.Add(temp);
                        }
                    }
                }
            }

            temp = location;
            temp.Y++;
            while (temp.Y < 8 && FindSelectedPiece(temp, chessPieces) == null)
            {
                possibleMoves.Add(temp);
                temp.Y++;
            }
            tempChessPiece = FindSelectedPiece(temp, chessPieces);
            if (tempChessPiece != null)
            {
                if (tempChessPiece.GetColor() == this.GetColor())
                {
                    backupMoves.Add(temp);
                }
                if (tempChessPiece.GetColor() != this.GetColor())
                {
                    if (!(tempChessPiece is King))
                    {
                        possibleMoves.Add(temp);
                    }
                    else
                    {
                        backupMoves.Add(temp);
                        temp.Y++;
                        if (temp.Y < 8 && (FindSelectedPiece(temp, chessPieces) == null || FindSelectedPiece(temp, chessPieces).GetColor() == this.GetColor()))
                        {
                            backupMoves.Add(temp);
                        }
                    }
                }
            }

            temp = location;
            temp.X--;
            while (temp.X >= 0 && FindSelectedPiece(temp, chessPieces) == null)
            {
                possibleMoves.Add(temp);
                temp.X--;
            }
            tempChessPiece = FindSelectedPiece(temp, chessPieces);
            if (tempChessPiece != null)
            {
                if (tempChessPiece.GetColor() == this.GetColor())
                {
                    backupMoves.Add(temp);
                }
                if (tempChessPiece.GetColor() != this.GetColor())
                {
                    if (!(tempChessPiece is King))
                    {
                        possibleMoves.Add(temp);
                    }
                    else
                    {
                        backupMoves.Add(temp);
                        temp.X--;
                        if (temp.X >= 0 && (FindSelectedPiece(temp, chessPieces) == null || FindSelectedPiece(temp, chessPieces).GetColor() == this.GetColor()))
                        {
                            backupMoves.Add(temp);
                        }
                    }
                }
            }

            temp = location;
            temp.Y--;
            while (temp.Y >= 0 && FindSelectedPiece(temp, chessPieces) == null)
            {
                possibleMoves.Add(temp);
                temp.Y--;
            }
            tempChessPiece = FindSelectedPiece(temp, chessPieces);
            if (tempChessPiece != null)
            {
                if (tempChessPiece.GetColor() == this.GetColor())
                {
                    backupMoves.Add(temp);
                }
                if (tempChessPiece.GetColor() != this.GetColor())
                {
                    if (!(tempChessPiece is King))
                    {
                        possibleMoves.Add(temp);
                    }
                    else
                    {
                        backupMoves.Add(temp);
                        temp.Y--;
                        if (temp.Y >= 0 && (FindSelectedPiece(temp, chessPieces) == null || FindSelectedPiece(temp, chessPieces).GetColor() == this.GetColor()))
                        {
                            backupMoves.Add(temp);
                        }
                    }
                }
            }
        }

        protected void CanMoveDiagonally(List<ChessPiece> chessPieces)
        {
            Point temp;
            ChessPiece tempChessPiece;

            temp = location;
            temp.X++;
            temp.Y++;
            while (temp.X < 8 && temp.Y < 8 && FindSelectedPiece(temp, chessPieces) == null)
            {
                possibleMoves.Add(temp);
                temp.X++;
                temp.Y++;
            }
            tempChessPiece = FindSelectedPiece(temp, chessPieces);
            if (tempChessPiece != null)
            {
                if (tempChessPiece.GetColor() == this.GetColor())
                {
                    backupMoves.Add(temp);
                }
                if (tempChessPiece.GetColor() != this.GetColor())
                {
                    if (!(tempChessPiece is King))
                    {
                        possibleMoves.Add(temp);
                    }
                    else
                    {
                        backupMoves.Add(temp);
                        temp.X++;
                        temp.Y++;
                        if (temp.X < 8 && temp.Y < 8 && (FindSelectedPiece(temp, chessPieces) == null || FindSelectedPiece(temp, chessPieces).GetColor() == this.GetColor()))
                        {
                            backupMoves.Add(temp);
                        }
                    }
                }
            }

            temp = location;
            temp.X--;
            temp.Y++;
            while (temp.X >= 0 && temp.Y < 8 && FindSelectedPiece(temp, chessPieces) == null)
            {
                possibleMoves.Add(temp);
                temp.X--;
                temp.Y++;
            }
            tempChessPiece = FindSelectedPiece(temp, chessPieces);
            if (tempChessPiece != null)
            {
                if (tempChessPiece.GetColor() == this.GetColor())
                {
                    backupMoves.Add(temp);
                }
                if (tempChessPiece.GetColor() != this.GetColor())
                {
                    if (!(tempChessPiece is King))
                    {
                        possibleMoves.Add(temp);
                    }
                    else
                    {
                        backupMoves.Add(temp);
                        temp.X--;
                        temp.Y++;
                        if (temp.X >= 0 && temp.Y < 8 && (FindSelectedPiece(temp, chessPieces) == null || FindSelectedPiece(temp, chessPieces).GetColor() == this.GetColor()))
                        {
                            backupMoves.Add(temp);
                        }
                    }
                }
            }

            temp = location;
            temp.X++;
            temp.Y--;
            while (temp.X < 8 && temp.Y >= 0 && FindSelectedPiece(temp, chessPieces) == null)
            {
                possibleMoves.Add(temp);
                temp.X++;
                temp.Y--;
            }
            tempChessPiece = FindSelectedPiece(temp, chessPieces);
            if (tempChessPiece != null)
            {

                if (tempChessPiece.GetColor() == this.GetColor())
                {
                    backupMoves.Add(temp);
                }
                if (tempChessPiece.GetColor() != this.GetColor())
                {
                    if (!(tempChessPiece is King))
                    {
                        possibleMoves.Add(temp);
                    }
                    else
                    {
                        backupMoves.Add(temp);
                        temp.X++;
                        temp.Y--;
                        if (temp.X < 8 && temp.Y >= 0 && (FindSelectedPiece(temp, chessPieces) == null || FindSelectedPiece(temp, chessPieces).GetColor() == this.GetColor()))
                        {
                            backupMoves.Add(temp);
                        }
                    }
                }
            }

            temp = location;
            temp.X--;
            temp.Y--;
            while (temp.X >= 0 && temp.Y >= 0 && FindSelectedPiece(temp, chessPieces) == null)
            {
                possibleMoves.Add(temp);
                temp.X--;
                temp.Y--;
            }
            tempChessPiece = FindSelectedPiece(temp, chessPieces);
            if (tempChessPiece != null)
            {
                if (tempChessPiece.GetColor() == this.GetColor())
                {
                    backupMoves.Add(temp);
                }
                if (tempChessPiece.GetColor() != this.GetColor())
                {
                    if (!(tempChessPiece is King))
                    {
                        possibleMoves.Add(temp);
                    }
                    else
                    {
                        backupMoves.Add(temp);
                        temp.X--;
                        temp.Y--;
                        if (temp.X >= 0 && temp.Y >= 0 && (FindSelectedPiece(temp, chessPieces) == null || FindSelectedPiece(temp, chessPieces).GetColor() == this.GetColor()))
                        {
                            backupMoves.Add(temp);
                        }
                    }
                }
            }
        }
    }
}
