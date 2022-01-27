using ChessGame.Entities.Enums;
using ChessGame.Controller;

namespace ChessGame.Entities
{
    class Pawn : Piece
    {
        private ChessGameController _chessGame;

        public Pawn(Board board, Color color, ChessGameController chessGame) : base(board, color)
        {
            _chessGame = chessGame;
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
                // Special move: En Passant
                if(GetRow() == 3)
                {
                    // Left
                    pos.SetPosition(GetRow(), GetColumn() - 1); 
                    if (Board.IsPositionValid(pos) && IsThereAdversary(pos) && (Board.GetPiece(pos) == _chessGame.VulnerableEnPassant))
                    {
                        movements[pos.Row - 1, pos.Column] = true;
                    }
                    // Right
                    pos.SetPosition(GetRow(), GetColumn() + 1);
                    if (Board.IsPositionValid(pos) && IsThereAdversary(pos) && (Board.GetPiece(pos) == _chessGame.VulnerableEnPassant))
                    {
                        movements[pos.Row - 1, pos.Column] = true;
                    }
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
                // Special move: En Passant
                if (GetRow() == 4)
                {
                    // Left
                    pos.SetPosition(GetRow(), GetColumn() - 1);
                    if (Board.IsPositionValid(pos) && IsThereAdversary(pos) && (Board.GetPiece(pos) == _chessGame.VulnerableEnPassant))
                    {
                        movements[pos.Row + 1, pos.Column] = true;
                    }
                    // Right
                    pos.SetPosition(GetRow(), GetColumn() + 1);
                    if (Board.IsPositionValid(pos) && IsThereAdversary(pos) && (Board.GetPiece(pos) == _chessGame.VulnerableEnPassant))
                    {
                        movements[pos.Row + 1, pos.Column] = true;
                    }
                }
            }
            return movements;
        }

        private bool IsThereAdversary(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece != null && piece.Color != Color;
        }

        protected override bool CanMove(Position position)
        {
            return Board.GetPiece(position) == null; ;
        }



    }
}
