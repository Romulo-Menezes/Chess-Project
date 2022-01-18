using ChessGame.Entities.Enums;

namespace ChessGame.Entities
{
    class Piece
    {
        public Position Position { get;  set; }
        public Color Color { get; protected set; }
        public Board Chessboard { get; protected set; }
        public int QtyMoves { get; protected set; }

        public Piece(Board chessboard, Color color)
        {
            Chessboard = chessboard;
            Color = color;
            Position = null;
            QtyMoves = 0;
        }
    }
}
