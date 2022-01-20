using System;
using ChessGame.Entities;
using ChessGame.Entities.Enums;
using ChessGame.View;

namespace ChessGame.Controller
{
    class ChessGameController
    {
        public Board Board { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public int GameTurn { get; private set; }
        public bool Ended { get; private set; }

        public ChessGameController()
        {
            Board = new Board();
            CurrentPlayer = Color.White;
            GameTurn = 1;
            Ended = false;

            InitBoard();
        }

        private void InitBoard()
        {
            Board.AddPiece(new Rook(Board,Color.Black), new Position(0, 0));
            Board.AddPiece(new Knight(Board, Color.Black), new Position(0, 1));
            Board.AddPiece(new Bishop(Board, Color.Black), new Position(0, 2));
            Board.AddPiece(new Queen(Board, Color.Black), new Position(0, 3));
            Board.AddPiece(new King(Board, Color.Black), new Position(0, 4));
            Board.AddPiece(new Bishop(Board, Color.Black), new Position(0, 5));
            Board.AddPiece(new Knight(Board, Color.Black), new Position(0, 6));
            Board.AddPiece(new Rook(Board, Color.Black), new Position(0, 7));

            Board.AddPiece(new Rook(Board, Color.White), new Position(7, 0));
            Board.AddPiece(new Knight(Board, Color.White), new Position(7, 1));
            Board.AddPiece(new Bishop(Board, Color.White), new Position(7, 2));
            Board.AddPiece(new Queen(Board, Color.White), new Position(7, 3));
            Board.AddPiece(new King(Board, Color.White), new Position(7, 4));
            Board.AddPiece(new Bishop(Board, Color.White), new Position(7, 5));
            Board.AddPiece(new Knight(Board, Color.White), new Position(7, 6));
            Board.AddPiece(new Rook(Board, Color.White), new Position(7, 7));

            for(int i = 0; i < 8; i++)
            {
                Board.AddPiece(new Pawn(Board, Color.Black), new Position(1, i));
                Board.AddPiece(new Pawn(Board, Color.White), new Position(6, i));
            }
        }

        public void MovePiece(Position origin, Position destiny)
        {
            Board.AddPiece(Board.RemovePiece(origin), destiny);
        }

    }
}
