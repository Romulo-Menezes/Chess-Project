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
            throw new System.NotImplementedException();
        }

    }
}
