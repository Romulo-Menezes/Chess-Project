using System;
using System.Collections.Generic;
using ChessGame.Entities;
using ChessGame.Entities.Enums;
using ChessGame.Controller;

namespace ChessGame.View
{
    class ConsoleView
    {
        public static void ShowGame(ChessGameController chessGame)
        {
            ShowInformation(chessGame);

            Console.Write("Origin position: ");

            string origin = Console.ReadLine();
            Position posOrigin = ChessPosition.StringToPosition(origin);
            chessGame.ValidatePositionOrigin(posOrigin);

            ShowInformation(chessGame, chessGame.AvailableMovements(posOrigin));

            Console.Write("Destination position: ");

            string destiny = Console.ReadLine();
            Position posDestiny = ChessPosition.StringToPosition(destiny);
            chessGame.ValidatePositionDestiny(posOrigin, posDestiny);

            chessGame.MakeMovement(posOrigin, posDestiny);
        }
        public static void ShowChessboard(Board board)
        {
            ConsoleColor foreground = Console.ForegroundColor;
            for (int i = 0; i < board.QtyRows; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{8 - i} ");
                Console.ForegroundColor = foreground;

                for (int j = 0; j < board.QtyColumns; j++)
                {
                    ShowPiece(board.Pieces[i, j]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  a b c d e f g h\n");
            Console.ForegroundColor = foreground;
        }

        public static void ShowChessboard(Board board, bool[,] availableMovements)
        {
            ConsoleColor foreground = Console.ForegroundColor;
            ConsoleColor background = Console.BackgroundColor;
            for (int i = 0; i < board.QtyRows; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{8 - i} ");
                Console.ForegroundColor = foreground;

                for (int j = 0; j < board.QtyColumns; j++)
                {
                    if (availableMovements[i, j])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.BackgroundColor = background;
                    }
                    ShowPiece(board.Pieces[i, j]);
                    Console.BackgroundColor = background;
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  a b c d e f g h\n");
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
        }

        public static void ShowPiece(Piece piece)
        {
            ConsoleColor temp = Console.ForegroundColor;
            if (piece == null)
            {
                Console.Write("- ");
            }
            else if (piece.Color == Color.Black)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(piece + " ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(piece + " ");
            }
            Console.ForegroundColor = temp;
        }

        public static void ShowInformation(ChessGameController chessGame)
        {
            Console.Clear();
            Console.WriteLine($"Game turn: {chessGame.GameTurn}");
            Console.WriteLine($"Current player: {chessGame.CurrentPlayer}\n");

            ShowChessboard(chessGame.Board);
            ShowCapturedPieces(chessGame);

        }

        public static void ShowInformation(ChessGameController chessGame, bool[,] availableMovements)
        {
            Console.Clear();
            Console.WriteLine($"Game turn: {chessGame.GameTurn}");
            Console.WriteLine($"Current player: {chessGame.CurrentPlayer}\n");

            ShowChessboard(chessGame.Board, availableMovements);
            ShowCapturedPieces(chessGame);

        }

        public static void ShowCapturedPieces(ChessGameController chessGame)
        {
            Console.WriteLine("Captured pieces:");
            Console.Write("White: ");
            ShowCollection(chessGame.CapturedPieces(Color.White));
            Console.Write("Black: ");
            ShowCollection(chessGame.CapturedPieces(Color.Black));
            Console.WriteLine();
        }

        public static void ShowCollection(HashSet<Piece> pieces)
        {
            Console.Write("[ ");

            foreach(Piece p in pieces)
            {
                Console.Write($"{p} ");
            }
            Console.WriteLine("]");
        }
    }
}
