namespace ChessGame.Entities
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

        public void SetPiecePosition(Piece piece, Position position)
        {
            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

    }
}
