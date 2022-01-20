using System;
using ChessGame.Entities;
using ChessGame.Entities.Enums;
using ChessGame.Entities.Exceptions;
using ChessGame.Controller;
using ChessGame.View;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessGameController chessGame = new ChessGameController();

            while (!chessGame.Ended)
            {
                try
                {
                    ConsoleView.ShowChessboard(chessGame.Board);

                    Console.Write("\nOrigin position: ");
                    string origin = Console.ReadLine();
                    Console.Write("Destination position: ");
                    string destiny = Console.ReadLine();

                    char column1 = origin[0], column2 = destiny[0];
                    int row1 = int.Parse(origin[1] + "");
                    int row2 = int.Parse(destiny[1] + "");

                    chessGame.MovePiece(new ChessPosition(row1, column1).ToPosition(), new ChessPosition(row2, column2).ToPosition());
                }
                catch(ChessboardException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                

            }

        }
    }
}
