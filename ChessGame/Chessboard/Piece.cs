namespace ChessGame.Chessboard
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public Board Chessboard { get; set; }
        public int QtyMoves { get; protected set; }

        public Piece(Board chessboard, Position position, Color color)
        {
            Chessboard = chessboard;
            Position = position;
            Color = color;
            QtyMoves = 0;
        }
    }
}
