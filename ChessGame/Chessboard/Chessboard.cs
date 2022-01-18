namespace ChessGame.Chessboard
{
    class Chessboard
    {
        public int QtyRows { get; private set; }
        public int QtyColumns { get; private set; }
        public Piece[,] Pieces { get; private set; }

        public Chessboard()
        {
            QtyRows = 8;
            QtyColumns = 8;
            Pieces = new Piece[QtyRows, QtyColumns];
        }
    }
}
