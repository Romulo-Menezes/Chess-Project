using ChessGame.Entities.Enums;
using ChessGame.Controller;

namespace ChessGame.Entities
{
    class King : Piece
    {
        private ChessGameController _chessGame;

        public King(Board board, Color color, ChessGameController chessGame) : base(board, color)
        {
            _chessGame = chessGame;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool CastlingTest(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece != null && piece is Rook && piece.Color == Color && piece.QtyMoves == 0;
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

            // Special move: Castling

            if(QtyMoves == 0 && !_chessGame.Check)
            {
                Position rookPos_1 = new Position(GetRow(), GetColumn() + 3);
                if (CastlingTest(rookPos_1))
                {
                    Position pos1 = new Position(GetRow(), GetColumn() + 1);
                    Position pos2 = new Position(GetRow(), GetColumn() + 2);
                    if(Board.GetPiece(pos1) == null && Board.GetPiece(pos2) == null)
                    {
                        movements[pos2.Row, pos2.Column] = true;
                    }
                }

                Position rookPos_2 = new Position(GetRow(), GetColumn() - 4);
                if (CastlingTest(rookPos_2))
                {
                    Position pos1 = new Position(GetRow(), GetColumn() - 1);
                    Position pos2 = new Position(GetRow(), GetColumn() - 2);
                    Position pos3 = new Position(GetRow(), GetColumn() - 3);
                    if (Board.GetPiece(pos1) == null && Board.GetPiece(pos2) == null && Board.GetPiece(pos3) == null)
                    {
                        movements[pos2.Row, pos2.Column] = true;
                    }
                }
            }


            return movements;
        }

    }
}
