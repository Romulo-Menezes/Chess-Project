using ChessGame.Entities.Enums;

namespace ChessGame.Entities
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }

        public override bool[,] AvailableMovements()
        {
            bool[,] movements = new bool[8, 8];
            Position pos = new Position(0, 0);

            // North
            pos.SetPosition(GetRow() - 1, GetColumn());
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            // NE
            pos.SetPosition(GetRow(), GetColumn() + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            // East
            pos.SetPosition(GetRow(), GetColumn() + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            // SE
            pos.SetPosition(GetRow() + 1, GetColumn() + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            // South
            pos.SetPosition(GetRow() + 1, GetColumn());
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            // SW
            pos.SetPosition(GetRow() + 1, GetColumn() - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            // West
            pos.SetPosition(GetRow(), GetColumn() - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            // NW
            pos.SetPosition(GetRow() - 1, GetColumn() - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }

            return movements;
        }

    }
}
