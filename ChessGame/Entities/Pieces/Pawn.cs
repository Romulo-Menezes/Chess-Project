using ChessGame.Entities.Enums;

namespace ChessGame.Entities
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        public override bool[,] AvailableMovements()
        {
            bool[,] movements = new bool[8, 8];
            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.SetPosition(GetRow() - 1, GetColumn());
                if (Board.IsPositionValid(pos) && CanMove(pos))
                {
                    movements[pos.Row, pos.Column] = true;
                }
                pos.SetPosition(GetRow() - 2, GetColumn());
                if (Board.IsPositionValid(pos) && CanMove(pos) && QtyMoves == 0)
                {
                    movements[pos.Row, pos.Column] = true;
                }
                pos.SetPosition(GetRow() - 1, GetColumn() - 1);
                if (Board.IsPositionValid(pos) && IsThereAdversary(pos))
                {
                    movements[pos.Row, pos.Column] = true;
                }
                pos.SetPosition(GetRow() - 1, GetColumn() + 1);
                if (Board.IsPositionValid(pos) && IsThereAdversary(pos))
                {
                    movements[pos.Row, pos.Column] = true;
                }
            }
            else
            {
                pos.SetPosition(GetRow() + 1, GetColumn());
                if (Board.IsPositionValid(pos) && CanMove(pos))
                {
                    movements[pos.Row, pos.Column] = true;
                }
                pos.SetPosition(GetRow() + 2, GetColumn());
                if (Board.IsPositionValid(pos) && CanMove(pos) && QtyMoves == 0)
                {
                    movements[pos.Row, pos.Column] = true;
                }
                pos.SetPosition(GetRow() + 1, GetColumn() - 1);
                if (Board.IsPositionValid(pos) && IsThereAdversary(pos))
                {
                    movements[pos.Row, pos.Column] = true;
                }
                pos.SetPosition(GetRow() + 1, GetColumn() + 1);
                if (Board.IsPositionValid(pos) && IsThereAdversary(pos))
                {
                    movements[pos.Row, pos.Column] = true;
                }
            }
            return movements;
        }

        private bool IsThereAdversary(Position position)
        {
            Piece piece = Board.Pieces[position.Row, position.Column];
            return piece != null && piece.Color != Color;
        }

        protected override bool CanMove(Position position)
        {
            return Board.Pieces[position.Row, position.Column] == null; ;
        }



    }
}
