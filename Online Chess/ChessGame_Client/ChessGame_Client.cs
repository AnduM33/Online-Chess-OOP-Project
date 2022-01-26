using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class ChessGame_Client : Form
    {
        private const int boardSize = 8;
        private const int squareSize = 100;
        private PieceUC[,] squares = new PieceUC[boardSize, boardSize];
        private List<ChessPiece> chessPieces = new List<ChessPiece>();
        private List<Point> potentialMoves = new List<Point>();
        ChessPiece selectedPiece;
        String clientInstructions = null;
        bool whitesTurn = true;
        bool whiteInCheck = false;
        bool blackInCheck = false;
        bool isConnected = false;
        bool checkMatePlayer = false;
        bool checkMate = false;
        public SwapPawn swapPawn;
        //1 - K, 2 - B, 3 - R, 4 - Q
        public int pieceCode = 0;
        bool pawnIsPromoted = false;

        public TcpClient client;
        public NetworkStream clientStream;
        public bool ascult;
        public ChessGame_Client clientForm;
        public Thread t;

        public ChessGame_Client()
        {
            InitializeComponent();

            GenerateChessBoard();

            swapPawn = new SwapPawn(this);

            clientForm = this;
        }

        private void GenerateChessBoard()
        {
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    squares[x, y] = new PieceUC
                    {
                        Size = new Size(squareSize, squareSize),
                        Location = new Point(y * squareSize, x * squareSize),
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    this.Controls.Add(squares[x, y]);
                    squares[x, y].Click += PieceClick;
                }
            }

            SetBoardPieces();

            SetBoardColors();

            PlaceBoardPieces();

            CalculateAllPossibleMoves(chessPieces);
        }
        private void PieceClick(object sender, EventArgs e)
        {
            PieceUC piece = sender as PieceUC;
            SetBoardColors();
            Point pieceLocation = new Point(piece.Location.Y / squareSize, piece.Location.X / squareSize);

            if (isConnected == false)
            {
                AddText("No connection to server");
                return;
            }

            if (potentialMoves.Contains(pieceLocation))
            {
                clientInstructions = null;
                clientInstructions += selectedPiece.GetLocation().X + " " + selectedPiece.GetLocation().Y + " ";
                MovePiece(pieceLocation, selectedPiece);
                clientInstructions += pieceLocation.X + " " + pieceLocation.Y + " ";
                if (selectedPiece is Pawn)
                {
                    if (pieceLocation.X == 0)
                    {
                        pawnIsPromoted = true;
                        int index;
                        for (index = 0; index < chessPieces.Count() - 2; index++)
                        {
                            if (chessPieces[index].GetLocation() == pieceLocation)
                            {
                                break;
                            }
                        }
                        swapPawn.ShowDialog();
                        if (pieceCode == 1)
                        {
                            chessPieces[index] = new Knight(pieceLocation, true);
                        }
                        if (pieceCode == 2)
                        {
                            chessPieces[index] = new Bishop(pieceLocation, true);
                        }
                        if (pieceCode == 3)
                        {
                            chessPieces[index] = new Rook(pieceLocation, true);
                        }
                        if (pieceCode == 4)
                        {
                            chessPieces[index] = new Queen(pieceLocation, true);
                        }
                        piece.BackgroundImage = chessPieces[index].GetImage();
                    }
                }
                if (pawnIsPromoted == true)
                {
                    clientInstructions += 1 + " " + pieceCode + " ";
                }
                else
                {
                    clientInstructions += 0 + " " + 0 + " ";
                }
                pawnIsPromoted = false;
                CalculateAllPossibleMoves(chessPieces);
                TestForCheck(chessPieces);
                SetBoardColors();
                TestForCheckMate();
                if (checkMate == true)
                {
                    clientInstructions += 1 + " ";
                }
                else
                {
                    clientInstructions += 0 +" ";
                }
                if(checkMatePlayer == true)
                {
                    clientInstructions += 1;
                }
                else
                {
                    clientInstructions += 0;
                }
                potentialMoves.Clear();
                SendInstructions();
            }

            ChessPiece chessPiece = FindSelectedPiece(pieceLocation, chessPieces);
            if (chessPiece == null)
            {
                AddText("Empty panel");
                selectedPiece = null;
                if (potentialMoves.Any())
                {
                    potentialMoves.Clear();
                }
                return;
            }
            selectedPiece = chessPiece;

            if (chessPiece.GetColor() == true && whitesTurn == true)
            {
                if (!(chessPiece is King && whiteInCheck == true))
                {
                    if ((pieceLocation.X + pieceLocation.Y) % 2 == 0)
                    {
                        squares[pieceLocation.X, pieceLocation.Y].BackColor = Color.LightGreen;
                    }
                    else
                    {
                        squares[pieceLocation.X, pieceLocation.Y].BackColor = Color.Green;
                    }
                }

                potentialMoves = new List<Point>(chessPiece.GetPossibleMoves());

                if (potentialMoves.Any())
                {
                    foreach (Point point in potentialMoves)
                    {
                        if ((point.X + point.Y) % 2 == 0)
                        {
                            squares[point.X, point.Y].BackColor = Color.LightGreen;
                        }
                        else
                        {
                            squares[point.X, point.Y].BackColor = Color.Green;
                        }
                    }
                }
            }
            else
            {
                if (potentialMoves.Any())
                {
                    AddText("Clears list");
                    potentialMoves.Clear();
                }
            }

        }

        private void MovePiece(Point pieceLocation, ChessPiece selectedPiece)
        {
            squares[selectedPiece.GetLocation().X, selectedPiece.GetLocation().Y].BackgroundImage = null;

            if (FindSelectedPiece(pieceLocation, chessPieces) != null)
            {
                chessPieces.Remove(FindSelectedPiece(pieceLocation, chessPieces));
            }

            String action = null;
            action += "Moving " + selectedPiece.GetType() + Environment.NewLine;
            action += "From: " + selectedPiece.GetLocation().X + " " + selectedPiece.GetLocation().Y + Environment.NewLine;
            action += "To: " + pieceLocation.X + " " + pieceLocation.Y;
            AddText(action);

            squares[pieceLocation.X, pieceLocation.Y].BackgroundImage = selectedPiece.GetImage();
            selectedPiece.SetLocation(pieceLocation);
            whitesTurn = !whitesTurn;
            if (selectedPiece is Pawn)
            {
                selectedPiece.SetHasMoved();
            }
        }

        private void TestMove(Point pieceLocation, ChessPiece selectedPiece, List<ChessPiece> tempList)
        {
            if (FindSelectedPiece(pieceLocation, tempList) != null)
            {
                tempList.Remove(FindSelectedPiece(pieceLocation, tempList));
            }
            selectedPiece.SetLocation(pieceLocation);
            CalculateAllPossibleMoves(tempList);
            TestForCheck(tempList);
        }

        private void ExecuteInstructions(String instructions)
        {
            Point pieceLocation;
            clientInstructions = instructions;
            if (clientInstructions != null)
            {
                String[] instructionSet = clientInstructions.Split(' ');
                selectedPiece = FindSelectedPiece(new Point(7 - Convert.ToInt32(instructionSet[0]), 7 - Convert.ToInt32(instructionSet[1])), chessPieces);
                pieceLocation = new Point(7 - Convert.ToInt32(instructionSet[2]), 7 - Convert.ToInt32(instructionSet[3]));
                MovePiece(pieceLocation, selectedPiece);
                if (Convert.ToInt32(instructionSet[4]) == 1)
                {
                    int index;
                    for (index = 0; index < chessPieces.Count() - 2; index++)
                    {
                        if (chessPieces[index].GetLocation() == pieceLocation)
                        {
                            break;
                        }
                    }
                    if (Convert.ToInt32(instructionSet[5]) == 1)
                    {
                        chessPieces[index] = new Knight(pieceLocation, false);
                    }
                    if (Convert.ToInt32(instructionSet[5]) == 2)
                    {
                        chessPieces[index] = new Bishop(pieceLocation, false);
                    }
                    if (Convert.ToInt32(instructionSet[5]) == 3)
                    {
                        chessPieces[index] = new Rook(pieceLocation, false);
                    }
                    if (Convert.ToInt32(instructionSet[5]) == 4)
                    {
                        chessPieces[index] = new Queen(pieceLocation, false);
                    }
                    squares[pieceLocation.X, pieceLocation.Y].BackgroundImage = chessPieces[index].GetImage();
                }
                CalculateAllPossibleMoves(chessPieces);
                TestForCheck(chessPieces);
                SetBoardColors();
                if (Convert.ToInt32(instructionSet[6]) == 1)
                {
                    if (Convert.ToInt32(instructionSet[7]) == 1)
                    {
                        AddText("White is in Check Mate");
                    }
                    else
                    {
                        AddText("Black is in Check Mate");
                    }
                    StopGame();
                }
                clientInstructions = null;
            }
        }

        private ChessPiece FindSelectedPiece(Point pieceLocation, List<ChessPiece> chessPieces)
        {
            foreach (ChessPiece chessPiece in chessPieces)
            {
                if (chessPiece.GetLocation() == pieceLocation)
                {
                    return chessPiece;
                }
            }
            return null;
        }
        private void SetBoardPieces()
        {
            chessPieces.Add(new Rook(new Point(0, 0), false));
            chessPieces.Add(new Knight(new Point(0, 1), false));
            chessPieces.Add(new Bishop(new Point(0, 2), false));
            chessPieces.Add(new Queen(new Point(0, 3), false));
            chessPieces.Add(new Bishop(new Point(0, 5), false));
            chessPieces.Add(new Knight(new Point(0, 6), false));
            chessPieces.Add(new Rook(new Point(0, 7), false));

            for (int i = 0; i < boardSize; i++)
            {
                chessPieces.Add(new Pawn(new Point(1, i), false));
            }

            chessPieces.Add(new Rook(new Point(7, 0), true));
            chessPieces.Add(new Knight(new Point(7, 1), true));
            chessPieces.Add(new Bishop(new Point(7, 2), true));
            chessPieces.Add(new Queen(new Point(7, 3), true));
            chessPieces.Add(new Bishop(new Point(7, 5), true));
            chessPieces.Add(new Knight(new Point(7, 6), true));
            chessPieces.Add(new Rook(new Point(7, 7), true));

            for (int i = 0; i < boardSize; i++)
            {
                chessPieces.Add(new Pawn(new Point(6, i), true));
            }

            chessPieces.Add(new King(new Point(0, 4), false));
            chessPieces.Add(new King(new Point(7, 4), true));
        }
        private void SetBoardColors()
        {
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    if ((x + y) % 2 == 0)
                    {
                        squares[x, y].BackColor = Color.White;
                    }
                    else
                    {
                        squares[x, y].BackColor = Color.Black;
                    }
                    if (whiteInCheck == true && squares[x, y].BackgroundImage == chessPieces[chessPieces.Count() - 1].GetImage())
                    {
                        squares[x, y].BackColor = Color.Red;
                    }
                    if (blackInCheck == true && squares[x, y].BackgroundImage == chessPieces[chessPieces.Count() - 2].GetImage())
                    {
                        squares[x, y].BackColor = Color.Red;
                    }
                }
            }
        }
        private void PlaceBoardPieces()
        {
            foreach (ChessPiece chessPiece in chessPieces)
            {
                squares[chessPiece.GetLocation().X, chessPiece.GetLocation().Y].BackgroundImage = chessPiece.GetImage();
            }
        }

        private void StopGame()
        {
            foreach (PieceUC square in squares)
            {
                square.Enabled = false;
            }
        }
        private void CalculateAllPossibleMoves(List<ChessPiece> chessPieces)
        {
            foreach (ChessPiece chessPiece in chessPieces)
            {
                chessPiece.CalculatePossibleMoves(chessPieces);
            }
        }

        private void TestForCheck(List<ChessPiece> chessPieces)
        {

            whiteInCheck = false;
            blackInCheck = false;
            ChessPiece whiteKing = new ChessPiece();
            ChessPiece blackKing = new ChessPiece();
            foreach (ChessPiece chessPiece in chessPieces)
            {
                if (chessPiece is King)
                {
                    if (chessPiece.GetColor() == true)
                    {
                        whiteKing = chessPiece;
                    }
                    else
                    {
                        blackKing = chessPiece;
                    }
                }
            }

            foreach (ChessPiece chessPiece in chessPieces)
            {
                if (chessPiece.GetColor() != whiteKing.GetColor())
                {
                    foreach (Point possibleMove in chessPiece.GetPossibleMoves())
                    {
                        if (possibleMove == whiteKing.GetLocation())
                        {
                            AddText("White king is in Check");
                            whiteInCheck = true;
                            return;
                        }
                    }
                    foreach (Point backupMove in chessPiece.GetBackupMoves())
                    {
                        if (backupMove == whiteKing.GetLocation())
                        {
                            AddText("White king is in Check");
                            whiteInCheck = true;
                            return;
                        }
                    }
                }
                if (chessPiece.GetColor() != blackKing.GetColor())
                {
                    foreach (Point possibleMove in chessPiece.GetPossibleMoves())
                    {
                        if (possibleMove == blackKing.GetLocation())
                        {
                            AddText("Black king is in Check");
                            blackInCheck = true;
                            return;
                        }
                    }
                    foreach (Point backupMove in chessPiece.GetBackupMoves())
                    {
                        if (backupMove == blackKing.GetLocation())
                        {
                            AddText("Black king is in Check");
                            blackInCheck = true;
                            return;
                        }
                    }
                }
            }
        }

        private void TestForCheckMate()
        {
            bool defend = false;
            if (whiteInCheck == true && !((chessPieces[chessPieces.Count() - 1].GetPossibleMoves()).Any()))
            {
                List<ChessPiece> tempList = new List<ChessPiece>();
                Clone(tempList);
                int nrOfPieces = tempList.Count() - 2;
                for (int index = 0; index < nrOfPieces; index++)
                {
                    if (tempList[index].GetColor() == true)
                    {
                        int n = (tempList[index].GetPossibleMoves()).Count();
                        for (int i = 0; i < n; i++)
                        {
                            Point move = (tempList[index].GetPossibleMoves())[i];
                            TestMove(move, tempList[index], tempList);
                            if (whiteInCheck == false)
                            {
                                checkMate = false;
                                defend = true;
                            }
                            whiteInCheck = true;
                            tempList = new List<ChessPiece>();
                            Clone(tempList);
                            if (defend == true)
                            {
                                return;
                            }
                        }
                    }
                }
                if (defend == false)
                {
                    checkMate = true;
                    checkMatePlayer = true;
                    AddText("White is in Check Mate");
                    StopGame();
                }
            }
            if (blackInCheck == true && !((chessPieces[chessPieces.Count() - 2].GetPossibleMoves()).Any()))
            {
                List<ChessPiece> tempList = new List<ChessPiece>();
                Clone(tempList);
                int nrOfPieces = tempList.Count() - 2;
                for (int index = 0; index < nrOfPieces; index++)
                {
                    if (tempList[index].GetColor() == false)
                    {
                        int n = (tempList[index].GetPossibleMoves()).Count();
                        for (int i = 0; i < n; i++)
                        {
                            Point move = (tempList[index].GetPossibleMoves())[i];
                            TestMove(move, tempList[index], tempList);
                            if (blackInCheck == false)
                            {
                                checkMate = false;
                                defend = true;
                            }
                            blackInCheck = true;
                            tempList = new List<ChessPiece>();
                            Clone(tempList);
                            if (defend == true)
                            {
                                return;
                            }
                        }
                    }
                }
                if (defend == false)
                {
                    checkMate = true;
                    checkMatePlayer = false;
                    AddText("Black is in Check Mate");
                    StopGame();
                }
            }
        }

        private void Clone(List<ChessPiece> tempList)
        {
            foreach (ChessPiece chesspiece in chessPieces)
            {
                if (chesspiece is Bishop)
                {
                    tempList.Add(new Bishop(chesspiece.GetLocation(), chesspiece.GetColor()));
                }
                if (chesspiece is King)
                {
                    tempList.Add(new King(chesspiece.GetLocation(), chesspiece.GetColor()));
                }
                if (chesspiece is Knight)
                {
                    tempList.Add(new Knight(chesspiece.GetLocation(), chesspiece.GetColor()));
                }
                if (chesspiece is Pawn)
                {
                    tempList.Add(new Pawn(chesspiece.GetLocation(), chesspiece.GetColor()));
                }
                if (chesspiece is Queen)
                {
                    tempList.Add(new Queen(chesspiece.GetLocation(), chesspiece.GetColor()));
                }
                if (chesspiece is Rook)
                {
                    tempList.Add(new Rook(chesspiece.GetLocation(), chesspiece.GetColor()));
                }
                foreach (Point move in chesspiece.GetPossibleMoves())
                {
                    tempList[tempList.Count() - 1].AddMove(move);
                }
                foreach (Point move in chesspiece.GetBackupMoves())
                {
                    tempList[tempList.Count() - 1].AddBackupMove(move);
                }
            }
        }
        public void AddText(String text)
        {
            this.textBox1.Text += text + Environment.NewLine;
            this.textBox1.SelectionStart = textBox1.Text.Length;
            this.textBox1.ScrollToCaret();
        }

        private void Asculta_client()
        {
            StreamReader citire = new StreamReader(clientStream);
            String dateClient;
            while (ascult)
            {
                dateClient = citire.ReadLine();
                MethodInvoker m = new MethodInvoker(() => clientForm.ExecuteInstructions(dateClient));
                clientForm.textBox1.Invoke(m);
            }
        }

        private void SendInstructions()
        {
            try
            {

                StreamWriter scriere = new StreamWriter(clientStream);
                scriere.AutoFlush = true; // enable automatic flushing

                scriere.WriteLine(clientInstructions);
            }
            finally
            {

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ascult = false;
            if (t != null)
            {
                t.Abort();
            }
            if (clientStream != null)
            {
                clientStream.Close();
            }
            if (client != null)
            {
                client.Close();
            }
            Application.Exit();
        }
        private void BtnConect_Click(object sender, EventArgs e)
        {
            if (connectLabel.Text == "Connect")
            {
                if (tbAddress.Text.Length > 0)
                {
                    client = new TcpClient(tbAddress.Text, 8098);
                    ascult = true;
                    t = new Thread(new ThreadStart(Asculta_client));
                    t.Start();
                    clientStream = client.GetStream();

                    isConnected = true;
                    //btnSend.Enabled = true;
                    label1.Visible = false;
                    tbAddress.Visible = false;
                    connectLabel.Text = "Disconect";
                }
                else
                {
                    MessageBox.Show("Specificati adresa de IP");
                }
            }
            else
            {
                isConnected = false;
                ascult = false;
                t.Abort();
                StreamWriter scriere = new StreamWriter(clientStream);
                scriere.AutoFlush = true; // enable automatic flushing
                scriere.WriteLine("#Gata");
            }

        }
        private void FClient_Load(object sender, EventArgs e)
        {

        }
        private void ChessGame_Client_Load(object sender, EventArgs e)
        {

        }
    }
}
