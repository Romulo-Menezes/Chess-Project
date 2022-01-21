using ChessGame.Entities.Enums;

namespace ChessGame.Entities
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] AvailableMovements()
        {
            bool[,] movements = new bool[8, 8];
            Position pos = new Position(0, 0);

            // NE
            pos.SetPosition(Position.Row - 1, Position.Column + 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
                if (!Board.IsEmpty(pos) && Board.Pieces[pos.Row, pos.Column].Color != Color)
                {
                    break;
                }
                pos.Row -= 1;
                pos.Column += 1;
            }
            // SE
            pos.SetPosition(Position.Row + 1, Position.Column + 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
                if (!Board.IsEmpty(pos) && Board.Pieces[pos.Row, pos.Column].Color != Color)
                {
                    break;
                }
                pos.Row += 1;
                pos.Column += 1;
            }
            // SW
            pos.SetPosition(Position.Row + 1, Position.Column - 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
                if (!Board.IsEmpty(pos) && Board.Pieces[pos.Row, pos.Column].Color != Color)
                {
                    break;
                }
                pos.Row += 1;
                pos.Column -= 1;
            }
            // NW
            pos.SetPosition(Position.Row - 1, Position.Column - 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movements[pos.Row, pos.Column] = true;
                if (!Board.IsEmpty(pos) && Board.Pieces[pos.Row, pos.Column].Color != Color)
                {
                    break;
                }
                pos.Row -= 1; 
                pos.Column -= 1;
            }

            return movements;
        }

    }
}
