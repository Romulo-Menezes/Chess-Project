using System;
using ChessGame.Entities;

namespace ChessGame.View
{
    class ConsoleView
    {
        public static void ShowChessboard(Board board)
        {
            for(int i = 0; i < board.QtyRows; i++)
            {
                for (int j = 0; j < board.QtyColumns; j++)
                {
                    if(board.Pieces[i, j] == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.Pieces[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
