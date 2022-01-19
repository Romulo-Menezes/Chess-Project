﻿using System;
using ChessGame.Entities;
using ChessGame.Entities.Enums;

namespace ChessGame.View
{
    class ConsoleView
    {
        public static void ShowChessboard(Board board)
        {
            for(int i = 0; i < board.QtyRows; i++)
            {
                Console.Write($"{8 - i} " );
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
            Console.WriteLine("   a b c d e f g h");
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
