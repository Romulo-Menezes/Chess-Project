using System;
using ChessGame.Entities;
using ChessGame.Entities.Enums;

namespace ChessGame.View
{
    class ConsoleView
    {
        public static void ShowChessboard(Board board)
        {
            ConsoleColor temp = Console.ForegroundColor;
            for (int i = 0; i < board.QtyRows; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{8 - i} " );
                Console.ForegroundColor = temp;

                for (int j = 0; j < board.QtyColumns; j++)
                {
                    if(board.Pieces[i, j] == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        ShowPiece(board.Pieces[i, j]);
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  a b c d e f g h");
            Console.ForegroundColor = temp;
        }

        public static void ShowPiece(Piece piece)
        {
            ConsoleColor temp = Console.ForegroundColor;
            if (piece.Color == Color.Black)
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
