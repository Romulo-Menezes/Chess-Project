using ChessGame.Entities.Enums;

namespace ChessGame.Entities
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "N";
        }

        public override bool[,] AvailableMovements()
        {
            bool[,] movements = new bool[8, 8];
            Position pos = new Position(0, 0);

            pos.SetPosition(GetRow() - 1, GetColumn() - 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            pos.SetPosition(GetRow() - 1, GetColumn() + 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            pos.SetPosition(GetRow() + 1, GetColumn() - 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            pos.SetPosition(GetRow() + 1, GetColumn() + 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }

            pos.SetPosition(GetRow() - 2, GetColumn() - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            pos.SetPosition(GetRow() - 2, GetColumn() + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            pos.SetPosition(GetRow() + 2, GetColumn() - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            pos.SetPosition(GetRow() + 2, GetColumn() + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }

            return movements;
        }

    }
}
