using ChessGame.Entities.Enums;

namespace ChessGame.Entities
{
    class Piece
    {
        public Position Position { get;  set; }
        public Color Color { get; protected set; }
        public Board Board { get; protected set; }
        public int QtyMoves { get; protected set; }

        public Piece(Board board, Color color)
        {
            Board = board;
            Color = color;
            Position = null;
            QtyMoves = 0;
        }
    }
}
