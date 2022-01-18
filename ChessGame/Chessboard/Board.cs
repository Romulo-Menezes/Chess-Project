namespace ChessGame.Chessboard
{
    class Board
    {
        public int QtyRows { get; private set; }
        public int QtyColumns { get; private set; }
        public Piece[,] Pieces { get; private set; }

        public Board()
        {
            QtyRows = 8;
            QtyColumns = 8;
            Pieces = new Piece[QtyRows, QtyColumns];
        }
    }
}
