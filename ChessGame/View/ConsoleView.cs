using System;
using ChessGame.Entities;
using ChessGame.Entities.Enums;

namespace ChessGame.View
{
    class ConsoleView
    {
        public static void ShowChessboard(Board board)
        {
            ConsoleColor foreground = Console.ForegroundColor;
            for (int i = 0; i < board.QtyRows; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{8 - i} " );
                Console.ForegroundColor = foreground;

                for (int j = 0; j < board.QtyColumns; j++)
                {
                    ShowPiece(board.Pieces[i, j]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  a b c d e f g h");
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
                    if(availableMovements[i, j])
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
            Console.WriteLine("  a b c d e f g h");
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
        }

        public static void ShowPiece(Piece piece)
        {
            ConsoleColor temp = Console.ForegroundColor;
            if(piece == null)
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

    }
}
