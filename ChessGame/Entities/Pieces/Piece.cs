using ChessGame.Entities.Enums;

namespace ChessGame.Entities
{
    abstract class Piece
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

        protected bool CanMove(Position position)
        {
            Piece temp = Board.Pieces[position.Row, position.Column];
            return temp == null || temp.Color != Color;
        }

        public abstract bool[,] AvailableMovements();

    }
}
