using System;
using ChessGame.Entities;
using ChessGame.Entities.Enums;
using ChessGame.Entities.Exceptions;
using ChessGame.View;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Position p1 = new Position(0, 0);
            Position p2 = new Position(1, 4);
            Position p3 = new Position(3, 6);
            Position p4 = new Position(0, 8);

            ConsoleView.ShowChessboard(board);
            Console.WriteLine();
            try 
            {
            board.SetPiecePosition(new King(board, Color.Black), p1);
            board.SetPiecePosition(new Bishop(board, Color.White), p2);
            board.SetPiecePosition(new Knight(board, Color.Black), p3);

            ConsoleView.ShowChessboard(board);
            }
            catch(ChessboardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
