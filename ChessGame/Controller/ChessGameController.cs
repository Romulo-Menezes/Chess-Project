using System.Collections.Generic;
using ChessGame.Entities;
using ChessGame.Entities.Enums;
using ChessGame.Entities.Exceptions;
using ChessGame.View;

namespace ChessGame.Controller
{
    class ChessGameController
    {
        public Board Board { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public int GameTurn { get; private set; }
        public bool Ended { get; private set; }
        public bool Check { get; private set; }
        private HashSet<Piece> _pieces;
        private HashSet<Piece> _capturedPieces;
        public Piece VulnerableEnPassant { get; private set; }

        public ChessGameController()
        {
            Board = new Board();
            CurrentPlayer = Color.White;
            GameTurn = 1;
            Ended = false;
            Check = false;
            _pieces = new HashSet<Piece>();
            _capturedPieces = new HashSet<Piece>();
            VulnerableEnPassant = null;

            InitBoard();
        }

        private void InitBoard()
        {
            PutPieces(new Rook(Board, Color.Black), new Position(0, 0));
            PutPieces(new Knight(Board, Color.Black), new Position(0, 1));
            PutPieces(new Bishop(Board, Color.Black), new Position(0, 2));
            PutPieces(new Queen(Board, Color.Black), new Position(0, 3));
            PutPieces(new King(Board, Color.Black, this), new Position(0, 4));
            PutPieces(new Bishop(Board, Color.Black), new Position(0, 5));
            PutPieces(new Knight(Board, Color.Black), new Position(0, 6));
            PutPieces(new Rook(Board, Color.Black), new Position(0, 7));

            PutPieces(new Rook(Board, Color.White), new Position(7, 0));
            PutPieces(new Knight(Board, Color.White), new Position(7, 1));
            PutPieces(new Bishop(Board, Color.White), new Position(7, 2));
            PutPieces(new Queen(Board, Color.White), new Position(7, 3));
            PutPieces(new King(Board, Color.White, this), new Position(7, 4));
            PutPieces(new Bishop(Board, Color.White), new Position(7, 5));
            PutPieces(new Knight(Board, Color.White), new Position(7, 6));
            PutPieces(new Rook(Board, Color.White), new Position(7, 7));

            for (int i = 0; i < 8; i++)
            {
                PutPieces(new Pawn(Board, Color.Black, this), new Position(1, i));
                PutPieces(new Pawn(Board, Color.White, this), new Position(6, i));
            }
        }

        private void PutPieces(Piece piece, Position position)
        {
            Board.AddPiece(piece, position);
            _pieces.Add(piece);
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        private Piece MovePiece(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.ImcrementQtyMoves();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.AddPiece(piece, destiny);

            if (capturedPiece != null)
            {
                _capturedPieces.Add(capturedPiece);
            }

            // Special move: Castling
            if (piece is King && destiny.Column == origin.Column + 2)
            {
                Position rookO = new Position(origin.Row, origin.Column + 3);
                Position rookD = new Position(origin.Row, origin.Column + 1);
                Piece temp = Board.RemovePiece(rookO);
                temp.ImcrementQtyMoves();
                Board.AddPiece(temp, rookD);
            }

            if (piece is King && destiny.Column == origin.Column - 2)
            {
                Position rookO = new Position(origin.Row, origin.Column - 4);
                Position rookD = new Position(origin.Row, origin.Column - 1);
                Piece temp = Board.RemovePiece(rookO);
                temp.ImcrementQtyMoves();
                Board.AddPiece(temp, rookD);
            }

            // Special move: En Passant
            if (piece is Pawn)
            {
                if(origin.Column != destiny.Column && capturedPiece == null)
                {
                    Position pos = new Position(origin.Row, destiny.Column);
                    capturedPiece = Board.RemovePiece(pos);
                    _capturedPieces.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }

        private void UndoMove(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(destiny);
            piece.DecrementQtyMoves();
            if (capturedPiece != null)
            {
                _capturedPieces.Remove(capturedPiece);
                Board.AddPiece(capturedPiece, destiny);
            }
            Board.AddPiece(piece, origin);

            // Special move: Castling
            if (piece is King && destiny.Column == origin.Column + 2)
            {
                Position rookO = new Position(origin.Row, origin.Column + 3);
                Position rookD = new Position(origin.Row, origin.Column + 1);
                Piece temp = Board.RemovePiece(rookD);
                temp.DecrementQtyMoves();
                Board.AddPiece(temp, rookO);
            }

            if (piece is King && destiny.Column == origin.Column - 2)
            {
                Position rookO = new Position(origin.Row, origin.Column - 4);
                Position rookD = new Position(origin.Row, origin.Column - 1);
                Piece temp = Board.RemovePiece(rookD);
                temp.DecrementQtyMoves();
                Board.AddPiece(temp, rookO);
            }

            // Special move: En Passant
            if (piece is Pawn)
            {
                if (origin.Column != destiny.Column && capturedPiece == VulnerableEnPassant)
                {
                    Position pos = new Position(origin.Row, destiny.Column);
                    Board.AddPiece(Board.RemovePiece(destiny), pos);
                }
            }

        }

        private Color Adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece GetKing(Color color)
        {
            foreach (Piece piece in PiecesInGame(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            throw new ChessboardException($"There is no {color} King on the board!");
        }

        private bool IsThereCheck(Color color)
        {
            Piece king = GetKing(color);

            foreach (Piece piece in PiecesInGame(Adversary(color)))
            {
                bool[,] temp = piece.AvailableMovements();

                if (temp[king.GetRow(), king.GetColumn()])
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsInCheckmate(Color color)
        {
            if (!IsThereCheck(color))
            {
                return false;
            }

            foreach (Piece piece in PiecesInGame(color))
            {
                bool[,] temp = piece.AvailableMovements();
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (temp[i, j])
                        {
                            Position origin = piece.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = MovePiece(origin, destiny);
                            bool check = IsThereCheck(color);
                            UndoMove(origin, destiny, capturedPiece);
                            if (!check)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> temp = new HashSet<Piece>();
            foreach (Piece piece in _capturedPieces)
            {
                if (piece.Color == color)
                {
                    temp.Add(piece);
                }
            }
            return temp;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> temp = new HashSet<Piece>();
            foreach (Piece piece in _pieces)
            {
                if (piece.Color == color)
                {
                    temp.Add(piece);
                }
            }

            temp.ExceptWith(CapturedPieces(color));
            return temp;
        }

        public void MakeMovement(Position origin, Position destiny)
        {
            Piece capturedPiece = MovePiece(origin, destiny);

            if (IsThereCheck(CurrentPlayer))
            {
                UndoMove(origin, destiny, capturedPiece);
                throw new ChessboardException("You can't put yourself in check!");
            }

            Piece piece = Board.GetPiece(destiny);

            // Special move: Promotion
            if (piece is Pawn)
            {
                if((piece.Color == Color.White && piece.GetRow() == 0) || (piece.Color == Color.Black && piece.GetRow() == 7))
                {
                    piece = Board.RemovePiece(destiny);
                    _pieces.Remove(piece);
                    Color temp = piece.Color;
                    piece = new Queen(Board, temp);
                    Board.AddPiece(piece, destiny);
                }
            }

            // Special move: En Passant
            if (piece is Pawn && (destiny.Row == origin.Row + 2 || destiny.Row == origin.Row - 2))
            {
                VulnerableEnPassant = piece;
            }
            else
            {
                VulnerableEnPassant = null;
            }

            if (IsThereCheck(Adversary(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (IsInCheckmate(Adversary(CurrentPlayer)))
            {
                Ended = true;
            }
            else
            {
                GameTurn++;
                ChangePlayer();
            }

        }

        public bool[,] AvailableMovements(Position position)
        {
            return Board.GetAvailableMovements(position);
        }

        public void ValidatePositionOrigin(Position position)
        {
            if (CurrentPlayer != Board.GetPieceColor(position))
            {
                throw new ChessboardException("The chosen piece is not yours!");
            }
            if (!Board.ExistsAvailableMovements(position))
            {
                throw new ChessboardException("There are no possible moves for this chess piece!");
            }
        }

        public void ValidatePositionDestiny(Position origin, Position destiny)
        {
            if (!Board.CanMoveTo(origin, destiny))
            {
                throw new ChessboardException("Invalid position!");
            }
        }
    }
}
