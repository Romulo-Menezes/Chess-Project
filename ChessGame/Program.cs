using System;
using ChessGame.Entities;
using ChessGame.View;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleView.ShowChessboard(new Board());
        }
    }
}
