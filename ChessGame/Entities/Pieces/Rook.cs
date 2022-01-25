using ChessGame.Entities.Enums;

namespace ChessGame.Entities
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] AvailableMovements()
        {
            bool[,] movements = new bool[8, 8];
            Position pos = new Position(0, 0);

            // North
            pos.SetPosition(GetRow() - 1, GetColumn());
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
                if (!Board.IsEmpty(pos) && Board.GetPieceColor(pos) != Color)
                {
                    break;
                }
                pos.Row -= 1;
            }
            // East
            pos.SetPosition(GetRow(), GetColumn() + 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
                if (!Board.IsEmpty(pos) && Board.GetPieceColor(pos) != Color)
                {
                    break;
                }
                pos.Column += 1;
            }
            // South
            pos.SetPosition(GetRow() + 1, GetColumn());
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
                if (!Board.IsEmpty(pos) && Board.GetPieceColor(pos) != Color)
                {
                    break;
                }
                pos.Row += 1;
            }
            // West
            pos.SetPosition(GetRow(), GetColumn() - 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
                if (!Board.IsEmpty(pos) && Board.GetPieceColor(pos) != Color)
                {
                    break;
                }
                pos.Column -= 1;
            }

            return movements;
        }

    }
}
