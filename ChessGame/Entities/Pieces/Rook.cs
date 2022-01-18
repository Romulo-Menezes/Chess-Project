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

    }
}
