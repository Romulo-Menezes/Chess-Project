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
        private HashSet<Piece> _pieces;
        private HashSet<Piece> _capturedPieces;

        public ChessGameController()
        {
            Board = new Board();
            CurrentPlayer = Color.White;
            GameTurn = 1;
            Ended = false;
            _pieces = new HashSet<Piece>();
            _capturedPieces = new HashSet<Piece>();

            InitBoard();
        }

        private void InitBoard()
        {
            PutPieces(new Rook(Board, Color.Black), new Position(0, 0));
            PutPieces(new Knight(Board, Color.Black), new Position(0, 1));
            PutPieces(new Bishop(Board, Color.Black), new Position(0, 2));
            PutPieces(new Queen(Board, Color.Black), new Position(0, 3));
            PutPieces(new King(Board, Color.Black), new Position(0, 4));
            PutPieces(new Bishop(Board, Color.Black), new Position(0, 5));
            PutPieces(new Knight(Board, Color.Black), new Position(0, 6));
            PutPieces(new Rook(Board, Color.Black), new Position(0, 7));

            PutPieces(new Rook(Board, Color.White), new Position(7, 0));
            PutPieces(new Knight(Board, Color.White), new Position(7, 1));
            PutPieces(new Bishop(Board, Color.White), new Position(7, 2));
            PutPieces(new Queen(Board, Color.White), new Position(7, 3));
            PutPieces(new King(Board, Color.White), new Position(7, 4));
            PutPieces(new Bishop(Board, Color.White), new Position(7, 5));
            PutPieces(new Knight(Board, Color.White), new Position(7, 6));
            PutPieces(new Rook(Board, Color.White), new Position(7, 7));

            for(int i = 0; i < 8; i++)
            {
                //PutPieces(new Pawn(Board, Color.Black), new Position(1, i));
                //PutPieces(new Pawn(Board, Color.White), new Position(6, i));
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

        private void MovePiece(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.ImcrementQtyMoves();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.AddPiece(piece, destiny);

            if(capturedPiece != null)
            {
                _capturedPieces.Add(capturedPiece);
            }

        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> temp = new HashSet<Piece>();
            foreach(Piece piece in _capturedPieces)
            {
                if(piece.Color == color)
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
            MovePiece(origin, destiny);
            GameTurn++;
            ChangePlayer();
        }

        public bool[,] AvailableMovements(Position position)
        {
            return Board.GetAvailableMovements(position);
        }

        public void ValidatePositionOrigin(Position position)
        {
            if(CurrentPlayer != Board.GetPieceColor(position))
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
