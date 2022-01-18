using System;
using ChessGame.Chessboard;

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
                    Console.Write((board.Pieces[i, j] == null)?"-" : board.Pieces[i, j] 
                                      + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
