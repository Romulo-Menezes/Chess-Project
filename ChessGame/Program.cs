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
                    Console.Clear();
                    Console.WriteLine($"Game turn: {chessGame.GameTurn}");
                    Console.WriteLine($"Current player: {chessGame.CurrentPlayer}\n");
                    ConsoleView.ShowChessboard(chessGame.Board);


                    Console.Write("\nOrigin position: ");

                    string origin = Console.ReadLine();
                    char column1 = origin[0];
                    int row1 = int.Parse(origin[1] + "");
                    Position posOrigin = new ChessPosition(row1, column1).ToPosition();
                    chessGame.ValidatePositionOrigin(posOrigin);

                    bool[,] availableMovements = chessGame.AvailableMovements(posOrigin);

                    Console.Clear();
                    Console.WriteLine($"Game turn: {chessGame.GameTurn}");
                    Console.WriteLine($"Current player:{chessGame.CurrentPlayer}\n");
                    ConsoleView.ShowChessboard(chessGame.Board, availableMovements);                    

                    Console.Write("Destination position: ");

                    string destiny = Console.ReadLine();
                    char column2 = destiny[0];
                    int row2 = int.Parse(destiny[1] + "");
                    Position posDestiny = new ChessPosition(row2, column2).ToPosition();
                    chessGame.ValidatePositionDestiny(posOrigin, posDestiny);

                    chessGame.MakeMovement(posOrigin, posDestiny);
                }
                catch(ChessboardException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                

            }

        }
    }
}
