using ChessGame.Entities.Enums;

namespace ChessGame.Entities
{
    abstract class Piece
    {
        public Position Position { get; set; }
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

        public int GetRow()
        {
            return Position.Row;
        }

        public int GetColumn()
        {
            return Position.Column;
        }

        public void ImcrementQtyMoves()
        {
            QtyMoves++;
        }

        public void DecrementQtyMoves()
        {
            QtyMoves--;
        }

        public bool ExistsAvailableMovements()
        {
            bool[,] movements = AvailableMovements();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (movements[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return AvailableMovements()[position.Row, position.Column];
        }

        public abstract bool[,] AvailableMovements();

    }
}
