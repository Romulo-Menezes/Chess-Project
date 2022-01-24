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
                    ConsoleView.ShowGame(chessGame);
                }
                catch (ChessboardException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }


            }

        }
    }
}
