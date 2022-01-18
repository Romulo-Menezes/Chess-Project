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

    }
}
