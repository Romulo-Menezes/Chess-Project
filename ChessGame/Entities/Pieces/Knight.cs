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

            pos.SetPosition(Position.Row - 1, Position.Column - 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            pos.SetPosition(Position.Row - 1, Position.Column + 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            pos.SetPosition(Position.Row + 1, Position.Column - 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            pos.SetPosition(Position.Row + 1, Position.Column + 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }

            pos.SetPosition(Position.Row - 2, Position.Column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            pos.SetPosition(Position.Row - 2, Position.Column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            pos.SetPosition(Position.Row + 2, Position.Column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }
            pos.SetPosition(Position.Row + 2, Position.Column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
            }

            return movements;
        }

    }
}
