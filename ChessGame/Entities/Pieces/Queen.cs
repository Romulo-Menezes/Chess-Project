using ChessGame.Entities.Enums;

namespace ChessGame.Entities
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "Q";
        }

    }
}
